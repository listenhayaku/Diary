<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ObjectList_Partial.ascx.cs" Inherits="Diary.ObjectList_Partial" %>

<table>
    <thead>
        <tr>
            <td colspan="3">物件清單</td>
        </tr>
    </thead>
    <tbody>
        <%foreach(var item in listObjectData) {%>
            <tr>
                <td rowspan="9"><%=item.Name %></td>
                <td>Id</td>
                <td><%=item.Id %></td>
            </tr>
            <tr>
                <td>OwnerId</td>
                <td><%=item.OwnerId %></td>
            </tr>
            <tr>
                <td>OwnerName</td>
                <td><%=item.OwnerName %></td>
            </tr>
            <tr>
                <td>Datetime</td>
                <td><%=item.Datetime %></td>
            </tr>
            <tr>
                <td>Name</td>
                <td><%=item.Name %></td>
            </tr>
            <tr>
                <td>概述</td>
                <td></td>
            </tr>
            <%foreach(KeyValuePair<string,string> key in item.Description){ %>
                <tr>
                    <td><%=key.Key %></td>
                    <td><%=key.Value %></td>
                </tr>
            <%}%>
        <%} %>
    </tbody>
</table>