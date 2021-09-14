var DetailDescription = $('#DetailDescription').val();
var objectDescription = JSON.parse(DetailDescription);
var stringInnerDiscription = '';
//Object.entries(DetailDescription).forEach(([value,key]) => {
//    stringInnerDiscription += '<label>' + `${key}` + '</label><input type="text" value="' + `${value}`+'" />"'

    
//});

//for (var k in DetailDescription) {

//    stringInnerDiscription += '<label>' + k + '</label><input type="text" value="' + DetailDescription[k] + '" />"'
//}
var m = 0;

jQuery.each(objectDescription, function (k, value) {
    if (k.includes("img")) {
        stringInnerDiscription += '<div class="form-group"><label class="control-label col-md-2">' + k + '</label><div class="col-md-10"><input class="form-control" type="text" value="' + value + '" /><a href="#" type="button" class="btn btn-success btn-image" id="btnSelectImage' + m +'">Select</a></div></div>';
        m++;
    } else {
        stringInnerDiscription += '<div class="form-group"><label class="control-label col-md-2">' + k + '</label><div class="col-md-10"><input class="form-control" type="text" value="' + value + '" /></div></div>'
    }

    
});



$('#InnerDiscription').html(stringInnerDiscription);

