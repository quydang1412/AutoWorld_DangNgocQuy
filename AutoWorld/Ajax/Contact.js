var contact = {
    init: function () {
        contact.registerEvents();
    },
    registerEvents: function () {
        var name = $('#name').val();
        var email = $('#email').val();
        var tel = $('#tel').val();
        var mess = $('#mess').val();
        

        $('#btnContact').off('click').on('click', function () {
            $.ajax({
                url: 'HomePage/SaveMessage',
                type: 'POST',
                data: {
                    name: name,
                    email: email,
                    phone: tel,
                    message: mess
                },
                dataType: "json",
                success: function (res) {
                    if (res.status) {
                        alert("gui thanh cong");
                    }
                }

            });
        });
    }
}