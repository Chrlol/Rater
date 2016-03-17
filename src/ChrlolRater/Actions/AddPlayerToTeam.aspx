<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="AddPlayerToTeam.aspx.cs" Inherits="ChrlolRater.Actions.AddPlayerToTeam" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    <h2>Available Players</h2>
    <asp:ListBox ID="AvailablePlayers" runat="server" Height="200" Width="200"></asp:ListBox>
    <br />
    <asp:Button ID="AddPlayerToTeamButton" runat="server" Text="Add Player To Team" OnClick="AddPlayerToTeam_Click"/>
</asp:Content>