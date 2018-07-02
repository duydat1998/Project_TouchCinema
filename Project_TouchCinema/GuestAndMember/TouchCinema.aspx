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
                <asp:TextBox runat="server" ID="txtSearchValue" Width="300px"></asp:TextBox>
                <asp:Button runat="server" ID="btnSeacrh" Text="Search" CssClass="button" OnClick="btnSeacrh_Click"/>                
            </div>
        </div>
        
       
        <%-- Phần show một chút thông tin phim mới ra --%>
        <div class="movie_info" runat="server">
           <%-- 
               
            --%>
            <asp:Repeater runat="server" ID="for_each_movie_list" >

            </asp:Repeater>
            <hr />
            <h2>AAA</h2>
            <img src="../Image/Poster/jurassicPark2.jpg"/>
            <div class="description">
                AAAAAA                
            </div>            
        </div>        

        <%-- Phần show promotions --%>
        <div>
            <div class="banner"></div>
        </div>
    </div>
</asp:Content>
