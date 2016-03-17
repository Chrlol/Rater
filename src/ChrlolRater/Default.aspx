<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChrlolRater.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Rater</h1>
        <p class="lead">Compete against others playing games and log the scores and Rater will log your performance give you a rating.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Best Player</h2>
            <p>
                Best Player will be shown here
            </p>
            <p>
                <a class="btn btn-default" href="/PlayerRankings.aspx">Player Rankings &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Best Team</h2>
            <p>
                Best Team will be shown here.
            </p>
            <p>
                <a class="btn btn-default" href="/TeamRankings.aspx">Team Rankings &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Random Stats</h2>
            <p>
                Most Wins:<br/>
                Highest Ratings:<br/>
                Best KD:<br/>
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
