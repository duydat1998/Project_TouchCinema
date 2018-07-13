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
                    <div class="movie_schedule_info" style="margin-top: 10px;margin-bottom: 10px;">
                        <div class="movie_schedule_img" style="text-align: center; font-weight: 900">
                            <img src="<%# Eval("Poster")%>" style="width: 100%;height: 90%;"/>
                            <br />
                            <%# Eval("MovieTitle") %>
                        </div>
                        <div style="float: left;width: 50%;">
                            <asp:Repeater runat="server" ID="MovieSchedule" OnDataBinding="MovieSchedule_DataBinding">
                                <ItemTemplate>
                                    <div style="text-align: right;">
                                        <%# Eval("ScheduleDate") %>
                                    </div>                                    
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>                    
                </ItemTemplate>
            </asp:Repeater>                   
        </div>        
    </div>                    
</asp:Content>
