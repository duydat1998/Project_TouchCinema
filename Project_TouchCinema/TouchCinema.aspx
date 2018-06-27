<%@ Page Title="" Language="C#" MasterPageFile="~/MemberLayout.Master" AutoEventWireup="true" CodeBehind="TouchCinema.aspx.cs" Inherits="Project_TouchCinema.MemberWorkspace" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" runat="server">
    <div id="login_form">
        <h2>Be a member to get attractive promotion:</h2>
        <table style="width: 479px">
        <tr>
            <td>Member ID</td>
            <td colspan="2">
                <asp:TextBox ID="txtUsername" runat="server" CssClass="textbox" Width="273px"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td>Password</td>
            <td colspan="2">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="textbox" Width="273px"></asp:TextBox>
            </td>
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
        <tr>
            <td></td>
            <td colspan="2">
                <asp:Label ID="Label1" runat="server" Text="If you don't have an member account, register now !"></asp:Label><br />
                <asp:Button ID="btnRegister" runat="server" Text="Register Here" CssClass="button" OnClick="btnRegister_Click"/>
            </td>
        </tr>
    </table>
    </div>
</asp:Content>
