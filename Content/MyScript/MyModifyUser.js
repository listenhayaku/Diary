var AllColumnPassword = document.querySelectorAll("[id^=ColumnPassword]");
var AllPassword = document.querySelectorAll("[id^=Password]");


for (let i = 0; i < AllColumnPassword.length; i++) {
    AllColumnPassword[i].onclick = () => {
        AllPassword[i].value = AllColumnPassword[i].textContent;
        AllColumnPassword[i].textContent = "";
        AllPassword[i].style.display = "block";
    }
}