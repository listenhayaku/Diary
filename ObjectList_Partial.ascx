﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ObjectList_Partial.ascx.cs" Inherits="Diary.ObjectList_Partial" %>


<div id="ObjectList" class="horizontal_arrangement_container">
    <div id="ObjectList_Partial_ArrowIcon" class="ObjectList_Partial_ArrowIcon Shrinked" onclick="javascript:SwitchBoxStatus()">
    </div>
    <div id="ObjectListBox" class="ObjectListBox Shrinked">
        <table>
            <thead>
                <tr>
                    <td colspan="2">物件清單</td>
                </tr>
            </thead>
            <tbody>
                <%foreach(var item in listObjectData) {%>
                    <tr class="ItemName">
                        <td colspan="2"><%=item.Name%>
                            <div>

                            </div>
                        </td>
                    </tr>
                    <%foreach (KeyValuePair<string, string> key in item.Description){%>
                        <tr class="Shrinked">
                            <td>
                                <%=key.Key %>
                            </td>
                            <td>
                                <%=key.Value %>
                            </td>
                        </tr>
                    <%} %>

                <%} %>
                <!--<%foreach(var item in listObjectData) {%>
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
                <%} %>-->
            </tbody>
        </table>
    </div>
</div>


