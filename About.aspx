<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="About.aspx.cs" Inherits="About" %>
    
       
<asp:Content ContentPlaceHolderID="TitleContentPlaceHolder" runat="server" ID="TitleContent">
    <asp:Literal runat="server" ID="TitleLabel"></asp:Literal>
</asp:Content>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        About Us
    </h2>
    <p>
        Welcome to the <strong>Movie Genius</strong>. Our goal is simple: we want to help you to 
        keep updated with upcoming movies and movies in theater. We believe 
        the more you know about upcoming movies the better you can plan to watch it 
        with your friends or family. We also provide you with comments and reviews about 
        each movie along with their offical trailer. </p>
       <br />
          <b> How we can help</b>
    <p>Following are the key features of our website.
       </p>
       <ul >
       <li class="lis">UpComing Movies</li>
       <li class="lis">Opening Movies</li>
       <li class="lis">Movies In Theater</li>
       <li class="lis">Watch Official Trailer</li>
       <li class="lis">See Users Reviews And Rating</li>
       <li class="lis">DVD's Rental</li>
       </ul>

       <div id="three-columns_new">
        <h2>Creators</h2>
        <p>Chirag Agrawal </p>
        <p>Ben Mcleod </p>
        <p>Ayyub Junior Morgan </p>
    </p>
</asp:Content>
