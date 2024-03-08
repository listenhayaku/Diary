function DeleteConfirm(i) {
    var nexturl = "/DeleteDiary";
    if (confirm("確認刪除?")) {
        //location.pathname = nexturl;    //這樣導?之後的參數不會影響 DiaryList?id={num} 導過去會直接變成DeleteDiary?id={num} 太方便了參數都不需要用到
        var theForm = document.forms["form1"];
        theForm._id.value = i;
        theForm._del.value = true;
        theForm.submit();
    }
    else {
        //location.pathname = "/DiaryList";
    }
}