<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/AdminLayout.Master" AutoEventWireup="true" CodeBehind="ManageSchedule.aspx.cs" Inherits="Project_TouchCinema.ManageSchedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 104px;
        }
        .auto-style2 {
            width: 303px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" runat="server">
    <h1>Cinema Schedule Management</h1>
            <table style="width: 48%;" border="0">
                <tr>
                    <td class="auto-style1">Schedule ID:</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtScheduleID" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">Date:</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">Time:</td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="dlHour" runat="server">
                        </asp:DropDownList>
                        &nbsp;H
                        <asp:DropDownList ID="dlMinute" runat="server">
                        </asp:DropDownList>
                        &nbsp;M
                        <asp:DropDownList ID="dlState" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dlState_SelectedIndexChanged">
                            <asp:ListItem>AM</asp:ListItem>
                            <asp:ListItem>PM</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td class="auto-style1">MovieID:</td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="dlMovieID" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td class="auto-style1">RoomID:</td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="dlRoomID" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">Price of Ticket:</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        &nbsp;<asp:Label ID="Label1" runat="server" Text="Search by MovieID:"></asp:Label>
    <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="button" OnClick="btnSearch_Click"/>
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnShowAll" runat="server" Text="Show All Records" CssClass="button" OnClick="btnShowAll_Click"/>
    <br />
    <asp:Button ID="btnNew" runat="server" Text="Add" CssClass="button" OnClick="btnNew_Click" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear" CssClass="button" />
        &nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="button" OnClick="btnDelete_Click"/>
        &nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="button" OnClick="btnUpdate_Click"/>
        <br />
    <asp:Label ID="lblMessage" runat="server" Text=" "></asp:Label>
        <br />
        
        <asp:GridView ID="gvStaffList" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal">
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <Columns>
                <asp:BoundField DataField="ScheduleID" HeaderText="ScheduleID" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="ScheduleDate" HeaderText="ScheduleDate" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="MovieID" HeaderText="MovieID" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="RoomID" HeaderText="RoomID" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="PriceOfTicket" HeaderText="Price" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkView" runat="server" CommandArgument='<%# Eval("ScheduleID") %>' OnClick="lnkView_Click" ForeColor="Blue"> View</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <SortedAscendingCellStyle BackColor="#F4F4FD" />
            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
            <SortedDescendingCellStyle BackColor="#D8D8F0" />
            <SortedDescendingHeaderStyle BackColor="#3E3277" />
        </asp:GridView>
        
</asp:Content>
