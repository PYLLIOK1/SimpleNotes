$(document).ready(function () {
$("#tag").keydown(function (e) {
    if (e.keyCode == 32 && !$(this).val() && $(this).hasClass('first')) {
        return false;
    }
    if (e.keyCode == 32 && $(this).val()) {
        $(this).removeClass('last').addClass('after');
        $(this).clone(true).removeClass('first').addClass('clone').addClass('last').val('').appendTo('#strings');
        $(".last").focus();
        return false;
    }
    if (e.keyCode == 8 && !$(this).val() && $(this).hasClass('clone')) {
        $(this).remove();
        $(".after").focus();
        $(this).removeClass('after').addClass('last');
        return false
    }
    });
});