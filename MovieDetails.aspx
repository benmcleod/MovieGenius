<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" EnableEventValidation="false" 
CodeFile="MovieDetails.aspx.cs" Inherits="MovieDetails" %>

<asp:Content ContentPlaceHolderID="TitleContentPlaceHolder" runat="server" ID="TitleContent">
    <asp:Literal runat="server" ID="TitleLabel"></asp:Literal>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="content">

        <asp:Label ID="lblNoMovieSelected" runat="server"></asp:Label>
    
    <asp:Repeater ID="MoviesRepeater" runat="server">
    <ItemTemplate>
        <div class="movie-details">
            <a href="">
                <asp:Image ID="Image5" ImageUrl='<%# Eval("Posters[2].Url") %>' runat="server" CssClass="pro-image" />
            </a>
            <div class="pro-description">
                <h4><a href="">
                    <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("Title") %>'></asp:Literal> 
                    (<asp:Literal ID="Literal2" runat="server" Text='<%# Eval("Year") %>'></asp:Literal>)
                    </a></h4>
                <div>
                    <span><asp:Literal ID="Literal4" runat="server" Text='<%# Eval("MpaaRating") %>'></asp:Literal></span> 
                    Release Date: <b><asp:Literal ID="Literal3" runat="server" Text='<%# Eval("ReleaseDates.Count").ToString() == "0" ? "Not Available" :  DataBinder.Eval(Container.DataItem, "ReleaseDates[0].Date", "{0:MMMM dd, yyyy}") %>'></asp:Literal></b> <br />
                    Runtime: <b><asp:Literal ID="Literal5" runat="server" Text='<%# Eval("Runtime") %>'></asp:Literal>mins</b>
                    
                    <br />Critics Rating: <b><asp:Literal ID="Literal6" runat="server" Text='<%# Eval("Ratings[0].Score") %>'></asp:Literal></b><br />
                     <br /> <br />
                    
                </div>
                <div class="synopsis">
                Synopsis:<br />
                <asp:Literal ID="Literal7" runat="server" Text='<%# Eval("Synopsis") %>'></asp:Literal> <br /><br />
                </div>
                
                Director(s): <b><asp:Literal ID="lblDirectors" Text='<%# Eval("Directors[0]") %>' runat="server"></asp:Literal></b> <br /><br />

            </div>
            <div class="synopsis">
                Genre(s): <b><asp:Literal ID="lblGenres" Text='<%# Eval("Genres[0]") %>' runat="server"></asp:Literal></b> <br /> <br />
                Cast(s): <b><asp:Literal ID="lblCasts" Text='<%# Eval("Cast[0].Name") %>' runat="server"></asp:Literal></b> <br /> <br />
            </div>
            <iframe 
            width="580" height="345"
            src='<%# DataBinder.Eval(Container.DataItem, "Links[0].Url", "http://www.youtube.com/v/{0}?version=3") %>'
            type="application/x-shockwave-flash">
            </iframe>
        </div>
        </ItemTemplate>
    </asp:Repeater>
    </div>
</asp:Content>

