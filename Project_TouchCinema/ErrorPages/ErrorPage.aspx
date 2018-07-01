<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MemberLayout.Master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="Project_TouchCinema.ErrorPages.ErrorPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" runat="server">
    <h1>Error occurs!</h1>
    <h1>There are too many connections to the server. Sorry for this inconvenient!</h1>
    <h2>
        Click <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/GuestAndMember/TouchCinema.aspx" Text="here" ForeColor="#ff0066" ></asp:HyperLink> to back to Home Page!
    </h2>
</asp:Content>
