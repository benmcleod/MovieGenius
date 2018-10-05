<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" EnableEventValidation="false" %>

<asp:Content ContentPlaceHolderID="TitleContentPlaceHolder" runat="server" ID="TitleContent">
    <asp:Literal runat="server" ID="TitleLabel"></asp:Literal>
</asp:Content>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

    <script src="Scripts/jquery.bxslider.min.js" type="text/javascript"></script>
    <link href="Styles/jquery.bxslider.css" rel="stylesheet" />
    <script src="Scripts/bxslider.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="featured">
        <h5>Popular</h5>

        <asp:Repeater ID="FeaturedRepeater" runat="server">

            <HeaderTemplate>
                <ul id="bxslider" class="bxslider">
            </HeaderTemplate>

            <ItemTemplate>
                <li>
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("id") %>'
                        OnClick="ViewDetails_Click">

                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# ("http://image.tmdb.org/t/p/w185") + Eval("poster_path") %>' />
                    </asp:LinkButton>
                </li>
            </ItemTemplate>
        </asp:Repeater>

    </div>

    <div class="content">
        <h2>Now Playing</h2>
        <asp:Repeater ID="MoviesRepeater" runat="server">
            <ItemTemplate>
                <div class="movie-summary">
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("id") %>' OnClick="ViewDetails_Click">
                        <asp:Image ID="Image5" ImageUrl='<%#("http://image.tmdb.org/t/p/w185") + Eval("poster_path") %>' runat="server" CssClass="pro-image" />
                    </asp:LinkButton>
                    <div class="pro-description">
                        <h4>
                            <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("id") %>' OnClick="ViewDetails_Click">
                                <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("title") %>'></asp:Literal>
                               <%-- (<asp:Literal ID="Literal2" runat="server" Text='<%# Eval("release_date") %>'></asp:Literal>)--%>
                            </asp:LinkButton>
                        </h4>
                        <%--<div>
                            <span>
                                <asp:Literal ID="Literal4" runat="server" Text='<%# Eval("mpaa_rating") %>'></asp:Literal></span>
                            Release Date: <b>
                                <asp:Literal ID="Literal3" runat="server" Text='<%# Eval("release_dates.theater").ToString() == "0" ? "Not Available" : DataBinder.Eval(Container.DataItem, "release_dates.theater.Date", "{0:MMMM dd, yyyy}") %>'></asp:Literal></b><br />
                            Critics score: <b>
                                <asp:Literal ID="Literal6" runat="server" Text='<%# Eval("ratings.critics_rating") %>'></asp:Literal></b>
                            <br />
                            <br />
                        </div>--%>
                        <div class="synopsis">
                            <asp:Literal ID="Literal5" runat="server" Text='<%# Eval("overview") %>'></asp:Literal>
                        </div>

                        <%--<asp:ImageButton ID="ImageButton1" CommandArgument='<%# Eval("id") %>' runat="server"
                            ImageUrl="~/images/moviedetails.png" OnClick="ViewDetails_Click" />--%>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Panel ID="plcPaging" runat="server" CssClass="pagination_links">
        </asp:Panel>

    </div>

</asp:Content>
