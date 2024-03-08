function Toggle() {
    var LoginCard = document.getElementById("LoginCard");
    var RegisterCard = document.getElementById("RegisterCard");
    //根據https://stackoverflow.com/questions/9444751/why-javascript-this-styleproperty-return-an-empty-string
    //的說法，.style屬性適任讓人直接更改，本身不會載入style
    var LoginStyle = getComputedStyle(LoginCard);
    var RegisterStyle = getComputedStyle(RegisterCard);

    

    //註冊轉登入
    if (LoginStyle.opacity == 0 && RegisterStyle.opacity == 1) {
        ToggletoLogin();

    }
    //登入轉註冊
    else if (LoginStyle.opacity == 1 && RegisterStyle.opacity == 0) {
        ToggletoRegister();
    }
    else {
        console.log("[Toggle]error");
        console.log("[Toggle]LoginStyle.opacity"+LoginStyle.opacity);
        console.log("[Toggle]RegisterStyle.opacity" +RegisterStyle.opacity);
        LoginCard.style.opacity = 0;
        LoginCard.style.zIndex = 0;
        RegisterCard.style.opacity = 1;
        RegisterCard.style.zIndex = 1;
    }
}

function ToggletoLogin() {
    var LoginCard = document.getElementById("LoginCard");
    var RegisterCard = document.getElementById("RegisterCard");
    LoginCard.style.opacity = 1;
    LoginCard.style.zIndex = 1;
    RegisterCard.style.opacity = 0;
    RegisterCard.style.zIndex = 0;
    //清除register的警示紅字
    document.getElementById("ErrorMessageBox").textContent = "";
}
function ToggletoRegister() {
    var LoginCard = document.getElementById("LoginCard");
    var RegisterCard = document.getElementById("RegisterCard");
    LoginCard.style.opacity = 0;
    LoginCard.style.zIndex = 0;
    RegisterCard.style.opacity = 1;
    RegisterCard.style.zIndex = 1;
}

//驗證兩次密碼是否一致
function ValidateCheckPassword() {
    var RegisterpasswordInput = document.getElementById("MainFrame_RegisterpasswordInput");
    
    var RegisterpasswordcheckInput = document.getElementById("MainFrame_RegisterpasswordcheckInput");
    var RegisterButton = document.getElementById("MainFrame_RegisterButton");

    if (RegisterpasswordcheckInput.value == RegisterpasswordInput.value) RegisterButton.disabled = false;
    else RegisterButton.disabled = true;
}

//debug用 懶得一直登入
function AutoLoginAdmin() {
    var MainFrame_UsernameInput = document.getElementById("MainFrame_UsernameInput");
    var MainFrame_PasswordInput = document.getElementById("MainFrame_PasswordInput");
    var LoginButton = document.getElementById("MainFrame_LoginButton");
    MainFrame_UsernameInput.value = "admin";
    MainFrame_PasswordInput.value = "admin";
    LoginButton.click();
}
//讓密碼輸入玩按下enter就可以登入 因為我把按鈕的submit拔掉 而拔掉的原因又是因為login跟registery放在同一個表單裡面 所以要拔掉按鈕的submit
function ListenEnter() {
    document.getElementById("MainFrame_PasswordInput").addEventListener("keypress", function (e) {
        if (e.key == "Enter") {
            document.getElementById("MainFrame_LoginButton").click();
        }
    });
    document.getElementById("MainFrame_RegisterpasswordcheckInput").addEventListener("keypress", function (e) {
        if (e.key = "Enter") {
            document.getElementById("MainFrame_RegisterButton").click();
        }
    });

    /*document.addEventListener("keypress", function (e) {
        console.log("(debug)[ListenEnter]you press a key but i don't know what is it");
        if (e.key == "Enter") {
            console.log("(debug)[ListenEnter]you press enter key");
            var LoginCard = document.getElementById("LoginCard");
            var RegisterCard = document.getElementById("RegisterCard");
            //根據https://stackoverflow.com/questions/9444751/why-javascript-this-styleproperty-return-an-empty-string
            //的說法，.style屬性適任讓人直接更改，本身不會載入style
            var LoginStyle = getComputedStyle(LoginCard);
            var RegisterStyle = getComputedStyle(RegisterCard);

            //頁面是註冊
            if (LoginStyle.opacity == 0 && RegisterStyle.opacity == 1) {
                document.getElementById("MainFrame_RegisterButton").click();
            }
            //頁面是登入
            else if (LoginStyle.opacity == 1 && RegisterStyle.opacity == 0) {
                document.getElementById("MainFrame_LoginButton").click();
            }
            else {

            }
        }
    });*/
}

function main() {
    if (location.hash == "#register") {
        ToggletoRegister();
        document.getElementById("ErrorMessageBox").textContent = "Opps!There is the same username in database";
    }

    ListenEnter();
    //setTimeout(AutoLoginAdmin, 1000);
}

main();
