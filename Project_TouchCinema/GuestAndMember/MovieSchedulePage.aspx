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
                            <img src="<%# Eval("Poster")%>" style="width: 100%;height: 90%;"/>
                            <br />
                            <%# Eval("MovieTitle") %>
                        </div>
                        <div class="movie_schedule_list">
                            <asp:Repeater runat="server" ID="MovieSchedule" OnDataBinding="MovieSchedule_DataBinding">
                                <ItemTemplate>
                                    <a href="UnderConstructionsPage.aspx">
                                        <div class="movie_schedule_details">
                                            <%# Eval("ScheduleDate") %> at Room <%# Eval("RoomID") %>
                                        </div>
                                    </a>                                                                        
                                </ItemTemplate>
<<<<<<< HEAD
                     </asp:Repeater>
=======
                            </asp:Repeater>
>>>>>>> 624628b80180af35df883592ca04636c6a4c5c16
                        </div>
                    </div>                    
                </ItemTemplate>
            </asp:Repeater>                   
        </div>        
    </div>                    
</asp:Content>
