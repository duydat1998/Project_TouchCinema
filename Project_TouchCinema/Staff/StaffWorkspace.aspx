<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/StaffLayout.Master" AutoEventWireup="true" CodeBehind="StaffWorkspace.aspx.cs" Inherits="Project_TouchCinema.StaffWorkspace" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 168px;
        }
        .auto-style2 {
            width: 406px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" runat="server">
    <h1 class="title">Check Ticket code:</h1>
    <table style="width: 586px">
        <tr>
            <td class="auto-style1">Booking Code</td>
            <td colspan="2"><asp:TextBox ID="txtBookingCode" runat="server" ClientIDMode="Static" CssClass="textbox" Width="273px" onkeypress="HideInvalidMessage()"></asp:TextBox></td>
            <td><asp:Button OnClientClick="return ValidateBookingCode()" ID="btnCheck" runat="server" Text="Check"  Width="96px" CssClass="button" OnClick="btnCheck_Click" /></td>
        </tr>
    </table>
    <p id="incorrectCode" class="error_message">A correct Booking code must be 10-character long! Please enter another one!</p>
    <asp:Label ID="invalidCode" runat="server" Text="The Booking code is invalid! Please enter another one!" CssClass="error_message"></asp:Label><br />
    <div runat="server" id="orderDetail"> 
        <h2 class="title">Order: <asp:Label ID="lblOrderID" runat="server" Text=""></asp:Label></h2>
        <table>
            <tr>
                <td>Movie:</td>
                <td class="auto-style2">
                <asp:Label ID="lbMovieName" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Date:</td>
                <td class="auto-style2">
                <asp:Label ID="lbDate" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Time:</td>
                <td class="auto-style2">
                <asp:Label ID="lbTime" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Room:</td>
                <td class="auto-style2">
                <asp:Label ID="lbRoom" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Seats:</td>
                <td class="auto-style2">
                <asp:Label ID="lbSeat" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                
                <td>Total Price:</td>
                <td class="auto-style2">
                <asp:Label ID="lbPrice" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td></td>
                <td class="auto-style2"><asp:Button ID="btnCheckOut" runat="server" Text="Check out" OnClick="btnCheckOut_Click" OnClientClick="return confirm('Do you really want to checkout?')"  CssClass="button" /></td>
            </tr>
        </table>
    </div>
</asp:Content>
