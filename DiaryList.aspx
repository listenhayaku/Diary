<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="DiaryList.aspx.cs" Inherits="Diary.DiaryList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Content/MyStyle/DiaryList.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainFrame" runat="server">
    <asp:Button ID="NewDiaryButton" Text="新增日記" runat="server" OnClick="NewDiaryButton_Click"/>
    <table>
        <thead><tr><td>時間</td><td>標題</td><td></td></tr></thead>
        <tbody>
            <%for(int i = 0;i < listDiaryData.Count;i++){ %>
                <tr><td><%=listDiaryData[i].Date %></td><td><%=listDiaryData[i].Title %></td><td><a href="/DiaryContent?id=<%=i %>">編輯</a><a href="javascript: DeleteConfirm(<%=i %>)">刪除</a></td></tr>
            <%} %>
        </tbody>
    </table>
    <input id="_id" name="_id" class="hidden" style="display: none;"/>
    <input id="_del" name="_del" class="hidden" style="display: none;"/>
    <script src="/Content/MyScript/DiaryList.js"></script>
</asp:Content>
