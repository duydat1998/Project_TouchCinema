<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MemberLayout.Master" AutoEventWireup="true" CodeBehind="MemberRegister.aspx.cs" Inherits="Project_TouchCinema.MemberRegister" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 294px;
        }
        .auto-style2 {
            width: 206px;
        }
        .auto-style3 {
            width: 94px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" runat="server">        
    <h1 class="title">Register to be a member for attractive promotions</h1>
    <table>
        <tr>
            <td class="auto-style2">Username:</td>
            <td class="auto-style3"></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td class="auto-style1" colspan="3"><asp:TextBox ID="txtUsername" runat="server" Width="533px" BackColor="White"></asp:TextBox></td>
            <td></td>
        </tr>
        <tr>
            <td class="auto-style2">Password:</td>
            <td class="auto-style3"></td>
            <td></td>
        </tr>   
        <tr>
            <td class="auto-style1" colspan="3"><asp:TextBox ID="txtPass" runat="server" Width="533px" TextMode="Password" BackColor="White"></asp:TextBox></td>
            <td></td>
        </tr>
        <tr>
            <td class="auto-style2">Confirm password:</td>
            <td class="auto-style3"></td>
            <td></td>
        </tr>        
        <tr>
            <td class="auto-style1" colspan="3"><asp:TextBox ID="txtConfirmPass" runat="server" Width="533px" TextMode="Password" BackColor="White"></asp:TextBox></td>
            <td></td>
        </tr>
        <tr>
            <td class="auto-style2">First name:</td>
            <td class="auto-style3"></td>
            <td></td>
        </tr>      
        <tr>
            <td class="auto-style1" colspan="3"><asp:TextBox ID="txtFirstName" runat="server" Width="533px" BackColor="White"></asp:TextBox></td>
            <td></td>
        </tr>
        <tr>
            <td class="auto-style2">Last name:</td>
            <td class="auto-style3"></td>
            <td></td>
        </tr>  
        <tr>
            <td class="auto-style1" colspan="3"><asp:TextBox ID="txtLastName" runat="server" Width="533px" BackColor="White"></asp:TextBox></td>
            <td></td>
        </tr>
        <tr>
            <td class="auto-style2">Phone number:</td>
            <td class="auto-style3"></td>
            <td></td>
        </tr>    
        <tr>
            <td class="auto-style1" colspan="3"><asp:TextBox ID="txtPhone" runat="server" Width="533px" TextMode="Phone" BackColor="White"></asp:TextBox></td>
            <td></td>
        </tr>
        <tr>
            <td class="auto-style2">Email:</td>
            <td class="auto-style3"></td>
            <td></td>
        </tr>      
        <tr>
            <td class="auto-style1" colspan="3"><asp:TextBox ID="txtEmail" runat="server" Width="533px" BackColor="White"></asp:TextBox></td>
            <td></td>
        </tr>
        <tr>
            <td class="auto-style2">Day of Birth:</td>
            <td class="auto-style3"></td>
            <td></td>
        </tr>     
        <tr>
            <td class="auto-style2"><asp:DropDownList ID="dlDay" runat="server" Width="130px" BackColor="White"></asp:DropDownList></td>
            <td class="auto-style3"><asp:DropDownList ID="dlMonth" runat="server" Width="130px" BackColor="White"></asp:DropDownList></td>
            <td><asp:DropDownList ID="dlYear" runat="server" Width="130px" BackColor="White"></asp:DropDownList></td>
        </tr>
        <tr>
            <td class="auto-style2">Avatar:</td>
            <td class="auto-style3"></td>
        </tr>
        <tr>
            <td>Got picture</td>
        </tr>
        <tr>
            <td colspan="3"><asp:CheckBox ID="chkGetNotify" runat="server" Text="Get notifications by email from Touch Cinema"/></td>
        </tr>
        <tr>
            <td colspan="3"><asp:CheckBox ID="chkAgree" runat="server" Text="I have read and agree to Touch Cinema's Term and Condition" /></td>
        </tr>
        <tr>
            <td colspan="3" style="color:green;">If you haven't read the Term and Condition, <b><a href="TermAndCondition.aspx" style="color:green;text-decoration:underline">read here</a></b>.</td>
        </tr>
        <tr>
            <td class="auto-style3" colspan="3"><asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="button" Width="538px" /></td>
        </tr>
    </table>
</asp:Content>
