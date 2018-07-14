<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MemberLayout.Master" AutoEventWireup="true" CodeBehind="FeedbackPage.aspx.cs" Inherits="Project_TouchCinema.GuestAndMember.FeedbackPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 133px;
        }
        .auto-style2 {
            width: 287px;
        }
        .auto-style3 {
            width: 273px;
        }
        .auto-style4 {
            width: 363px;
        }
        .auto-style5 {
            width: 979px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" runat="server">
    <h1 class="title">Feedback</h1>
    <h3>We hope to get constructive opinions from you to improve our services.
        <br />
        
        Thank you!
    </h3>
    <textarea id="txtFeedback" cols="100" rows="10" placeholder="Your opinions..." style="overflow:scroll;"></textarea>
    <table class="auto-style5">
        <tr>
            <td colspan="2">Please leave information for us to contact to you:</td>
        </tr>
        <tr>
            <td class="auto-style1">Name:</td>
            <td class="auto-style2"><input id="txtName" type="text" class="auto-style3" /></td>
        </tr>
        <tr>
            <td class="auto-style1">Email:</td>
            <td class="auto-style2"><input id="txtEmail" type="text" class="auto-style3" onkeypress="HideErrorMessage('emailFormat')" /></td>
            <td class="auto-style4">
                <span id="emailFormat" class="error_message">Email is NOT in corect format. </span>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Phone:</td>
            <td class="auto-style2"><input id="txtPhone" type="text" class="auto-style3" onkeypress="HideErrorMessage('phoneFormat')"/></td>
            <td class="auto-style4">
                <span id="phoneFormat" class="error_message">Phone number is NOT in corect format. </span>
            </td>
        </tr>
        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style2"><asp:Button ID="btnFeedback" Text="Give Feedback" OnClientClick="return CheckFeedbackInformation()" OnClick="btnFeedback_Click" runat="server" CssClass="button"/></td>
        </tr>
    </table>
</asp:Content>
