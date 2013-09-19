<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" EnableEventValidation="false" %>
    
<asp:Content ContentPlaceHolderID="TitleContentPlaceHolder" runat="server" ID="TitleContent">
    <asp:Literal runat="server" ID="TitleLabel"></asp:Literal>
</asp:Content>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="featured">
        <h5>Featured</h5>

        <asp:Repeater ID="FeaturedRepeater" runat="server">
        <ItemTemplate>
            <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("RottenTomatoesId") %>' onclick="ViewDetails_Click">
                <asp:Image ID="Image1" runat="server" 
                ImageUrl='<%# Eval("Posters[2].Url") %>' 
                CssClass="det-image" />
            </asp:LinkButton>
        </ItemTemplate>
        </asp:Repeater>

        <div class="short-description">
        </div>
    </div>
    
    <div class="content">
        <h2>Now Playing</h2>
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
                            Release Date: <b><asp:Literal ID="Literal3" runat="server" Text='<%# Eval("ReleaseDates.Count").ToString() == "0" ? "Not Available" : DataBinder.Eval(Container.DataItem, "ReleaseDates[0].Date", "{0:MMMM dd, yyyy}") %>'></asp:Literal></b><br />
                            Critics score: <b><asp:Literal ID="Literal6" runat="server" Text='<%# Eval("Ratings[0].Score") %>'></asp:Literal></b> 
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
