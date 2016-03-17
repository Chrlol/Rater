<%@ Page Title="Create Player" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreatePlayer.aspx.cs" Inherits="ChrlolRater.CreatePlayer" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Create Player</h2>
    <asp:Label ID="Failure" Visible="False" BorderStyle="Solid" BorderColor="Red" runat="server"></asp:Label>
    <p class="DefaultStyle">Player Name:
        <asp:TextBox ID="PlayerNameText" runat="server"></asp:TextBox>
        <asp:Button CssClass="GenButton" ID="CreatePlayerButton" Text="Create" runat="server" OnClick="CreatePlayerButton_Click" />
    </p>
    <asp:Label ID="Success" Visible="False" BorderStyle="Solid" BorderColor="Green" runat="server"></asp:Label>
</asp:Content>
