<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RemovePlayerFromTeam.aspx.cs" Inherits="ChrlolRater.RemovePlayerFromTeam" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Error" runat="server" Text=""></asp:Label>
    <h1>Er du sikker på du vil fjerne <%=Player.Name%> fra holdet <%=Team.Name%>?</h1>
    <asp:Button runat="server" Text="Yes" ID="YesButton" OnClick="YesButton_Click"/>
    <asp:Button runat="server" Text="No" ID="NoButton" OnClick="NoButton_Click"/>
</asp:Content>
