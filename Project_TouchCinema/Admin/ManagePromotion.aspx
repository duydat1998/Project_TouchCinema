<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/AdminLayout.Master" AutoEventWireup="true" CodeBehind="ManagePromotion.aspx.cs" Inherits="Project_TouchCinema.ManagePromotion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" runat="server">
    <br />
    <asp:Label ID="lblCode" runat="server" Font-Size="X-Large" Text="Promotion code will appear here!"></asp:Label>
    <br />
    <br />
    
    <asp:Button ID="btnGenerate" runat="server" Text="Generate Promotion Code" CssClass="button" OnClick="btnGenerate_Click" />
    
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Promotion Name:" Font-Size="Large"></asp:Label>
&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtName" runat="server" Width="227px"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="btnAdd" runat="server" Text="Add promotion" CssClass="button" />
    <br />
    <br />
    <asp:Label ID="lblMessage" runat="server" Text=" "></asp:Label>
        <br />
    <asp:Button ID="btnUpdateActive" runat="server" Text="Update Activation" CssClass="button" Width="200px" OnClick="btnUpdateActive_Click" />
        <br />
        
        <asp:GridView ID="gvStaffList" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal">
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <Columns>
                <asp:BoundField DataField="RoomID" HeaderText="RoomID" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="NumberOfSeat" HeaderText="NumberOfSeat" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="IsAvailable">
                    <ItemTemplate>
                        <asp:CheckBox ID="isActive" runat="server" Checked='<%# Eval("IsActive").ToString().Equals("True")  %>'/>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <SortedAscendingCellStyle BackColor="#F4F4FD" />
            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
            <SortedDescendingCellStyle BackColor="#D8D8F0" />
            <SortedDescendingHeaderStyle BackColor="#3E3277" />
        </asp:GridView>
        
</asp:Content>
