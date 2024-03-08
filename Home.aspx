<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Diary.Home" MasterPageFile="~/MySite.Master" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainFrame" runat="server">

    <div>
        <h1>Welcome to My Diary Application</h1>
        <h1>@User</h1>

        <asp:Button ID="DiaryListButton" Text="日記列表" runat="server" OnClick="DiaryListButton_Click" />
        
        <asp:Button ID="DiaryEditorButton" Text="日記編輯器" runat="server" OnClick="DiaryEditorButton_Click" />
    </div>

</asp:Content>
