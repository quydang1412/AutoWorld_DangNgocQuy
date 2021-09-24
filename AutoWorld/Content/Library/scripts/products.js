var p = {
    init: function () {
        p.registerEvent();
    },
    registerEvent: function () {
        $('#btnSearch').click();
        
        $(document).on('click', '.addToCart', function () {
            
            $.ajax({
                type: 'GET',
                dataType: 'json',
                url: '/Cart/UpdateCartNumber',
                success: function (res) {
                    if (res.status) {
                        var count = res.data;
                        $('#CountCartItem').html(count);
                    }
                    
                }

            });
        });
    }
}

p.init();

//$(document).ready(function () {
    
//});

