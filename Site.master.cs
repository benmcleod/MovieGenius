using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    Service service;

    protected void Page_Load(object sender, EventArgs e)
    {
        service = new Service();
        Movie[] movies;
        
        List<GeniusMovie> boxoffice = new List<GeniusMovie>();
        movies = service.FindBoxOfficeList().ToArray();
        
        for(int i = 0;i < 10;i++)
        {
            boxoffice.Add(new GeniusMovie(i+1,movies[i].RottenTomatoesId,movies[i].Title));
        }

        grdBoxOffice.DataSource = boxoffice;
        if (!IsPostBack) grdBoxOffice.DataBind();


        List<GeniusMovie> upcoming = new List<GeniusMovie>();
        movies = service.FindUpcomingMoviesList().ToArray();

        for (int i = 0; i < 5; i++)
        {
            upcoming.Add(new GeniusMovie(
                movies[i].RottenTomatoesId,
                movies[i].Title, movies[i].Posters[0].Url,
                movies[i].ReleaseDates[0].Date.ToShortDateString(),
                movies[i].MpaaRating,
                movies[i].Runtime.ToString()
                ));
        }

        GridView1.DataSource = upcoming;
        if (!IsPostBack) GridView1.DataBind();

        List<DVDRow> dvdRow = new List<DVDRow>();
        movies = service.FindNewReleasedDVDs(1).ToArray();

        for(int i = 0; i < 9; i+=3)
        {
            dvdRow.Add(
                new DVDRow(
                    movies[i].Posters[0].Url, movies[i].RottenTomatoesId,
                    movies[i+1].Posters[0].Url, movies[i+1].RottenTomatoesId,
                    movies[i+2].Posters[0].Url, movies[i+2].RottenTomatoesId
                    ));
        }

        GridViewNewReleasedDVDs.DataSource = dvdRow;
        if (!IsPostBack) GridViewNewReleasedDVDs.DataBind();
    }

    class GeniusMovie
    {
        public int Ranking { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Poster { get; set; }
        public string ReleaseDate { get; set; }
        public string Rating { get; set; }
        public string Runtime { get; set; }

        public GeniusMovie(int ranking, int id, string name)
        {
            this.Ranking = ranking;
            this.Id = id;
            this.Name = name;
        }

        public GeniusMovie(int id, string name, string poster, string releaseDate, string rating, string runtime)
        {
            this.Id = id;
            this.Name = name;
            this.Poster = poster;
            this.ReleaseDate = releaseDate;
            this.Rating = rating;
            this.Runtime = runtime;
        }
    }

    class DVDRow
    {
        public string RowImage1 { get; set; }
        public string RowImage2 { get; set; }
        public string RowImage3 { get; set; }
        public int RowImage1ID { get; set; }
        public int RowImage2ID { get; set; }
        public int RowImage3ID { get; set; }

        public DVDRow(string RowImage1, int RowImage1ID, string RowImage2, int RowImage2ID, string RowImage3, int RowImage3ID)
        {
            this.RowImage1 = RowImage1;
            this.RowImage2 = RowImage2;
            this.RowImage3 = RowImage3;
            this.RowImage1ID = RowImage1ID;
            this.RowImage2ID = RowImage2ID;
            this.RowImage3ID = RowImage3ID;
        }
    }

    //protected void grdBoxOffice_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        var secondCell = e.Row.Cells[1];
    //        secondCell.Controls.Clear();
    //        secondCell.Controls.Add(new HyperLink { NavigateUrl = secondCell.Text, Text = secondCell.Text });
    //    }
    //}

    protected void LinkButton_Click(object sender, EventArgs e)
    {
        LinkButton button = sender as LinkButton;
        Session.Add("button", button.CommandArgument.Trim());
        Response.Redirect("movies.aspx");
    }

    protected void ViewDetails_Click(object sender, EventArgs e)
    {
        using (StreamWriter writer = new StreamWriter(@"c:\test\debug.txt", true))
        {
            writer.WriteLine(DateTime.Now.ToString() + "click");
        }
        LinkButton button = sender as LinkButton;
        if (sender is LinkButton)
            Session.Add("movieID", ((LinkButton)sender).CommandArgument.Trim());
        else if (sender is ImageButton)
            Session.Add("movieID", ((ImageButton)sender).CommandArgument.Trim());
        Response.Redirect("MovieDetails.aspx");
    }
    protected void searchButton_Click(object sender, EventArgs e)
    {
        Session.Add("search", searhText.Text.Trim());
        Response.Redirect("SearchResults.aspx");
    }
}
