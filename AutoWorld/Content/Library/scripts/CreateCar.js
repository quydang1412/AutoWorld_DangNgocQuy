////$('.btn-image').on("click", function (e) {
////    e.preventDefault();
////    var finder = new CKFinder();
////    finder.selectActionFunction = function (url) {
////        //$('#txtImage').val(url);
////        $('.txtImg').val(url);

////    };
////    finder.popup();
////});

var selectUrlForImage = function (btnselect, txtImg) {
    btnselect.on("click", function (e) {
        e.preventDefault();
        var finder = new CKFinder();
        finder.selectActionFunction = function (url) {
            txtImg.val(url);

        };
        finder.popup();
    });
}

selectUrlForImage($('#btnSelectImage'), $('#txtImage'));
selectUrlForImage($('#btnSelectImageDetail1'), $('#txtImageDetail1'));
selectUrlForImage($('#btnSelectImageDetail2'), $('#txtImageDetail2'));
selectUrlForImage($('#btnSelectImageDetail3'), $('#txtImageDetail3'));
selectUrlForImage($('#btnSelectImageDetail4'), $('#txtImageDetail4'));
selectUrlForImage($('#btnSelectImageDetail5'), $('#txtImageDetail5'));
