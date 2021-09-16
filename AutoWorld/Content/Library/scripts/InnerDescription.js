﻿var DetailDescription = $('#DetailDescription').val();
var objectDescription = JSON.parse(DetailDescription);
var stringInnerDiscription = '';
var m = 0;
var srcImageDetail = '';

var selectUrlForImage = function (btnselect, txtImg, imgDetail) {
    btnselect.on("click", function (e) {
        e.preventDefault();
        var finder = new CKFinder();
        finder.selectActionFunction = function (url) {
            txtImg.val(url);
            var srcLink = "/Content/Library/" + url;
            imgDetail.attr('src', srcLink);
        };
        finder.popup();
    });
}


jQuery.each(objectDescription, function (k, value) {
    if (k.includes("img")) {
        srcImageDetail = "/Content/Library/" + value; 
        
        stringInnerDiscription += '<div class="form-group"><label class="control-label col-md-2">' + k + '</label><div class="col-md-10"><input class="form-control" type="text" id="txtImageDetail' + m + '" value="' + value + '" /><a href="#" type="button" class="btn btn-success btn-image" id="btnSelectImageDetail' + m + '">Select</a></div><div class="pt-1 pl-3"><img class="imgSize" id="imgDetail'+m+'" src="' + srcImageDetail+'"/></div></div>';
        m++;

    } else {
        stringInnerDiscription += '<div class="form-group"><label class="control-label col-md-2">' + k + '</label><div class="col-md-10"><input class="form-control" type="text" value="' + value + '" /></div></div>'
    }

    
});


//var ChangeImage = function (i) {
//    var i = 0;
//    var txtSelect = '#txtImageDetail' + i;
//    var imgDetail = '#imgDetail' + i;
//    var srcImg = '/Content/Library/' + $(txtSelect).val();
//    $(imgDetail).attr('src', srcImg);
//    //$(imgDetail).attr('src') = '/Content/Library /' + $(txtSelect).val();
//    //console.log($(imgDetail).attr('src'));
//    //console.log($(txtSelect).val());


//};

$('#InnerDiscription').html(stringInnerDiscription);

for (var i = 0; i < m; i++) {
        var btnSelect = '#btnSelectImageDetail' + i;
    var txtSelect = '#txtImageDetail' + i;
    var imgDetail = '#imgDetail' + i;
    selectUrlForImage($(btnSelect), $(txtSelect), $(imgDetail));
    
}
selectUrlForImage($('#btnSelectImage'), $('#txtImage'), $('#imgDisplay'));













