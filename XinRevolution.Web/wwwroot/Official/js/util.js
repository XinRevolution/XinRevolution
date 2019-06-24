// 開關區塊
function toggleBlock(block, show) {
    if (show)
        block.addClass('active');
    else
        block.removeClass('active');
}

// 切換 class
function toggleClass(target, add, className) {
    if (add)
        target.addClass(className);
    else
        target.removeClass(className);
}

// 發送 Ajax 要求
function sendAjaxRequest(option) {
    $.ajax(option);
}

// 鎖定畫面
function blockUI(lock, message) {

}

// 顯示訊息
function showMessage(message){

}