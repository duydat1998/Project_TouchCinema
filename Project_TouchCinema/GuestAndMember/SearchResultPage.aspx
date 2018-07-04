<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MemberLayout.Master" AutoEventWireup="true" CodeBehind="SearchResultPage.aspx.cs" Inherits="Project_TouchCinema.GuestAndMember.SearchResultPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" runat="server">
    <link href="../Css_File/StyleSheet.css" rel="stylesheet" />
    <div>
        <%-- Phần search movie --%>
        <div>
            <div id="search_mess">Do you want to find a movie?</div>            
            <div id="search_form">
                <asp:TextBox runat="server" ID="txtSearchValue" Width="300px" placeholder="Type the movie you want to search" CssClass="textbox"/>
                <asp:Button runat="server" ID="btnSeacrh" Text="Search" CssClass="button" OnClick="btnSeacrh_Click"/>                
            </div>
        </div>
        <hr />
        <div>
            <asp:Label runat="server" ID="ResultFor" Text="" Visible="true"/>
            <asp:Repeater runat="server" ID="ResultDetail">
                <HeaderTemplate>
                    <table style="border: 1px double black; ">
                        <thead>
                            <tr>                                
                                <th>Image</th>
                                <th>MovieTitle</th>
                                <th>Length</th>
                                <th>Rate</th>
                                <th>Start at</th>
                                <th>Producer</th>
                                <th>Year</th>
                                <th>Trailer's Link</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                            <tr>
                                <td><img src=""/></td>
                                <td><%# Eval("movieTitle") %></td>
                                <td><%# Eval("length") %></td>
                                <td><%# Eval("rating")%></td>
                                <td><%# Eval("startDate")%></td>
                                <td><%# Eval("producer")%></td>
                                <td><%# Eval("year")%></td>
                                <td><a href=""></a></td>
                            </tr>
                </ItemTemplate>
                <FooterTemplate>
                        </tbody>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <asp:Label runat="server" ID="ResultEmpty" Visible="false">
                <h1>Sorry! No Movie is Matched!!!!!</h1>
            </asp:Label> 
        </div>
        <hr />
    </div>        
</asp:Content>
