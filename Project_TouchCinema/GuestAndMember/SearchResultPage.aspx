<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MemberLayout.Master" AutoEventWireup="true" CodeBehind="SearchResultPage.aspx.cs" Inherits="Project_TouchCinema.GuestAndMember.SearchResultPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" runat="server">
    <link href="../Css_File/StyleSheet.css" rel="stylesheet" />
    <div>
        <%-- Phần search movie --%>
        <div id="search_bar">
            <div id="search_mess">Do you want to find a movie?</div>            
            <div id="search_form">
                <asp:TextBox runat="server" ID="txtSearchValue" Width="300px" placeholder="Type the movie you want to search" CssClass="textbox"/>
                <asp:Button runat="server" ID="btnSeacrh" Text="Search" CssClass="button" OnClick="btnSeacrh_Click"/>                
            </div>
        </div>        
        <div id="search_result">
            <hr />
            <asp:Label runat="server" ID="ResultFor" Text="" Visible="true" CssClass="search_result_mess"/>
            <asp:Repeater runat="server" ID="ResultDetail">
                <HeaderTemplate>
                    <table border="1">
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
                                <td>
                                    <a href="MemberRegister.aspx"><img src="<%# Eval("poster")%>" style="width: 100%;"/></a>
                                </td>
                                <td><%# Eval("MovieTitle") %></td>
                                <td><%# Eval("Length") + " phút" %></td>
                                <td><%# Eval("Rating")%></td>
                                <td><%# Eval("StartDate")%></td>
                                <td><%# Eval("Producer")%></td>
                                <td><%# Eval("Year")%></td>
                                <td><a href="<%# Eval("LinkTrailer")%>"></a></td>
                            </tr>
                </ItemTemplate>
                <FooterTemplate>
                        </tbody>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <asp:Label runat="server" ID="ResultEmpty" Visible="false" CssClass="search_result_mess">
                <h1 id="empty_label">Sorry! No Movie is Matched!!!!!</h1>
            </asp:Label> 
            <hr />
        </div>        
    </div>        
</asp:Content>
