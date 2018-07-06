<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MemberLayout.Master" AutoEventWireup="true" CodeBehind="MovieDetailPage.aspx.cs" Inherits="Project_TouchCinema.GuestAndMember.MovieDetailPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" runat="server">
    <link href="../Css_File/StyleSheet.css" rel="stylesheet" />
    <div>
        <div id="search_bar">
            <div id="search_mess">
                Is this not the movie you want to see? <br />
                Do you want to find other movies ?
            </div>            
            <div id="search_form">
                <asp:TextBox runat="server" ID="txtSearchValue" Width="300px" placeholder="Type the movie you want to search" CssClass="textbox"/>
                <asp:Button runat="server" ID="btnSeacrh" Text="Search" CssClass="button" OnClick="btnSeacrh_Click"/>                
            </div>
        </div>        
        <div>
            <asp:FormView runat="server" ID="MovieDataForm" CssClass="movie_data_form">
                <ItemTemplate>
                    <div id="movie_data_poster">
                        <img src="<%# Eval("Poster")%>"/>
                    </div>
                    <div id="movie_data_description">
                        <div id="movie_title">
                            <b><%# Eval("MovieTitle")%></b>
                        </div>
                        <div id="movie_detail">                            
                            Genre: <br />
                            <%# Eval("Genre")%> 
                            <br />
                            Rating: <%# Eval("Rating")%>    Length: <%# Eval("Length")%> mins <br />
                            Producder: <%# Eval("Producer")%>                                
                        </div>
                    </div>                    
                </ItemTemplate>                
            </asp:FormView>            
            <asp:Label runat="server" ID="MovieDataEmpty" Visible="false" CssClass="movie_data_mess">
                <h1 id="empty_label">
                    There is something wrong! We are sorry for this inconvience!!
                </h1>
            </asp:Label>
            <div id="movie_same_genre">
                <div class="panel_upper">
                    <asp:Label runat="server" ID="MovieSameGenre" Text="Movies also have '' genre"/>
                </div>
                <asp:Repeater runat="server" ID="MovieSameGenreList">
                    <HeaderTemplate>                                         
                        <table class="reference_table">                        
                            <tr>                        
                    </HeaderTemplate>
                    <ItemTemplate>                    
                                <td>
                                    <a href="MovieDetailPage.aspx?movieTitle=<%# Eval("movieTitle")%>">
                                        <img src="<%# Eval("poster")%>"/>
                                    </a>
                                    <br />
                                    <asp:Label runat="server" style="text-align:center;">
                                        <b><%# Eval("movieTitle") %></b>
                                    </asp:Label>
                                </td>
                    </ItemTemplate>                
                    <FooterTemplate>
                            </tr>
                        </table>                    
                    </FooterTemplate>
                </asp:Repeater>        
                <div class="panel_lower">
                        
                </div>
            </div>
           
            <div id="movie_same_producer">
                <div class="panel_upper">
                    <asp:Label runat="server" ID="MovieSameProducer" Text="Movies also have been made form ''"/>
                </div>
                <asp:Repeater runat="server" ID="MovieSameProducerList" >
                    <HeaderTemplate>                    
                        <table class="reference_table">                        
                            <tr>                        
                    </HeaderTemplate>
                    <ItemTemplate>                    
                                <td>
                                    <a href="MovieDetailPage.aspx?movieTitle=<%# Eval("movieTitle")%>">
                                        <img src="<%# Eval("poster")%>"/>
                                    </a>
                                    <br />
                                    <asp:Label runat="server" style="text-align:center;">
                                        <b><%# Eval("movieTitle") %></b>
                                    </asp:Label>
                                </td>
                    </ItemTemplate>                
                    <FooterTemplate>
                            </tr>
                        </table>                    
                    </FooterTemplate>
                </asp:Repeater>            
                <div class="panel_lower">
                    
                </div>
            </div>
        </div>
    </div>    
</asp:Content>
