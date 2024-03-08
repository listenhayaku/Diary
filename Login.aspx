<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Diary.Login" MasterPageFile="~/MySite.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="/Content/MyStyle/Login.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainFrame" runat="server">
    <h1 id="ErrorMessageBox" style="color: red;"></h1>
    <div class="CardContain">
        <div id="LoginCard">
            <h1>Login</h1>
            <label>username</label>
            <asp:TextBox ID="UsernameInput" runat="server" />
            <label>password</label>
            <asp:TextBox ID="PasswordInput" runat="server" type="password" />
            <asp:Button ID="LoginButton" Text="Login" runat="server" OnClick="LoginButton_Click" UseSubmitBehavior="false"/>
            <a href="javascript: Toggle()" onclick="">Sign up</a>
        </div>
        <div id="RegisterCard">
            <h1>Register</h1>
            <label>username</label>
            <asp:TextBox ID="RegisterusernameInput" runat="server" />
            <label>password</label>
            <asp:TextBox ID="RegisterpasswordInput" runat="server" type="password" />
            <label>check your password</label>
            <asp:TextBox ID="RegisterpasswordcheckInput" runat="server" type="password" oninput ="javascript: ValidateCheckPassword()"/>
            <asp:Button ID="RegisterButton" Text="Register" runat="server" OnClick="RegisterButton_Click" UseSubmitBehavior="false" disabled/>
            <a href="javascript: Toggle()" onclick="">Sign in</a>
        </div>
    </div>

    <script src="/Content/MyScript/MyLoginScript.js"></script>
    <script src="/Content/MyScript/MyWebsocket.js"></script>
</asp:Content>
