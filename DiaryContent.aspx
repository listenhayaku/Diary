<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="DiaryContent.aspx.cs" Inherits="Diary.DiaryContent" %>
<%@ Register Src="~/ObjectList_Partial.ascx" TagName="ObjectList_Partial" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Content/MyStyle/DiaryContent.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainFrame" runat="server">
    <div class="col10 horizontal_arrangement_container">
        <div class="horizontal_arrangement">    
            <table class="MyTableStyle1">
                <thead>
                    <tr>
                        <td>日期</td><td>標題</td><td>類別</td>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td><%=diaryData.Date %></td><td><asp:TextBox ID="FrontTitle" runat="server" /></td><td><%=diaryData.Class %></td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:TextBox ID="FrontJournal" TextMode="MultiLine" UseSubmitBehavior="false" runat="server" style="width: 100%;height:100%;" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="horizontal_arrangement">
            <uc:ObjectList_Partial runat="server" />
        </div>
    </div>
    <asp:Button ID="ModifyButton" Text="Modify" UseSubmitBehavior="false" runat="server" OnClick="ModifyButton_Click"/>
    <asp:Button ID="BackButton" Text="BacktoList" UseSubmitBehavior="false" runat="server" OnClick="BacktoListButton_Click"/>
    
    <script src="/Content/MyScript/JournalRunner"></script>
</asp:Content>
