var calculator = function () {
    var sv = $('#sovay').val();
    var st = $('#sothang').val();
    var sovay = (sv == "") ? 0 : parseInt(sv);
    var sothang = (st == "") ? 0 : parseInt(st);
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