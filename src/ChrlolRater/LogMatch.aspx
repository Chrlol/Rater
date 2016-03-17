<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LogMatch.aspx.cs" Inherits="ChrlolRater.LogMatch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Log Match</h1>
    <h2>Player versus Player</h2>
    <table>
        <tr>
            <td>Player</td>
            <td>Score</td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="Player1DropDown" runat="server" DataSourceID="PlayerNames" DataTextField="Name" DataValueField="Name"></asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="Player1ScoreBox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="Player2DropDown" runat="server" DataSourceID="PlayerNames" DataTextField="Name" DataValueField="Name"></asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="Player2ScoreBox" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <asp:Button ID="PlayerMatchSubmitButton" runat="server" Text="Submit Player Match" OnClick="PlayerMatchSubmitButton_Click" />
    <asp:LinqDataSource ID="PlayerNames" runat="server" ContextTypeName="Data.ChrlolRaterContext" EntityTypeName="" Select="new (Name)" TableName="Players">
    </asp:LinqDataSource>
    <asp:LinqDataSource ID="TeamNames" runat="server" ContextTypeName="Data.ChrlolRaterContext" EntityTypeName="" Select="new (Name)" TableName="Teams">
    </asp:LinqDataSource>
    <h2>Team versus Team</h2>
    <table>
        <tr>
            <td>Team</td>
            <td>Score</td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList AutoPostBack="True" ID="Team1DropDown" runat="server" DataSourceID="TeamNames" DataTextField="Name" DataValueField="Name" OnSelectedIndexChanged="Team1DropDown_OnSelectedIndexChanged"></asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="Team1Scorebox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList AutoPostBack="True" ID="Team2DropDown" runat="server" DataSourceID="TeamNames" DataTextField="Name" DataValueField="Name" OnSelectedIndexChanged="Team2DropDown_OnSelectedIndexChanged"></asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="Team2Scorebox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                
            </td>
        </tr>
    </table>
    <asp:Button ID="TeamMatchSubmitButton" runat="server" Text="Submit Team Match" OnClick="TeamMatchSubmitButton_Click" />
</asp:Content>
