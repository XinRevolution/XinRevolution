$(function () {
    // 事件 - 轉場動畫淡出
    $(window).on('load', function () {
        $('#js-layout-block-transition').delay(1000).fadeOut("slow");
    });

    // 事件 - 按鈕點選 - Menu
    $(document).on('click', '#js-layout-btn-menu-show', function () {
        toggleBlock($('#js-layout-block-menu'), true);
    });

    // 事件 - 按鈕點選 - Menu - 關閉
    $(document).on('click', '#js-layout-btn-menu-hide', function () {
        toggleBlock($('#js-layout-block-menu'), false);
    });

    // 事件 - 按鈕點選 - AboutUs
    $(document).on('click', '#js-layout-btn-aboutUs-show', function () {
        toggleBlock($('#js-layout-block-aboutUs'), true);
    });

    // 事件 - 按鈕點選 - AboutUs - 關閉
    $(document).on('click', '#js-layout-btn-aboutUs-hide', function () {
        toggleBlock($('#js-layout-block-aboutUs'), false);
    });
});