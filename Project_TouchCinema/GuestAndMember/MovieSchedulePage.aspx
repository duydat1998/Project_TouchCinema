<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MemberLayout.Master" AutoEventWireup="true" CodeBehind="MovieSchedulePage.aspx.cs" Inherits="Project_TouchCinema.GuestAndMember.MovieSchedulePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" runat="server">
    <link href="../Css_File/StyleSheet.css" rel="stylesheet" />
    <div id="schedule_content">
        <div class="panel_upper">
            Movies' Schedule
        </div>
        <div id="movie_schedule_content">
            <asp:Repeater runat="server" ID="MovieList">
                <ItemTemplate>
                    <div class="movie_schedule_info">
                        <div class="movie_schedule_img">
                            <img src="<%# Eval("Poster")%>"/>
                        </div>
                    </div>
                    <div class="movie_schedule_detail">
                        
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>                    
</asp:Content>
