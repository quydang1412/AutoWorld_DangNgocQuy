var calculator = function () {
    var sovay = parseInt($('#sovay').val());
    var sothang = parseInt($('#sothang').val());
    if (sovay != 0 && sothang != 0) {
        var tonglai = sovay * sothang * 0.1 / 12;
        var tongphi = sovay + tonglai;
        var laihangthang = (tongphi / sothang).toFixed(2);
        $('#payment').removeClass('hide');
        $('#payment').html(laihangthang + "$");
    } else {
        $('#payment').html('0');
    }
   
}