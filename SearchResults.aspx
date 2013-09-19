<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" EnableEventValidation="false" 
CodeFile="SearchResults.aspx.cs" Inherits="SearchResults" %>

<asp:Content ContentPlaceHolderID="TitleContentPlaceHolder" runat="server" ID="TitleContent">
    <asp:Literal runat="server" ID="TitleLabel"></asp:Literal>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="content">
        <h2><asp:Literal ID="Heading" runat="server"></asp:Literal></h2>
        <asp:Label ID="ResultsCount" runat="server"></asp:Label><br /><br />
        <asp:Repeater ID="MoviesRepeater" runat="server">
            <ItemTemplate>
                <div class="movie-summary">
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("RottenTomatoesId") %>' onclick="ViewDetails_Click">
                        <asp:Image ID="Image5" ImageUrl='<%# Eval("Posters[1].Url") %>' runat="server" CssClass="pro-image" />
                    </asp:LinkButton>
                    <div class="pro-description">
                        <h4><asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("RottenTomatoesId") %>' onclick="ViewDetails_Click">
                        <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("Title") %>'></asp:Literal> 
                        (<asp:Literal ID="Literal2" runat="server" Text='<%# Eval("Year") %>'></asp:Literal>)
                        </asp:LinkButton></h4>
                        <div>
                            <span><asp:Literal ID="Literal4" runat="server" Text='<%# Eval("MpaaRating") %>'></asp:Literal></span> 
                            Release Date: <b><asp:Literal ID="Literal3" runat="server" Text='<%# Eval("ReleaseDates.Count").ToString() == "0" ? "Not Available" : DataBinder.Eval(Container.DataItem, "ReleaseDates[0].Date", "{0:MMMM dd, yyyy}") %>'></asp:Literal></b>
                            <br />Critics score: <b><asp:Literal ID="Literal6" runat="server" Text='<%# Eval("Ratings[0].Score") %>'></asp:Literal></b> 
                            <br /><br />
                        </div>
                        <div class="synopsis">
                        <asp:Literal ID="Literal5" runat="server" Text='<%# Eval("Synopsis") %>'></asp:Literal>
                        </div>

                        <asp:ImageButton ID="ImageButton1" CommandArgument='<%# Eval("RottenTomatoesId") %>' runat="server" 
                            ImageUrl="~/images/moviedetails.png" onclick="ViewDetails_Click" />
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Panel ID="plcPaging" runat="server" CssClass="pagination_links">
        </asp:Panel>
        <%--<asp:PlaceHolder ID="plcPaging" runat="server" />--%>

    </div>

</asp:Content>
