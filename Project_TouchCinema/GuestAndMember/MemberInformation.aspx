<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MemberLayout.Master" AutoEventWireup="true" CodeBehind="MemberInformation.aspx.cs" Inherits="Project_TouchCinema.GuestAndMember.MemberInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 209px;
        }
        .auto-style2 {
            width: 1064px;
            height: 749px;
        }
        .auto-style4 {
            width: 331px;
        }
        .auto-style6 {
            width: 124px;
        }
        .auto-style7 {
            width: 330px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" runat="server">
    <h1 class="title">Member Information</h1>
    <table class="auto-style2">
        <tr>
            <td class="auto-style7">Avatar:</td>
            <td></td>
        </tr>
        <tr>
            <td class="auto-style7">
                <asp:Image ID="imageAvatar" runat="server" CssClass="avatar" /></td>
            <td colspan="2">
                <asp:FileUpload ID="FileUpload" runat="server" Width="322px" />
                <asp:Button ID="btnUploadPicture" runat="server" Text="Upload Picture" OnClick="btnUploadPicture_Click" CssClass="button" />
                <asp:HiddenField ID="txtPicture" runat="server" />
            </td>

        </tr>
        <tr>
            <td class="auto-style7">Username: <b><asp:Label ID="txtUsername" runat="server" Text="Label"></asp:Label></b></td>
            <td></td>
            <td class="auto-style6"></td>
            <td class="auto-style4"></td>
        </tr>
        <tr>
            <td class="auto-style7">First name:</td>
            <td></td>
            <td class="auto-style6"></td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:TextBox ClientIDMode="Static" onkeypress="HideErrorMessage('firtnameRequire','invalidInput')" ID="txtFirstName" runat="server"  BackColor="White" Width="249px"></asp:TextBox></td>
            <td class="auto-style4">
                <span id="firtnameRequire" class="error_message">First name is required. </span>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">Last name:</td>
            <td></td>
            <td class="auto-style6"></td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:TextBox ClientIDMode="Static" onkeypress="HideErrorMessage('latnameRequire','invalidInput')" ID="txtLastName" runat="server" BackColor="White" Width="249px"></asp:TextBox></td>
            <td class="auto-style4">
                <span id="latnameRequire" class="error_message">Last name is required. </span>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">Phone number:</td>
            <td></td>
            <td class="auto-style6"></td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:TextBox ClientIDMode="Static" placeholder="The phone number to contact to you" onkeypress="HideErrorMessage('phoneRequire','phoneFormat','invalidInput')" ID="txtPhone" runat="server" TextMode="Phone" BackColor="White" Width="244px"></asp:TextBox></td>
            <td class="auto-style4">
                <span id="phoneRequire" class="error_message">Phone number is required. </span>
                <br />
                <span id="phoneFormat" class="error_message">Phone number is NOT in corect format. </span>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">Email:</td>
            <td></td>
            <td class="auto-style6"></td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:TextBox ClientIDMode="Static" placeholder="Email address to contact to you" onkeypress="HideErrorMessage('emailRequire','emailFormat','invalidInput')" ID="txtEmail" runat="server" BackColor="White" Width="240px"></asp:TextBox></td>
            <td class="auto-style4">
                <span id="emailRequire" class="error_message">Email is required. </span>
                <br />
                <span id="emailFormat" class="error_message">Email is NOT in corect format. </span>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">Day of Birth:</td>
            <td></td>
            <td class="auto-style6"></td>
        </tr>
        <tr>
            <td class="auto-style1" colspan="3">
                <asp:DropDownList ID="dlDay" ClientIDMode="Static" runat="server" BackColor="White" Width="100px" onchange="HideErrorMessage('dateInvalid','invalidInput')"></asp:DropDownList>
                <asp:DropDownList ID="dlMonth" ClientIDMode="Static" runat="server" BackColor="White" Width="100px" onchange="HideErrorMessage('dateInvalid','invalidInput')"></asp:DropDownList>
                <asp:DropDownList ID="dlYear" runat="server" ClientIDMode="Static" BackColor="White" Width="100px" onchange="HideErrorMessage('dateInvalid','invalidInput')"></asp:DropDownList>
            </td>
            <td class="auto-style4"><span id="dateInvalid" class="error_message">Date is not valid. </span></td>
        </tr>
        <tr>
            <td class="auto-style7">
                <asp:Button ID="btnUpdate" runat="server" Text="Update profile" CssClass="button"  OnClick="btnUpdate_Click" OnClientClick="return CheckBeforeUpdate()" />
            </td>
            <td>
                <asp:Button ID="btnChangePass" runat="server" Text="Change Password" CssClass="button" OnClick="btnChangePass_Click" />
            </td>
            <td></td>
            <td class="auto-style6">
                <span id="invalidInput" class="error_message">You must fill in all fields in correct format before updating.</span>
            </td>
        </tr>
    </table>
</asp:Content>
