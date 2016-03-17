<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TeamRankings.aspx.cs" Inherits="ChrlolRater.TeamRankings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Team Rankings</h1>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="LinqDataSource1">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="Id" HeaderText="Name" SortExpression="Name" DataNavigateUrlFormatString="TeamPage.aspx?ID={0}" DataTextField="Name"/>
            <asp:BoundField DataField="Score.Rating" HeaderText="Rating" ReadOnly="True" SortExpression="Rating"/>
            <asp:BoundField DataField="Score.Wins" HeaderText="Wins" ReadOnly="True" SortExpression="Wins"/>
            <asp:BoundField DataField="Score.Losses" HeaderText="Losses" ReadOnly="True" SortExpression="Losses"/>
        </Columns>
    </asp:GridView>
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="Data.ChrlolRaterContext" EntityTypeName="" Select="new (Name, Score, Id)" TableName="Teams">
    </asp:LinqDataSource>


</asp:Content>
