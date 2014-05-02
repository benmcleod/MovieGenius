<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" EnableEventValidation="false"
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
                        <asp:Image ID="Image5" ImageUrl='<%# Eval("posters.detailed") %>' runat="server" CssClass="pro-image" />
                    </a>
                    <div class="pro-description">
                        <h4><a href="">
                            <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("title") %>'></asp:Literal>
                            (<asp:Literal ID="Literal2" runat="server" Text='<%# Eval("year") %>'></asp:Literal>)
                        </a></h4>
                        <div>
                            <span>
                                <asp:Literal ID="Literal4" runat="server" Text='<%# Eval("mpaa_rating") %>'></asp:Literal></span>
                            Release Date: <b>
                                <asp:Literal ID="Literal3" runat="server" Text='<%# Eval("release_dates.theater").ToString() == "0" ? "Not Available" :  DataBinder.Eval(Container.DataItem, "release_dates.theater.Date", "{0:MMMM dd, yyyy}") %>'></asp:Literal></b>
                            <br />
                            Runtime: <b>
                                <asp:Literal ID="Literal5" runat="server" Text='<%# Eval("runtime") %>'></asp:Literal>mins</b>

                            <br />
                            Critics Rating: <b>
                                <asp:Literal ID="Literal6" runat="server" Text='<%# Eval("ratings.critics_rating") %>'></asp:Literal></b><br />
                            <br />
                            <br />

                        </div>
                        <div class="synopsis">
                            Synopsis:<br />
                            <asp:Literal ID="Literal7" runat="server" Text='<%# Eval("synopsis") %>'></asp:Literal>
                            <br />
                            <br />
                        </div>

                        Director(s): <b>
                            <asp:Literal ID="lblDirectors" Text='<%# Eval("abridged_directors[0].name") %>' runat="server"></asp:Literal></b>
                        <br />
                        <br />

                    </div>
                    <div class="synopsis">
                        Genre(s): <b>
                            <asp:Literal ID="lblGenres" Text='<%# Eval("genres[0]") %>' runat="server"></asp:Literal></b>
                        <br />
                        <br />
                        Cast(s): <b>
                            <asp:Literal ID="lblCasts" Text='<%# Eval("abridged_cast[0].name") %>' runat="server"></asp:Literal></b>
                        <br />
                        <br />
                    </div>
                    <iframe
                        width="580" height="345"
                        src='<%# DataBinder.Eval(Container.DataItem, "links.self", "http://www.youtube.com/v/{0}?version=3") %>'
                        type="application/x-shockwave-flash">
            </iframe>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

