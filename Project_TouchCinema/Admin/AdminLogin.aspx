<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/AdminLayout.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="Project_TouchCinema.AdminLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" runat="server">
    <h2>Please log in to continue your work:</h2>
    <table style="width: 479px">
        <tr>
            <td>Admin ID</td>
            <td colspan="2">
                <asp:TextBox ID="txtUsername" runat="server" ClientIDMode="Static" CssClass="textbox" Width="273px" onkeypress="HideInvalidMessage()"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td>Password</td>
            <td colspan="2">
                <asp:TextBox ID="txtPassword" runat="server" ClientIDMode="Static" TextMode="Password" CssClass="textbox" Width="273px"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" OnClientClick="return CheckLoginInput('txtUsername','txtPassword')" Width="96px" CssClass="button" /></td>
            <td>
                <input id="Reset1" type="reset" value="Reset" class="button"/>

            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <asp:Label ID="invalidLogin" runat="server" ClientIDMode="Static" Text="Invalid username or password!" CssClass="error_message"></asp:Label><br />
            </td>
        </tr>
    </table>
</asp:Content>
