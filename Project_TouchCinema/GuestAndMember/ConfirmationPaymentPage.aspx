<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MemberLayout.Master" AutoEventWireup="true" CodeBehind="ConfirmationPaymentPage.aspx.cs" Inherits="Project_TouchCinema.GuestAndMember.ConfirmationPaymentPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" runat="server">
    <link href="../Css_File/StyleSheet.css" rel="stylesheet" />    
    <div class="confirm_payment_content">
        <div class="panel_upper">
            Ticket(s) Booking Confirmation
        </div>     
        <div class="confirm_detail">
            <h2>Please confirm these information before you submit your payment</h2>
            <table>
                <tr>
                    <td>Username:</td>
                    <td><asp:Label runat="server" ID="lblUsername"/></td>
                </tr>
                <tr>
                    <td>Phone:</td>
                    <td><asp:Label runat="server" ID="lblPhone"/></td>
                </tr>
                <tr>
                    <td>Email:</td>
                    <td><asp:Label runat="server" ID="lblEmail"/></td>
                </tr>
                <tr>
                    <td>Movie:</td>
                    <td><asp:Label runat="server" ID="lblMovie" /></td>
                </tr>
                <tr>
                    <td>Schedule:</td>
                    <td><asp:Label runat="server" ID="lblSchedule" /></td>
                </tr>
                <tr>
                    <td>Total Booked Seat:</td>
                    <td><asp:Label runat="server" ID="lblBookedSeat" /></td>
                </tr>
                <tr>
                    <td>Booked Seats:</td>
                    <td><asp:Label runat="server" ID="lblBookedSeatList" /></td>
                </tr>
                <tr>
                    <td>Ticket's Price:</td>
                    <td><asp:Label runat="server" ID="lblTicketPrice" /></td>
                </tr>
                <tr>
                    <td>Total Price:</td>
                    <td><asp:Label runat="server" ID="lblTotalPrice" /></td>
                </tr>
            </table>
            <div></div>
        </div>        
    </div>
</asp:Content>
