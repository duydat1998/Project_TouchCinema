<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MemberLayout.Master" AutoEventWireup="true" CodeBehind="MovieDetailPage.aspx.cs" Inherits="Project_TouchCinema.GuestAndMember.MovieDetailPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" runat="server">
    <link href="../Css_File/StyleSheet.css" rel="stylesheet" />
    <div>
        <div id="search_bar">
            <div id="search_mess">Is this not the movie you want to see? Do you want to find other movies ?</div>            
            <div id="search_form">
                <asp:TextBox runat="server" ID="txtSearchValue" Width="300px" placeholder="Type the movie you want to search" CssClass="textbox"/>
                <asp:Button runat="server" ID="btnSeacrh" Text="Search" CssClass="button" OnClick="btnSeacrh_Click"/>                
            </div>
        </div>        
        <div>
            <asp:FormView runat="server" ID="MovieDataForm" CssClass="movie_data_form">
                <ItemTemplate>
                    <table border="1">
                        <tr>
                            <td rowspan="2">
                                <img src="<%# Eval("Poster")%>"/>
                            </td>
                            <td>
                                <b><%# Eval("MovieTitle")%></b>
                            </td>
                        </tr>
                        <tr>                            
                            <td>
                                Genre: <%# Eval("Genre")%>
                                Rating: <%# Eval("Rating")%>    Length: <%# Eval("Length")%> mins
                                Producder: <%# Eval("Producer")%>
                                                                
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:FormView>
            <asp:Label runat="server" ID="MovieDataEmpty" CssClass="movie_data_mess">
                <h1 id="empty_label">
                    There is something wrong! We are sorry for this inconvience!!
                </h1>
            </asp:Label>            
        </div>
    </div>    
</asp:Content>
