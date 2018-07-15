<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MemberLayout.Master" AutoEventWireup="true" CodeBehind="BookTicketPage.aspx.cs" Inherits="Project_TouchCinema.GuestAndMember.BookTicketPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" runat="server">
    <link href="../Css_File/StyleSheet.css" rel="stylesheet" />
    <div id="book_ticket_content">
        <div id="detail"></div>
        <div id="room">
            <div id="room_select">
                <asp:DropDownList runat="server" ID="RoomList"></asp:DropDownList>
            </div>
        </div>
    </div>
</asp:Content>
