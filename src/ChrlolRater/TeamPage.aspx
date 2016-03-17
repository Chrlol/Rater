<%@ Page EnableEventValidation="false" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TeamPage.aspx.cs" Inherits="ChrlolRater.TeamPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <h1><%=Team.Name %></h1>
    <table>
        <tr>
            <th>Rating</th>
            <td><%=Team.Score.Rating %></td>
        </tr>
        <tr>
            <th>Wins</th>
            <td><%=Team.Score.Wins %></td>
        </tr>
        <tr>
            <th>Losses</th>
            <td><%=Team.Score.Losses %></td>
        </tr>
    </table>
    <a href="/Actions/AddPlayerToTeam.aspx?TeamID=<%=Team.Id%>">Add Player to Team</a>
    
    <asp:Repeater ID="HistoryRepeater" runat="server">
        <HeaderTemplate><h3>Match History:</h3></HeaderTemplate>
    </asp:Repeater>

    <asp:Repeater ID="MembersRepeater" runat="server">
        <HeaderTemplate>
            <h3>Members:</h3>
        </HeaderTemplate>
        <ItemTemplate>
            <h4><%# Eval("Name") %></h4>
            <b>Rating:</b><%# Eval("Score.Rating") %><br/><b>Wins:</b><%# Eval("Score.Wins") %><br/><b>Losses:</b><%# Eval("Score.Losses") %><br/>
            <a href="/Actions/RemovePlayerFromTeam.aspx?PlayerID=<%# Eval("Id") %>&TeamID=<%= Team.Id %>">Remove Player</a>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
