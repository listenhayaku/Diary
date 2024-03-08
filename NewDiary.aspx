<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="NewDiary.aspx.cs" Inherits="Diary.NewDiary" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Content/MyStyle/NewDiary.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainFrame" runat="server">
    <table class="MyTableStyle1">
        <thead>
            <tr>
                <td>標籤</td><td>日記標題</td>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td><asp:TextBox ID="class" runat="server" /></td><td><asp:TextBox ID="title" runat="server" /></td>
            </tr>
            <tr>
                <td colspan="2"><asp:TextBox ID="journal" TextMode="MultiLine" runat="server" /></td>
            </tr>
        </tbody>
    </table>
    <asp:Button ID="NewDiaryButton" Text="新增" runat="server" OnClick="NewDiaryButton_Click"/>
    <asp:Button ID="CancelButton" Text="取消" runat="server" OnClick="CancelButton_Click"/>



</asp:Content>
