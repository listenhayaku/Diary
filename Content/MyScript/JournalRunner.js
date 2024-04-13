let BoxStatus = 0;  //0 = Shrinked;1 = Expanded

function main() {

    console.log("(deubg)[JournalRunner]start");
    if (location.pathname == "/DiaryContent") {
        console.log("(deubg)[JournalRunner]run");
    }
}

function ExpandBox() {
    console.log("(debug)[JournalRunner]ExpandBox start");
    var ObjectList_Partial_ArrowIcon = document.getElementById("ObjectList_Partial_ArrowIcon");
    ObjectList_Partial_ArrowIcon.classList.remove("Shrinked");
    ObjectList_Partial_ArrowIcon.classList.add("Expanded");
    var ObjectListBox = document.getElementById("ObjectListBox");
    ObjectListBox.classList.remove("Shrinked");
    ObjectListBox.classList.add("Expanded");
    BoxStatus = 1;
}

function ShrinkBox() {
    console.log("(debug)[JournalRunner]ShrinkBox start");
    var ObjectList_Partial_ArrowIcon = document.getElementById("ObjectList_Partial_ArrowIcon");
    ObjectList_Partial_ArrowIcon.classList.remove("Expanded");
    ObjectList_Partial_ArrowIcon.classList.add("Shrinked");
    var ObjectListBox = document.getElementById("ObjectListBox");
    ObjectListBox.classList.remove("Expanded");
    ObjectListBox.classList.add("Shrinked");
    BoxStatus = 0;
}

function SwitchBoxStatus() {
    if (BoxStatus == 0) ExpandBox();
    else ShrinkBox();
}

main();