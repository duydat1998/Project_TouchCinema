<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MemberLayout.Master" AutoEventWireup="true" CodeBehind="PromotionPage.aspx.cs" Inherits="Project_TouchCinema.GuestAndMember.PromotionPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" runat="server">
    <link href="../Css_File/StyleSheet.css" rel="stylesheet" />
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
</asp:Content>
