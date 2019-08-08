$(function () {
    $('.conception-btn').click(function () {
        var url = '/Official/FireGeneration/ConceptionContent/3';

        $.ajax({
            url: url,
            success: function (view) {
                $('#js-block-coception-content').html(view);
            }
        });
    });
});