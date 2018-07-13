<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MemberLayout.Master" AutoEventWireup="true" CodeBehind="TouchCinema.aspx.cs" Inherits="Project_TouchCinema.MemberWorkspace" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" runat="server">
    <link href="../Css_File/StyleSheet.css" rel="stylesheet" />
    <div>
        <%-- Phần search movie --%>
        <div id="search_bar">
            <div id="search_mess">Do you want to find a movie?</div>            
            <div id="search_form">
                <asp:TextBox runat="server" ID="txtSearchValue" Width="300px" placeholder="Type the movie you want to search" CssClass="textbox"/>
                <asp:Button runat="server" ID="btnSeacrh" Text="Search" CssClass="button" OnClick="btnSeacrh_Click"/>                
            </div>
        </div>
        <hr />              
        <%-- Phần show một chút thông tin phim mới ra --%>
        <div class="movie_lastest_info" runat="server">                    
            <asp:Repeater runat="server" ID="LastestMovieList" >
                <HeaderTemplate>
                    <div class="panel_upper">
                        Lastest Added Movies
                    </div>                                          
                </HeaderTemplate>
                <ItemTemplate>                                                
                    <div class="movie_panel">
                        <a href="MovieDetailPage.aspx?movieTitle=<%# Eval("MovieTitle")%>">
                            <img src="<%# Eval("poster")%>" style="width: 100%;  height: 200px;"/>
                        </a>
                        <br /><%# Eval("MovieTitle") %>
                        <br /><%# Eval("Length") + " phút" %>    
                        <br />Added on <%# Eval("StartDate") %>
                    </div>
                </ItemTemplate>                                
            </asp:Repeater>                        
        </div>
        <hr />
        <div class="movie_rating_info" runat="server">                    
            <asp:Repeater runat="server" ID="MostRatingMovieList" >
                <HeaderTemplate>
                    <div class="panel_upper">
                        Most Rating Movies
                    </div>                                          
                </HeaderTemplate>
                <ItemTemplate>                                                
                    <div class="movie_panel">
                        <a href="MovieDetailPage.aspx?movieTitle=<%# Eval("MovieTitle")%>">
                            <img src="<%# Eval("poster")%>" style="width: 100%;  height: 200px;"/>
                        </a>
                        <br /><%# Eval("MovieTitle") %>
                        <br /><%# Eval("Length") + " phút" %>                                                               
                        <br />Rate: <%# Eval("Rating") %>
                    </div>
                </ItemTemplate>                                
            </asp:Repeater>            
        </div>
        <hr />
        <%-- Phần show promotions --%>
        <div>
            <div class="banner">
                <div class="panel_upper">
                        Currently Promotion
                </div>
                <div class="promotion_section">
                    <div class="promotion_banner">
                        <a href="UnderConstructionsPage.aspx">
                            <img src="../Image/Promotion/DongGia20k.jpg" />
                        </a>
                    </div>
                    <div class="promotion_banner">
                        <a href="UnderConstructionsPage.aspx">
                            <img src="../Image/Promotion/PhongPhiTieuSanQuaNhieu.jpg" />
                        </a>
                    </div>
                    <div class="promotion_banner">
                        <a href="UnderConstructionsPage.aspx">
                            <img src="../Image/Promotion/TickAndGetTiclet.jpg" />
                        </a>
                    </div>
                    <div class="promotion_banner">
                        <a href="UnderConstructionsPage.aspx">
                            <img src="../Image/Promotion/TuSachChoEm.jpg" />
                        </a>
                    </div>
                </div>                
            </div>
        </div>
    </div>
</asp:Content>
