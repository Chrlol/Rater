<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PlayerPage.aspx.cs" Inherits="ChrlolRater.PlayerPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%=Player.Name %></h1>
    <table>
        <tr>
            <th>Rating</th>
            <td><%=Player.Score.Rating %></td>
        </tr>
        <tr>
            <th>Wins</th>
            <td><%=Player.Score.Wins %></td>
        </tr>
        <tr>
            <th>Losses</th>
            <td><%=Player.Score.Losses %></td>
        </tr>
    </table>
    <a href="/Actions/JoinTeam.aspx?PlayerID=<%= Player.Id %>">Join a Team</a>
    
    <asp:Repeater ID="HistoryRepeater" runat="server">
        <HeaderTemplate><h3>Match History</h3></HeaderTemplate>
    </asp:Repeater>

    <asp:Repeater ID="TeamsRepeater" runat="server">
        <HeaderTemplate>
            <h3>Teams:</h3>
        </HeaderTemplate>
        <ItemTemplate>
            <h4><%# Eval("Name") %></h4>
            <b>Rating:</b><%# Eval("Score.Rating") %><br/>
            <b>Wins:</b><%# Eval("Score.Wins") %><br/>
            <b>Losses:</b><%# Eval("Score.Losses") %><br/>
            <a href="/Actions/LeaveTeam.aspx?TeamID=<%# Eval("Id") %>&PlayerID=<%= Player.Id %>">Leave Team</a>
        </ItemTemplate>
    </asp:Repeater>
    
</asp:Content>

