$(function () {
    // 事件 - 開關點選 - 日期分類
    $(document).on('click', '.js-blog-btn-switch-date', function () {
        var target = $(this).parent().find('.js-blog-list').first();

        toggleBlock(target, !target.hasClass('active'));
    });
});