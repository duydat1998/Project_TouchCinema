<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MemberLayout.Master" AutoEventWireup="true" CodeBehind="TouchCinema.aspx.cs" Inherits="Project_TouchCinema.MemberWorkspace" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" runat="server">
    <link href="../Css_File/StyleSheet.css" rel="stylesheet" />
    <div>
        <%-- Phần search movie --%>
        <div>
            <div id="search_mess">Do you want to find a movie?</div>            
            <div id="search_form">
                <asp:TextBox runat="server" ID="txtSearchValue" Width="300px" placeholder="Type the movie you want to search" CssClass="textbox"/>
                <asp:Button runat="server" ID="btnSeacrh" Text="Search" CssClass="button" OnClick="btnSeacrh_Click"/>                
            </div>
        </div>
        
       
        <%-- Phần show một chút thông tin phim mới ra --%>
        <div class="movie_info" runat="server">        
            <hr />
            <asp:Repeater runat="server" ID="MovieList" >
                <HeaderTemplate>
                    <b>Newest Movies</b>                      
                    <table>                        
                        <tr>                        
                </HeaderTemplate>
                <ItemTemplate>                    
                            <td>
                                <a href="MemberRegister.aspx"><img src="<%# Eval("poster")%>" style="width: 100%;"/></a>
                                <asp:Label runat="server" Text='<%# Eval("movieTitle") %>' style="text-align:center;"/>
                            </td>
                </ItemTemplate>
                <FooterTemplate>
                        </tr>
                    </table>                    
                </FooterTemplate>
            </asp:Repeater>            
            <hr />
        </div>        

        <%-- Phần show promotions --%>
        <div>
            <div class="banner">
            </div>
        </div>
    </div>
</asp:Content>
