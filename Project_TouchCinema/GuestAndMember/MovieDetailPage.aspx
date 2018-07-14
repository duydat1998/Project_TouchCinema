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
                            <br />                            
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
                <div class="movie_reference_content">
                    <asp:Repeater runat="server" ID="MovieSameGenreList">
                        <HeaderTemplate>                                                                     
                        </HeaderTemplate>
                        <ItemTemplate>                    
                            <div class="movie_panel">
                                <a href="MovieDetailPage.aspx?movieTitle=<%# Eval("MovieTitle")%>">
                                    <img src="<%# Eval("poster")%>" style="width: 100%; height: 200px;"/>
                                </a>
                                <br /><%# Eval("MovieTitle") %>
                                <br /><%# Eval("Length") + " phút" %>                                                               
                            </div>
                        </ItemTemplate>                
                        <FooterTemplate>                                               
                        </FooterTemplate>
                    </asp:Repeater>                        
                </div>  
                <br />
                <a href="MovieListWithTag.aspx?tag1=" class="show_more_link">Show more </a>
                <br />
                <div class="panel_lower">
                        
                </div>
            </div>
           
            <div id="movie_same_producer">
                <div class="panel_upper">
                    <asp:Label runat="server" ID="MovieSameProducer" Text="Movies also have been made form ''"/>
                </div>
                <div class="movie_reference_content">
                    <asp:Repeater runat="server" ID="MovieSameProducerList" >
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
                <br />
                <a href="MovieListWithTag.aspx?tag1=" class="show_more_link">Show more </a>
                <br />
                <div class="panel_lower">
                    
                </div>
            </div>
        </div>
    </div>    
</asp:Content>
