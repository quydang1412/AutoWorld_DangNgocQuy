////var contact = {
////    init: function() {
////        contact.registerEvents();
////    },
////    registerEvents: function() {

        
////    }
////};

////contact.init();

$('#btnContact').off('click').on('click', function () {
    var name = $('#name').val();
    var email = $('#email').val();
    var tel = $('#tel').val();
    var mess = $('#mess').val();

    $.ajax({
        
        type: 'POST',
        data: {
            name: name,
            email: email,
            phone: tel,
            message: mess
        },
        dataType: "json",
        url: '/HomePage/SubmitContact',
        success: function (res) {
            if (res.status) {

                $('#AlertBox1').addClass("alert-success");
                $('#AlertBox1').html("<p>Action is sucess</p>");
                $('#AlertBox1').show();
                $('#AlertBox1').delay(1000).slideUp(500);
                
            } else {
                $('#AlertBox1').addClass("alert-danger");
                $('#AlertBox1').html("<p>Action is failed</p>");
                $('#AlertBox1').show();
                $('#AlertBox1').delay(1000).slideUp(500);
            }
        },
        error: function (err) {
            alert(err);
        }

    });
});
