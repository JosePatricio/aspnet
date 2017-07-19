$(document).ready(function () {

    
    $('#header a').click(function () {
        var page = $(this).attr('href');
        $('#contenido').load(page);
        return false;
    })
});