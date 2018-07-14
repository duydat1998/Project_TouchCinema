<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MemberLayout.Master" AutoEventWireup="true" CodeBehind="MovieListWithTag.aspx.cs" Inherits="Project_TouchCinema.GuestAndMember.MovieListWithTag" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" runat="server">
    <link href="../Css_File/StyleSheet.css" rel="stylesheet" />
    <div id="movie_tag_content">
        <div class="panel_upper">
            <asp:Label runat="server" ID="MoviesTag" Text="Movies also have '' genre"/>
        </div>
        <asp:Repeater runat="server" ID="TaggedMovieList">
            <HeaderTemplate>                    
            </HeaderTemplate>
            <ItemTemplate>                              
                <div class="movie_panel">
                    <a href="MovieDetailPage.aspx?movieTitle=<%# Eval("MovieTitle")%>">
                        <img src="<%# Eval("poster")%>" style="width: 100%;  height: 200px;"/>
                    </a>
                    <br /><%# Eval("MovieTitle") %>
                    <br /><%# Eval("Length") + " phút" %>                                                               
                </div>                    
            </ItemTemplate>
            <FooterTemplate>                        
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
