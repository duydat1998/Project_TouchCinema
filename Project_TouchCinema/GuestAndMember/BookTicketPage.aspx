<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MemberLayout.Master" AutoEventWireup="true" CodeBehind="BookTicketPage.aspx.cs" Inherits="Project_TouchCinema.GuestAndMember.BookTicketPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" runat="server">
    <link href="../Css_File/StyleSheet.css" rel="stylesheet" />    
    <div id="book_ticket_content">
        <div class="panel_upper">
            Booking ticket(s)
        </div>                                          
        <div id="detail">
            <table>
                <tr>
                    <td>Movie:</td>
                    <td><asp:DropDownList runat="server" ID="dlMovieList" OnSelectedIndexChanged="dlMovieList_SelectedIndexChanged"
                        AutoPostBack="true" CssClass="book_ticket_drop_list" ></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>Schedule(Day & Hour):</td>
                    <td><asp:DropDownList runat="server" ID="dlScheduleList" OnSelectedIndexChanged="dlScheduleList_SelectedIndexChanged"
                        AutoPostBack="true" CssClass="book_ticket_drop_list"></asp:DropDownList>
                        <asp:DropDownList runat="server" ID="dlScheduleID" Visible="false"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Number of Tickets:</td>
                    <td><asp:DropDownList runat="server" ID="dlTicketNum" OnSelectedIndexChanged="dlTicketNum_SelectedIndexChanged"
                        AutoPostBack="true" CssClass="book_ticket_drop_list"></asp:DropDownList>
                        <asp:Label runat="server" ID="lblTicketNoti" Text="Can only choose from 1-10"/>
                    </td>
                </tr>
            </table> 
            <asp:Label runat="server" ID="TicketAmount" Text="Remaing selectable seats: --." CssClass="ticket_mess"/>
        </div>
        <div id="room">      
            <asp:Label runat="server" ID="roomTitle" CssClass="room_title"/>
            <div id="screen">S  C  R  E  E  N</div>
            <br />
            <br />
            <br />
            <br />            
            <div class="line">
                <h5 class="seat_line_name">Line A:</h5>
                <div class="seat_line">                    
                    <asp:Button runat="server" ID="btnA1" CssClass="seat_avail" Text="A1" OnClick="btnSeat_Click"/>
                    <asp:Button runat="server" ID="btnA2" CssClass="seat_avail" Text="A2" OnClick="btnSeat_Click"/>
                    <asp:Button runat="server" ID="btnA3" CssClass="seat_avail" Text="A3" OnClick="btnSeat_Click"/>
                    <asp:Button runat="server" ID="btnA4" CssClass="seat_avail" Text="A4" OnClick="btnSeat_Click"/>
                    <asp:Button runat="server" ID="btnA5" CssClass="seat_avail" Text="A5" OnClick="btnSeat_Click"/>
                    <asp:Button runat="server" ID="btnA6" CssClass="seat_avail" Text="A6" OnClick="btnSeat_Click"/>
                    <asp:Button runat="server" ID="btnA7" CssClass="seat_avail" Text="A7" OnClick="btnSeat_Click"/>
                    <asp:Button runat="server" ID="btnA8" CssClass="seat_avail" Text="A8" OnClick="btnSeat_Click"/>
                </div>               
            </div>
            <div class="line">
                <h5 class="seat_line_name">Line B:</h5>
                <div class="seat_line">
                    <asp:Button runat="server" ID="btnB1" CssClass="seat_avail" Text="B1" OnClick="btnSeat_Click"/>
                    <asp:Button runat="server" ID="btnB2" CssClass="seat_avail" Text="B2" OnClick="btnSeat_Click"/>
                    <asp:Button runat="server" ID="btnB3" CssClass="seat_avail" Text="B3" OnClick="btnSeat_Click"/>
                    <asp:Button runat="server" ID="btnB4" CssClass="seat_avail" Text="B4" OnClick="btnSeat_Click"/>
                    <asp:Button runat="server" ID="btnB5" CssClass="seat_avail" Text="B5" OnClick="btnSeat_Click"/>
                    <asp:Button runat="server" ID="btnB6" CssClass="seat_avail" Text="B6" OnClick="btnSeat_Click"/>
                    <asp:Button runat="server" ID="btnB7" CssClass="seat_avail" Text="B7" OnClick="btnSeat_Click"/>
                    <asp:Button runat="server" ID="btnB8" CssClass="seat_avail" Text="B8" OnClick="btnSeat_Click"/>
                </div>               
            </div>
            <div class="line">
                <h5 class="seat_line_name">Line C:</h5>
                <div class="seat_line">
                    <asp:Button runat="server" ID="btnC1" CssClass="seat_avail" Text="C1" OnClick="btnSeat_Click"/>
                    <asp:Button runat="server" ID="btnC2" CssClass="seat_avail" Text="C2" OnClick="btnSeat_Click"/>
                    <asp:Button runat="server" ID="btnC3" CssClass="seat_avail" Text="C3" OnClick="btnSeat_Click"/>
                    <asp:Button runat="server" ID="btnC4" CssClass="seat_avail" Text="C4" OnClick="btnSeat_Click"/>
                    <asp:Button runat="server" ID="btnC5" CssClass="seat_avail" Text="C5" OnClick="btnSeat_Click"/>
                    <asp:Button runat="server" ID="btnC6" CssClass="seat_avail" Text="C6" OnClick="btnSeat_Click"/>
                    <asp:Button runat="server" ID="btnC7" CssClass="seat_avail" Text="C7" OnClick="btnSeat_Click"/>
                    <asp:Button runat="server" ID="btnC8" CssClass="seat_avail" Text="C8" OnClick="btnSeat_Click"/>
                </div>               
            </div>
            <div class="line">
                <h5 class="seat_line_name">Line D:</h5>
                <div class="seat_line">
                    <asp:Button runat="server" ID="btnD1" CssClass="seat_avail" Text="D1" OnClick="btnSeat_Click"/>
                    <asp:Button runat="server" ID="btnD2" CssClass="seat_avail" Text="D2" OnClick="btnSeat_Click"/>
                    <asp:Button runat="server" ID="btnD3" CssClass="seat_avail" Text="D3" OnClick="btnSeat_Click"/>
                    <asp:Button runat="server" ID="btnD4" CssClass="seat_avail" Text="D4" OnClick="btnSeat_Click"/>
                    <asp:Button runat="server" ID="btnD5" CssClass="seat_avail" Text="D5" OnClick="btnSeat_Click"/>
                    <asp:Button runat="server" ID="btnD6" CssClass="seat_avail" Text="D6" OnClick="btnSeat_Click"/>
                    <asp:Button runat="server" ID="btnD7" CssClass="seat_avail" Text="D7" OnClick="btnSeat_Click"/>
                    <asp:Button runat="server" ID="btnD8" CssClass="seat_avail" Text="D8" OnClick="btnSeat_Click"/>
                </div>               
            </div>
            <div class="line">
                <h5 class="seat_line_name">Line E:</h5>
                <div class="seat_line">
                    <asp:Button runat="server" ID="btnE1" CssClass="seat_avail" Text="E1" OnClick="btnSeat_Click"/>
                    <asp:Button runat="server" ID="btnE2" CssClass="seat_avail" Text="E2" OnClick="btnSeat_Click"/>
                    <asp:Button runat="server" ID="btnE3" CssClass="seat_avail" Text="E3" OnClick="btnSeat_Click"/>
                    <asp:Button runat="server" ID="btnE4" CssClass="seat_avail" Text="E4" OnClick="btnSeat_Click"/>
                    <asp:Button runat="server" ID="btnE5" CssClass="seat_avail" Text="E5" OnClick="btnSeat_Click"/>
                    <asp:Button runat="server" ID="btnE6" CssClass="seat_avail" Text="E6" OnClick="btnSeat_Click"/>
                    <asp:Button runat="server" ID="btnE7" CssClass="seat_avail" Text="E7" OnClick="btnSeat_Click"/>
                    <asp:Button runat="server" ID="btnE8" CssClass="seat_avail" Text="E8" OnClick="btnSeat_Click"/>
                </div>               
            </div>
        </div>
        <div id="seat_description">
            <table>
                <tr>
                    <td>
                        <h5 class="seat_description_name">Available = </h5>
                        <div class="seat_description_line">
                            <button class="seat_avail_description" disabled="disabled"></button>
                        </div>
                    </td>
                    <td>
                        <h5 class="seat_description_name">Booked = </h5>
                        <div class="seat_description_line">
                            <button class="seat_booked_description" disabled="disabled"></button>
                        </div>
                    </td>
                    <td>
                        <h5 class="seat_description_name">Selected = </h5>
                        <div class="seat_description_line">
                            <button class="seat_select_description" disabled="disabled"></button>
                        </div>
                    </td>
                </tr>                
            </table>
        </div>
        <div class="panel_lower">
                    
        </div>
    </div>
</asp:Content>
