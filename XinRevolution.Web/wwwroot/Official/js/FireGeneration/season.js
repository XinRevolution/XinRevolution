$(function () {
    $('.js-node').click(function () {
        var id = $(this).data('id');

        $.ajax({
            url: '/Official/FireGeneration/Chapter',
            success: function (view) {
                $('#js-season-block-intro').html(view);
            }
        });
    });

    $(document).on('click', '.js-chapter', function () {
        $.ajax({
            url: '/Official/FireGeneration/Comic',
            success: function (view) {
                $('#js-layout-popup-content').html(view);
                $('#js-layout-block-popUp').addClass('active');
            }
        });
    });

    $('.js-node').first().click();
});