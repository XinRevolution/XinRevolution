$(function () {
    $('.js-character').click(function () {
        var controller = $(this).data('controller');
        var action = $(this).data('action');
        var id = $(this).data('id');

        $.ajax({
            url: '/Official/' + controller + '/' + action + '/' + id,
            success: function (view) {
                $('#js-layout-popup-content').html(view);
                $('#js-layout-block-popUp').addClass('active');
            }
        });
    });

    $('#js-layout-btn-popUp-close').click(function () {
        $('#js-layout-popup-content').html('');
        $('#js-layout-block-popUp').removeClass('active');
    });
});