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
	' @subpackage ErrorHandler
	' @copyright CKSource - Frederico Knabben

	''
	' File upload error handler
	'
	' @package CKFinder
	' @subpackage ErrorHandler
	' @copyright CKSource - Frederico Knabben
	'
class CKFinder_Connector_ErrorHandler_FileUpload
	'pseudo inheritance
	private base

	Private Sub Class_Initialize()
		Set base = new CKFinder_Connector_ErrorHandler_Base
	End Sub

	Private Sub Class_Terminate()
		Set base = nothing
	End Sub

	Public Property Let setCatchAllErrors(newValue)
		base.setCatchAllErrors newValue
	End Property

	function setSkipErrorsArray(newArray)
		base.setSkipErrorsArray newArray
	End Function

	''
	' Throw file upload error, return true if error has been thrown, false if error has been catched
	'
	' @param int $number
	' @param string $text
	' @access public
	'
	function throwError(number, uploaded, debugText)
		If (base.SkipError(number)) Then Exit Function

'		response.clear
		Response.charset="utf-8"

		Dim sFileName, sFileUrl, sResponse, errorMessage, funcNum
		sFileName = oCKFinder_Factory.Registry.Item("FileUpload_fileName")
		sFileUrl = oCKFinder_Factory.Registry.Item("FileUpload_url")

		' incompatiblity between 1.3 and 1.4
		If TypeName(uploaded)<>"Boolean" Then
			sFileName = uploaded
			uploaded = False
		End If

		If (CKFinder_Debug) Then
			'Response.ContentType	= "text/plain"
			response.write "<scr" & "ipt type=""text/javascript"">"
			sResponse = sResponse & "CKFinder connector for classic ASP. The connector is in Debug Mode." & vblf
			sResponse = sResponse & "In order to use the connector you'll have to set CKFinder_Debug = false." & vblf
			sResponse = sResponse & "Response from the connector (including debugging messages):" & vblf
			sResponse = sResponse & "                                                                        " & vblf
			sResponse = sResponse & "Response Number: " & number & vblf
			sResponse = sResponse & "FileUpload_fileName: " & sFileName & vblf
			sResponse = sResponse & "Uploaded: " & uploaded & vblf
			sResponse = sResponse & "Debug Text: " & debugText & vblf

			sResponse = Replace( sResponse, "'", "\'")
			sResponse = Replace( sResponse, vbcr, "")
			sResponse = Replace( sResponse, vblf, "\n' + " & vbcr & "'")
			sResponse = Replace( sResponse, "</", "<\/")

			response.write "alert('" & sResponse & "');"
			response.write "</scr" & "ipt>"
		Else

			errorMessage = oCKFinder_Factory.Translator.getErrorMessage(number, sFileName)
			If Not(uploaded) Then
				sFileName = ""
				sFileUrl = ""
			End If

			if (request.queryString("response_type") = "txt") then
				response.write sFileName & "|" & errorMessage
				response.end
			End if

			response.write "<scr" & "ipt type=""text/javascript"">"

			funcNum = request.queryString("CKFinderFuncNum")
			If funcNum<>"" then
				funcNum = oCKFinder_Factory.RegExp.ReplacePattern("[^0-9]", funcNum, "")
	            response.write "window.parent.CKFinder.tools.callFunction(" & funcNum & ", '" & replace(sFileUrl & sFileName, "'", "\'") & "', '" & replace(errorMessage, "'", "\'") & "');"
			else
				response.write "window.parent.OnUploadCompleted('" & replace(sFileName, "'", "\'") & "', '" & replace(errorMessage, "'", "\'") & "') ;"
			End if
			response.write "</scr" & "ipt>"
		End if
		response.end
	end Function
End Class

</script>
