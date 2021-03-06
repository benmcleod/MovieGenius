﻿<%@ Page Title="Movies" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="movies.aspx.cs" Inherits="_Movies" EnableEventValidation="false" %>

<asp:Content ContentPlaceHolderID="TitleContentPlaceHolder" runat="server" ID="TitleContent">
    <asp:Literal runat="server" ID="TitleLabel"></asp:Literal>
</asp:Content>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <div class="content">
        <h2>
            <asp:Literal ID="Heading" runat="server"></asp:Literal></h2>
        <asp:Repeater ID="MoviesRepeater" runat="server">
            <ItemTemplate>
                <div class="movie-summary">
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("id") %>' OnClick="ViewDetails_Click">
                        <asp:Image ID="Image5" ImageUrl='<%# ("http://image.tmdb.org/t/p/w185") + Eval("poster_path") %>' runat="server" CssClass="pro-image" />
                    </asp:LinkButton>
                    <div class="pro-description">
                        <h4>
                            <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("id") %>' OnClick="ViewDetails_Click">
                                <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("title") %>'></asp:Literal>
                            </asp:LinkButton></h4>
                        <div>
                            <%--<span>
                                <asp:Literal ID="Literal4" runat="server" Text='<%# Eval("mpaa_rating") %>'></asp:Literal>
                            </span>--%>
                            Release Date: <b>
                                <asp:Literal ID="Literal3" runat="server" Text='<%# Eval("release_date") %>'></asp:Literal></b>
                            <br />
                            Score: <b>
                                <asp:Literal ID="Literal6" runat="server" Text='<%# Eval("vote_average") %>'></asp:Literal></b>
                            <br />
                            <br />
                        </div>
                        <div class="synopsis">
                            <asp:Literal ID="Literal5" runat="server" Text='<%# Eval("overview") %>'></asp:Literal>
                        </div>

                        <asp:ImageButton ID="ImageButton1" CommandArgument='<%# Eval("id") %>' runat="server"
                            ImageUrl="~/images/moviedetails.png" OnClick="ViewDetails_Click" />
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Panel ID="plcPaging" runat="server" CssClass="pagination_links">
        </asp:Panel>
        <%--<asp:PlaceHolder ID="plcPaging" runat="server" />--%>
    </div>

</asp:Content>
