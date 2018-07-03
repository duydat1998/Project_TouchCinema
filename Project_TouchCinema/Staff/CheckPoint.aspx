<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/StaffLayout.Master" AutoEventWireup="true" CodeBehind="CheckPoint.aspx.cs" Inherits="Project_TouchCinema.Staff.CheckPoint" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 372px;
        }
        .auto-style2 {
            width: 414px;
        }
        .auto-style3 {
            width: 203px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" runat="server">
    <h1 class="title">Check Member point:</h1>
    <table style="width: 627px">
        <tr>
            <td class="auto-style1">UserID or Email or Phone</td>
            <td colspan="2"><asp:TextBox ID="txtSearch" runat="server" CssClass="textbox" Width="273px" onkeypress="HideInvalidMessage()"></asp:TextBox></td>
            <td><asp:Button ID="btnCheck" runat="server" Text="Check"  Width="96px" CssClass="button" OnClick="btnCheck_Click"/></td>
        </tr>
    </table>
     <asp:Label ID="invalidMember" runat="server" Text="There is no member like that! Please enter another information!" CssClass="error_message"></asp:Label>
    <div runat="server" id="memberInfo">
        <h2 class="title">Member Point</h2>
        <table>
            <tr>
                <td class="auto-style3">Member name:</td>
                <td class="auto-style2"><asp:Label ID="lbMemberName" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="auto-style3">Phone:</td>
                <td class="auto-style2"><asp:Label ID="lbPhone" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="auto-style3">Email:</td>
                <td class="auto-style2"><asp:Label ID="lbEmail" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="auto-style3">Point:</td>
                <td class="auto-style2"><asp:Label ID="lbPoint" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>
    </div>
</asp:Content>
