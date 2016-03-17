<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateTeam.aspx.cs" Inherits="ChrlolRater.CreateTeam" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Create Team</h1>
    <h2>Team Name:</h2>
    <asp:TextBox ID="TeamNameBox" runat="server"></asp:TextBox>
    
    <asp:Label ID="TeamNameValidation" runat="server" Text="" ForeColor="Red"></asp:Label>
    
    <table>
        <tr>
            <th>
                <h3>Available Players</h3>
            </th>
            <th>
            </th>
            <th>
                <h3>Selected Players</h3>
            </th>
        </tr>
        <tr>
            <td rowspan="2">
                <asp:ListBox ID="AvailablePlayers" runat="server" DataSourceID="PlayerNames" DataTextField="Name" DataValueField="Name" Height="200" ItemType="Data.Player" Width="200"></asp:ListBox>
            </td>
            <td>
                <asp:Button ID="AddPlayer" Text="-->" runat="server" OnClick="AddPlayer_Click"/>
            </td>
            <td rowspan="2">
                <asp:ListBox ID="SelectedPlayers" Width="200" Height="200" runat="server" DataTextField="Name" DataValueField="Name"></asp:ListBox>

            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="RemovePlayer" Text="<--" runat="server" OnClick="RemovePlayer_Click"/>
            </td>
        </tr>

    </table>
    <asp:Label ID="TeamValidation" runat="server" Text="" ForeColor="Red"></asp:Label>
    <br />
    <asp:Button ID="CreateTeamButton" runat="server" Text="Create Team" OnClick="CreateTeamButton_Click" />
    <br />
    <asp:Label ID="TeamCreationSuccess" runat="server" Text="" ForeColor="Green"></asp:Label>
    <asp:LinqDataSource ID="PlayerNames" runat="server" ContextTypeName="Data.ChrlolRaterContext" EntityTypeName="" Select="new (Name)" TableName="Players">
    </asp:LinqDataSource>
</asp:Content>
