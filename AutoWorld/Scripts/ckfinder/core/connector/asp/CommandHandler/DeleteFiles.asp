<script runat="server" language="VBScript">
' CKFinder
' ========
' http://cksource.com/ckfinder
' Copyright (C) 2007-2015, CKSource - Frederico Knabben. All rights reserved.
'
' The software, this file and its contents are subject to the CKFinder
' License. Please read the license.txt file before using, installing, copying,
' modifying or distribute this file or part of its contents. The contents of
' this file is part of the Source Code of CKFinder.

	''
	' @package CKFinder
	' @subpackage CommandHandlers
	' @copyright CKSource - Frederico Knabben
	'

	''
	' Handle DeleteFiles command
	'
	' @package CKFinder
	' @subpackage CommandHandlers
	' @copyright CKSource - Frederico Knabben
	'
class CKFinder_Connector_CommandHandler_DeleteFiles

	''
	' Command name
	'
	' @access private
	' @var string
	'
	private command

	'pseudo inheritance
	private base

	Private Sub Class_Initialize()
		Set base = new CKFinder_Connector_CommandHandler_XmlCommandHandlerBase
		Set base.child = me
		command = "DeleteFiles"
	End Sub

	Private Sub Class_Terminate()
		Set base.child = Nothing
		Set base = Nothing
	End Sub

	' Pseudo inheritance
	Public Property Get currentFolder()
		Set currentFolder = base.currentFolder
	End Property

	Public Sub sendResponse(response)
		base.sendResponse(response)
	End sub

	Public Property Get ErrorHandler()
		Set ErrorHandler = base.ErrorHandler
	End Property

	function buildXml( oXML )
		Dim fileName, filePath, thumbPath, oDeleteFileNode, resourceTypeConfig
'		Set resourceTypeConfig = currentFolder.getResourceTypeConfig()

		if ( request.Form("CKFinderCommand") <> "true") then
			errorHandler.throwError CKFINDER_CONNECTOR_ERROR_INVALID_REQUEST, "", "Not sent by CKFinder"
		End if

		if (Not currentFolder.checkAcl(CKFINDER_CONNECTOR_ACL_FILE_DELETE)) then
			errorHandler.throwError CKFINDER_CONNECTOR_ERROR_UNAUTHORIZED, "", "Not authorized to access " & currentFolder.getClientPath
		End If

		Dim oErrorsNode, errorCode, deletedNum, oDeleteFilesNode, checkedPaths, aclMasks, aclConfig
		Set oErrorsNode = oXML.connectorNode.createChild("Errors")
		errorCode = CKFINDER_CONNECTOR_ERROR_NONE
		deletedNum = 0
		Set oDeleteFilesNode = oXML.connectorNode.createChild("DeleteFiles")

		Set aclConfig = oCKFinder_Factory.Config.getAccessControlConfig()
		Set aclMasks = Server.CreateObject("Scripting.Dictionary")
		Set checkedPaths = Server.CreateObject("Scripting.Dictionary")

		Dim iFileNum, fileType, path, isAuthorized
		iFileNum = 0
		Do while ( Request.Form("files[" & iFileNum & "][type]") <> "")

			fileName = Request.Form("files[" & iFileNum & "][name]")
			fileType = Request.Form("files[" & iFileNum & "][type]")
			path = Request.Form("files[" & iFileNum & "][folder]")
			iFileNum = iFileNum + 1

			if (fileName="" Or path="") then
				errorHandler.throwError CKFINDER_CONNECTOR_ERROR_INVALID_REQUEST, "", "Invalid name or path "
			End if

			' cached at Config object
			Set resourceTypeConfig = oCKFinder_Factory.Config.getResourceTypeConfig(fileType)
			if (resourceTypeConfig Is Nothing) then
				errorHandler.throwError CKFINDER_CONNECTOR_ERROR_INVALID_TYPE, "", "Invalid type " & fileType
			End if

			if (Not oCKFinder_Factory.UtilsFileSystem.checkFileName(fileName)) then
				errorHandler.throwError CKFINDER_CONNECTOR_ERROR_INVALID_REQUEST, "", "Invalid FileName " & fileName
			End if

			if (Not resourceTypeConfig.checkExtension(fileName)) then
				errorHandler.throwError CKFINDER_CONNECTOR_ERROR_INVALID_REQUEST, "", "Invalid Extension " & fileName
			End if

			if not(checkedPaths.exists(path)) then
				checkedPaths.add path, true

				if (resourceTypeConfig.checkIsHiddenPath(path)) then
					errorHandler.throwError CKFINDER_CONNECTOR_ERROR_INVALID_REQUEST, "", "Hidden path " & path
				End if
			End if

			if (resourceTypeConfig.checkIsHiddenFile(fileName)) then
				errorHandler.throwError CKFINDER_CONNECTOR_ERROR_INVALID_REQUEST, "", "Invalid FileName " & fileName
			End if


			if not(aclMasks.exists(fileType & "@" & path)) then
				aclMasks.add fileType & "@" & path, aclConfig.getComputedMask(fileType, path)
			End if

			isAuthorized = (aclMasks(fileType & "@" & path) and CKFINDER_CONNECTOR_ACL_FILE_DELETE) = CKFINDER_CONNECTOR_ACL_FILE_DELETE
			if not(isAuthorized) then
				errorHandler.throwError CKFINDER_CONNECTOR_ERROR_UNAUTHORIZED, "", "Failed ACL"
			End if

			filePath = oCKFinder_Factory.UtilsFileSystem.combinePaths(currentFolder.getServerPath(), fileName)

			if (Not oCKFinder_Factory.UtilsFileSystem.FileExists(filePath)) then
				errorCode = CKFINDER_CONNECTOR_ERROR_FILE_NOT_FOUND
				appendErrorNode oErrorsNode, errorCode, fileName, fileType, path
			else
				Dim deleted
				On Error Resume Next
				If Not(oCKFinder_Factory.UtilsFileSystem.DeleteFile(filePath)) then
					errorCode = CKFINDER_CONNECTOR_ERROR_ACCESS_DENIED
					appendErrorNode oErrorsNode, errorCode, fileName, fileType, path
					deleted = false
				Else
					deleted = true
				End If

				If Err.number<>0 And deleted Then
					deleted = false
					errorCode = CKFINDER_CONNECTOR_ERROR_UNKNOWN
					appendErrorNode oErrorsNode, errorCode, fileName, fileType, path
					'errorHandler.throwError CKFINDER_CONNECTOR_ERROR_UNKNOWN, "Unable to delete file " & fileName, "(error:" & Err.number & ", " & Err.description & ") "
				End if

				On Error goto 0

				If (deleted) Then
					deletedNum = deletedNum + 1
					thumbPath = oCKFinder_Factory.UtilsFileSystem.combinePaths(currentFolder.getThumbsServerPath(), fileName)

					oCKFinder_Factory.UtilsFileSystem.DeleteFile thumbPath
				End If
			End if
		loop


		oXML.connectorNode.appendChild oDeleteFilesNode
		oDeleteFilesNode.addAttribute "deleted", deletedNum

		if (errorCode <> CKFINDER_CONNECTOR_ERROR_NONE) then
			oXML.connectorNode.appendChild oErrorsNode
			errorHandler.throwError CKFINDER_CONNECTOR_ERROR_DELETE_FAILED, "", "internal error code " & errorCode
		End if

	End function

	private sub appendErrorNode(oErrorsNode, errorCode, name, resourceTypeName, path)
		Dim oErrorNode
		Set oErrorNode = oErrorsNode.addChild("Error")
		oErrorNode.addAttribute "code", errorCode
		oErrorNode.addAttribute "name", name
		oErrorNode.addAttribute "type", resourceTypeName
		oErrorNode.addAttribute "folder", path
	End sub

End Class

</script>
