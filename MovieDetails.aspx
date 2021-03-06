﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" EnableEventValidation="false"
    CodeFile="MovieDetails.aspx.cs" Inherits="MovieDetails" %>

<asp:Content ContentPlaceHolderID="TitleContentPlaceHolder" runat="server" ID="TitleContent">
    <asp:Literal runat="server" ID="TitleLabel"></asp:Literal>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="content">

        <asp:Label ID="lblNoMovieSelected" runat="server"></asp:Label>

        <asp:Repeater ID="MoviesRepeater" runat="server">
            <ItemTemplate>
                <div class="movie-details">
                    <a href="">
                        <asp:Image ID="Image5" ImageUrl='<%# ("http://image.tmdb.org/t/p/w185") + Eval("poster_path") %>' runat="server" CssClass="pro-image" />
                    </a>
                    <div class="pro-description">
                        <h4><a href="">
                            <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("title") %>'></asp:Literal>
                        </a></h4>
                        <div>
                            Release Date: <b>
                                <asp:Literal ID="Literal3" runat="server" Text='<%# Eval("release_date") %>'></asp:Literal></b>
                            <br />
                            Runtime: <b>
                                <asp:Literal ID="Literal5" runat="server" Text='<%# Eval("runtime") %>'></asp:Literal>mins</b>

                            <br />
                            Critics Rating: <b>
                                <asp:Literal ID="Literal6" runat="server" Text='<%# Eval("vote_average") %>'></asp:Literal></b><br />
                            <br />
                            <br />

                        </div>
                        <div class="synopsis">
                            Synopsis:<br />
                            <asp:Literal ID="Literal7" runat="server" Text='<%# Eval("overview") %>'></asp:Literal>
                            <br />
                            <br />
                        </div>

                        Director(s): <b>
                            <asp:Literal ID="lblDirectors" Text='<%# GetDirector((Credits)Eval("credits")) %>' runat="server"></asp:Literal></b>
                        <br />
                        <br />

                    </div>
                    <div class="synopsis">
                        Genre(s): <b>
                            <asp:Literal ID="lblGenres" Text='<%# GetGenre((List<Genre>) Eval("genres")) %>' runat="server"></asp:Literal></b>
                        <br />
                        <br />
                        Cast(s): <b>
                            <asp:Literal ID="lblCasts" Text='<%# GetCast((Credits)Eval("credits")) %>' runat="server"></asp:Literal></b>
                        <br />
                        <br />
                    </div>
                    <iframe
                        width="580" height="345"
                        src=<%# GetVideo((Videos) Eval("videos"))%>></iframe>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

