<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="ModifyUser.aspx.cs" Inherits="Diary.ModifyUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Content/MyStyle/ModifyUser.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainFrame" runat="server">
    <h1>ModifyUserPage</h1>


    <table>
        <thead>
            <tr><td>Id</td><td>Group</td><td>Username</td><td>Password</td></tr>
        </thead>
        <tbody>
            <tr><td>@Id@<input id="UserId@Num@" name="UserId@Num@" value="@Id@" style="display:none;" /></td><td><select id="UserPermission@Num@" name="UserPermission@Num@"><option value=""><!--原始的value空值讓後端直接判斷有沒有被改過-->@Group@</option><option value="@Value2@">@Group2@</option></select></td><td>@Username@<input id="Username@Num@" name="Username@Num@" value="@Username@" style="display:none;" /></td><td><span id="ColumnPassword@Num@">@Password@</span><input id="Password@Num@" name="Password@Num@" value="" style="display:none;" size="5" /></td></tr>
        </tbody>
    </table>    

    <asp:Button runat="server" ID="ModifySubmitButton" Text="Modify" OnClick ="ModifySubmitButton_Click"/>
    <asp:Button runat="server" ID="ModifyCancelButton" Text="Cancel" OnClick ="ModifyCancelButton_Click"/>


    <!--本來想說用GridView 但是發現沒什麼文章可以看 查到的目前GridView 原生提供新增跟修改的方法不符我意-->
    <!--
    <asp:sqldatasource id="CustomersSource"
        selectcommand="SELECT * FROM UserData"
        updatecommand="UPDATE UserData SET [Usergroup] = @Usergroup,[Username] = @Username,[Password] = @Password WHERE [Id] = @Id"
        connectionstring="<%$ ConnectionStrings:DbConnectionString %>" 
        runat="server"/>

    <asp:gridview id="CustomersGridView" 
      datasourceid="CustomersSource" 
      autogeneratecolumns="False"
      emptydatatext="No data available." 
      allowpaging="True" 
      runat="server" DataKeyNames="Id" CellPadding="4" ForeColor="#333333" GridLines="None">
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    <Columns>
        <asp:CommandField ShowEditButton ="true" ShowInsertButton ="true" />
        <asp:BoundField DataField="Id" HeaderText="Id" 
            InsertVisible="False" ReadOnly="True" SortExpression="CustomerID" />
        <asp:BoundField DataField="Usergroup" HeaderText="Usergroup" 
            SortExpression="Group" />
        <asp:BoundField DataField="Username" HeaderText="Username" 
            SortExpression="Username" />
        <asp:BoundField DataField="Password" HeaderText="Password" 
            SortExpression="Password" />
    </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
</asp:gridview>-->

    <!--<asp:Table id="UserData" 
        GridLines="Both" 
        HorizontalAlign="Center" 
        Font-Names="Verdana" 
        Font-Size="8pt" 
        CellPadding="15" 
        CellSpacing="0" 
        Runat="server"/>-->
    <script src="/Content/MyScript/MyModifyUser.js"></script>
</asp:Content>
