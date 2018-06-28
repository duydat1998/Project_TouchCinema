<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/StaffLayout.Master" AutoEventWireup="true" CodeBehind="StaffLogin.aspx.cs" Inherits="Project_TouchCinema.StaffLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" runat="server">
    <h2>Please log in to continue your work:</h2>
    <table style="width: 479px">
        <tr>
            <td>Staff ID</td>
            <td colspan="2"><asp:TextBox ID="txtUsername" runat="server" CssClass="textbox" Width="273px" OnTextChanged="txtUsername_TextChanged"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Password</td>
            <td colspan="2"><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="textbox" Width="273px"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" Width="96px" CssClass="button" /></td>
            <td>
                <input id="Reset1" type="reset" value="Reset" class="button"/>

            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <asp:Label ID="invalidLogin" runat="server" Text="Invalid username or password!" CssClass="error_message"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
