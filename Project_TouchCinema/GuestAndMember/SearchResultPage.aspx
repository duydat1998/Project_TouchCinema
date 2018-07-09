<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MemberLayout.Master" AutoEventWireup="true" CodeBehind="SearchResultPage.aspx.cs" Inherits="Project_TouchCinema.GuestAndMember.SearchResultPage" %>
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
        <div class="panel_upper">           
            <asp:Label runat="server" ID="ResultFor" Text="" Visible="true" CssClass="search_result_mess"/>
        </div>     
        <div id="search_result">                        
            <asp:Repeater runat="server" ID="ResultDetail">
                <HeaderTemplate>                    
                </HeaderTemplate>
                <ItemTemplate>                              
                    <div class="movie_panel">
                        <a href="MovieDetailPage.aspx?movieTitle=<%# Eval("MovieTitle")%>">
                            <img src="<%# Eval("poster")%>" style="width: 100%;"/>
                        </a>
                        <br /><%# Eval("MovieTitle") %>
                        <br /><%# Eval("Length") + " phút" %>                                                               
                    </div>                    
                </ItemTemplate>
                <FooterTemplate>                        
                </FooterTemplate>
            </asp:Repeater>
            <asp:Label runat="server" ID="ResultEmpty" Visible="false" CssClass="search_result_mess">                
                <h1 id="empty_label">Sorry! No Movie is Matched!!!!!</h1>
            </asp:Label>                         
        </div>
        <div class="panel_lower">
                        
        </div>
        <hr />
    </div>        
</asp:Content>
