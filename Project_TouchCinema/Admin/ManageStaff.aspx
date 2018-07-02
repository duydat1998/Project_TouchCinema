<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/AdminLayout.Master" AutoEventWireup="true" CodeBehind="ManageStaff.aspx.cs" Inherits="Project_TouchCinema.ManageStaff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" runat="server">
    <h1>Cinema Staff Management</h1>
    <asp:HiddenField ID="hfUsername" runat="server" />
            <table style="width: 36%;" border="0">
                <tr>
                    <td class="auto-style1">Username:</td>
                    <td>
                        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Password:</td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">First Name:</td>
                    <td>
                        <asp:TextBox ID="txtFirstname" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Last Name:</td>
                    <td>
                        <asp:TextBox ID="txtLastname" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Phone:</td>
                    <td>
                        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Email:</td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        
        &nbsp;<asp:Button ID="btnNew" runat="server" Text="Add" CssClass="button" OnClick="btnNew_Click" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" CssClass="button" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear" CssClass="button" />
        <br />
    <asp:Label ID="lblMessage" runat="server" Text=" "></asp:Label>
        <br />
    <asp:Button ID="btnUpdateActive" runat="server" Text="Update Activation" CssClass="button" Width="200px" OnClick="btnUpdateActive_Click" />
        <br />
        
        <asp:GridView ID="gvStaffList" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Username" HeaderText="Username" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" />
                <asp:BoundField DataField="Phone" HeaderText="Phone" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:CheckBoxField DataField="IsActive" HeaderText="IsActive"/>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkView" runat="server" CommandArgument="<%# Eval("Username") %>" OnClick="lnkView_Click"> View</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
</asp:Content>
