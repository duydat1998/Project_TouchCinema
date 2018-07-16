<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MemberLayout.Master" AutoEventWireup="true" CodeBehind="BookTicketPage.aspx.cs" Inherits="Project_TouchCinema.GuestAndMember.BookTicketPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" runat="server">
    <link href="../Css_File/StyleSheet.css" rel="stylesheet" />
    <div id="book_ticket_content">
        <div id="detail">
            <table>
                <tr>
                    <td>Movie:</td>
                    <td><asp:DropDownList runat="server" ID="dlMovieList" OnSelectedIndexChanged="dlMovieList_SelectedIndexChanged"
                        AutoPostBack="true" CssClass="book_ticket_drop_list"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>Schedule(Day & Hour):</td>
                    <td><asp:DropDownList runat="server" ID="dlScheduleList" OnSelectedIndexChanged="dlScheduleList_SelectedIndexChanged"
                        AutoPostBack="true" CssClass="book_ticket_drop_list"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>Number of Tickets:</td>
                    <td><asp:DropDownList runat="server" ID="dlTicketNum" OnSelectedIndexChanged="dlTicketNum_SelectedIndexChanged"
                        AutoPostBack="true" CssClass="book_ticket_drop_list"></asp:DropDownList>
                        <asp:DropDownList runat="server" ID="dlScheduleID" Visible="false"></asp:DropDownList>
                    </td>
                </tr>
            </table>                                         
        </div>
        <div id="room">
            <div id="room_select">
                <asp:DropDownList runat="server" ID="dlRoomList"></asp:DropDownList>
            </div>
        </div>
    </div>
</asp:Content>
