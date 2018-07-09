<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MemberLayout.Master" AutoEventWireup="true" CodeBehind="MemberInformation.aspx.cs" Inherits="Project_TouchCinema.GuestAndMember.MemberInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 147px;
        }
        .auto-style2 {
            width: 826px;
            height: 875px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" runat="server">
    <table class="auto-style2">
        <tr>
            <td class="auto-style1">Avatar:</td>
            <td></td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Image ID="imageAvatar" runat="server" CssClass="avatar" /></td>
            <td colspan="2">
                <asp:FileUpload ID="FileUpload" runat="server" Width="322px" />
                <asp:Button ID="btnUploadPicture" runat="server" Text="Upload Picture" OnClick="btnUploadPicture_Click" CssClass="button" />
                <asp:HiddenField ID="txtPicture" runat="server" />
            </td>

        </tr>
        <tr>
            <td class="auto-style1">Username:</td>
            <td><asp:Label ID="txtUsername" runat="server" Text="Label"></asp:Label></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td class="auto-style1">First name:</td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:TextBox ClientIDMode="Static" onkeypress="HideErrorMessage('firtnameRequire','invalidInput')" ID="txtFirstName" runat="server"  BackColor="White" Width="249px"></asp:TextBox></td>
            <td>
                <span id="firtnameRequire" class="error_message">First name is required. </span>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Last name:</td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:TextBox ClientIDMode="Static" onkeypress="HideErrorMessage('latnameRequire','invalidInput')" ID="txtLastName" runat="server" BackColor="White" Width="249px"></asp:TextBox></td>
            <td>
                <span id="latnameRequire" class="error_message">Last name is required. </span>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Phone number:</td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:TextBox ClientIDMode="Static" placeholder="The phone number to contact to you" onkeypress="HideErrorMessage('phoneRequire','phoneFormat','invalidInput')" ID="txtPhone" runat="server" TextMode="Phone" BackColor="White" Width="244px"></asp:TextBox></td>
            <td>
                <span id="phoneRequire" class="error_message">Phone number is required. </span>
                <br />
                <span id="phoneFormat" class="error_message">Phone number is NOT in corect format. </span>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Email:</td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:TextBox ClientIDMode="Static" placeholder="Email address to contact to you" onkeypress="HideErrorMessage('emailRequire','emailFormat','invalidInput')" ID="txtEmail" runat="server" BackColor="White" Width="240px"></asp:TextBox></td>
            <td>
                <span id="emailRequire" class="error_message">Email is required. </span>
                <br />
                <span id="emailFormat" class="error_message">Email is NOT in corect format. </span>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Day of Birth:</td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:DropDownList ID="dlDay" ClientIDMode="Static" runat="server" BackColor="White" onchange="HideErrorMessage('dateInvalid','invalidInput')"></asp:DropDownList></td>
            <td>
                <asp:DropDownList ID="dlMonth" ClientIDMode="Static" runat="server" BackColor="White" onchange="HideErrorMessage('dateInvalid','invalidInput')"></asp:DropDownList></td>
            <td>
                <asp:DropDownList ID="dlYear" runat="server" ClientIDMode="Static" BackColor="White" onchange="HideErrorMessage('dateInvalid','invalidInput')"></asp:DropDownList></td>
            <td class="auto-style4"><span id="dateInvalid" class="error_message">Date is not valid. </span></td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="button"  OnClick="btnRegister_Click" OnClientClick="return CheckBeforeRegister()" />
            </td>
            <td>

            </td>
            <td>
                <span id="invalidInput" class="error_message">You must fill in all fields in correct format before register.</span>
            </td>
        </tr>
    </table>
</asp:Content>
