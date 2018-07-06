<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MemberLayout.Master" AutoEventWireup="true" CodeBehind="PromotionPage.aspx.cs" Inherits="Project_TouchCinema.GuestAndMember.PromotionPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" runat="server">
    <link href="../Css_File/StyleSheet.css" rel="stylesheet" />
    <div id="promo_header">
        <asp:Label runat="server" ID="PromoHeader" Text="Currently Promotion"/>
    </div>
</asp:Content>
