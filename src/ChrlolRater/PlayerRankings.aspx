<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PlayerRankings.aspx.cs" Inherits="ChrlolRater.PlayerRankings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Player Rankings</h1>
    <asp:GridView ID="Rankings" runat="server" AutoGenerateColumns="False" DataSourceID="LinqDataSource1">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="Id" HeaderText="Name" SortExpression="Name" 
    DataNavigateUrlFormatString="PlayerPage.aspx?ID={0}" DataTextField="Name"/>
            <asp:BoundField DataField="Score.Rating" HeaderText="Rating" ReadOnly="True" SortExpression="Rating"/>
            <asp:BoundField DataField="Score.Wins" HeaderText="Wins" ReadOnly="True" SortExpression="Wins"/>
            <asp:BoundField DataField="Score.Losses" HeaderText="Losses" ReadOnly="True" SortExpression="Losses"/>
        </Columns>
    </asp:GridView>
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="Data.ChrlolRaterContext" EntityTypeName="" Select="new (Name, Score, Id)" TableName="Players">
    </asp:LinqDataSource>
</asp:Content>
