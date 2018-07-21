<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MemberLayout.Master" AutoEventWireup="true" CodeBehind="MemberChangePassword.aspx.cs" Inherits="Project_TouchCinema.GuestAndMember.MemberChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 501px;
        }
        .auto-style2 {
            width: 252px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" runat="server">
    <h1 class="title">Change password</h1>
    <table>
        <tr>
            <td class="auto-style2">Old password*:</td>
            <td>
                <asp:TextBox ID="txtOldPass" runat="server" ClientIDMode="Static" Width="260px" TextMode="Password" BackColor="White" onkeypress="HideErrorMessage('oldpassRequire')"></asp:TextBox>
            </td>
            <td class="auto-style1">
                <span id="oldpassRequire" class="error_message">Password is required. </span>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">New Password*:</td>
            <td>
                <asp:TextBox ID="txtNewPass" runat="server" ClientIDMode="Static" Width="260px" TextMode="Password" BackColor="White" onkeypress="HideErrorMessage('newpassRequire','newpassLength')" placeholder="Password is no more than 10 characters"></asp:TextBox>
            </td>
            <td class="auto-style1">
                <span id="newpassRequire" class="error_message">Password is required. </span>
                <br />
                <span id="newpassLength" class="error_message">Password must be no more than 10 characters. </span>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Confirm new password*:</td>
            <td>
                <asp:TextBox ID="txtConfirmPass" runat="server" ClientIDMode="Static" Width="260px" TextMode="Password" BackColor="White" onkeypress="HideErrorMessage('confirmPassRequire','confirmPassMatch')" placeholder="Confirm password"></asp:TextBox>
            </td>
            <td class="auto-style1">
                <span id="confirmPassRequire" class="error_message">Confirm Password is required. </span>
                <br />
                <span id="confirmPassMatch" class="error_message">Confirm Password is not matched.   </span>
            </td>
        </tr>
        <tr>
            <td class="auto-style2"></td>
            <td><asp:Button ID="btnChange" runat="server" Text="Change" CssClass="button" OnClick="btnChange_Click" OnClientClick="return ValidateChangePass()"/></td>
            <td class="auto-style1"><input id="Reset1" type="reset" value="Reset" class="button" /></td>
        </tr>
    </table>
</asp:Content>
