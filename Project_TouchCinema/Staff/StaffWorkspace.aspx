<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/StaffLayout.Master" AutoEventWireup="true" CodeBehind="StaffWorkspace.aspx.cs" Inherits="Project_TouchCinema.StaffWorkspace" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 168px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" runat="server">
    <h1>Check Ticket code:</h1>
    <table style="width: 586px">
        <tr>
            <td class="auto-style1">Booking Code</td>
            <td colspan="2"><asp:TextBox ID="txtBookingCode" runat="server" CssClass="textbox" Width="273px" OnTextChanged="txtBookingCode_TextChanged"></asp:TextBox></td>
            <td><asp:Button ID="btnCheck" runat="server" Text="Check"  Width="96px" CssClass="button" OnClick="btnCheck_Click" /></td>
        </tr>
    </table>
    <asp:Label ID="invalidCode" runat="server" Text="The Booking code is invalid! Please enter another one!" CssClass="error_message"></asp:Label>
    <div runat="server" id="orderDetail"> 
        <h2>Order <asp:Label ID="lblOrderID" runat="server" Text=""></asp:Label></h2>
        <table>
            <tr>
                <td>Movie:</td>
                <td>
                <asp:Label ID="lbMovieName" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Date:</td>
                <td>
                <asp:Label ID="lbDate" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Time:</td>
                <td>
                <asp:Label ID="lbTime" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Room:</td>
                <td>
                <asp:Label ID="lbRoom" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Seats:</td>
                <td>
                <asp:Label ID="lbSeat" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                
                <td>Total Price:</td>
                <td>
                <asp:Label ID="lbPrice" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnCheckOut" runat="server" Text="Check out" OnClick="btnCheckOut_Click" /></td>
            </tr>
        </table>
    </div>
</asp:Content>
