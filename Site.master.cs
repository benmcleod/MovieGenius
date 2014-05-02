using System;
using System.Web.UI.WebControls;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    Service service;
    MovieObject movieObject;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            service = new Service();

            movieObject = service.FindBoxOfficeList();

            grdBoxOffice.DataSource = movieObject.movies;
            grdBoxOffice.DataBind();

            movieObject = service.FindUpcomingMoviesList(5);

            GridView1.DataSource = movieObject.movies;
            GridView1.DataBind();

            movieObject = service.FindNewReleasedDVDs(1);
            movieObject.movies.RemoveAt(9);


            ListViewNewReleasedDVDs.DataSource = movieObject.movies;
            ListViewNewReleasedDVDs.DataBind();
        }
    }

    protected void LinkButton_Click(object sender, EventArgs e)
    {
        LinkButton button = sender as LinkButton;
        Session.Add("button", button.CommandArgument.Trim());
        Response.Redirect("movies.aspx");
    }

    protected void ViewDetails_Click(object sender, EventArgs e)
    {
        LinkButton button = sender as LinkButton;
        if (sender is LinkButton)
            Session.Add("movieID", ((LinkButton)sender).CommandArgument.Trim());
        else if (sender is ImageButton)
            Session.Add("movieID", ((ImageButton)sender).CommandArgument.Trim());
        Response.Redirect("MovieDetails.aspx");
    }

    protected void searchButton_Click(object sender, EventArgs e)
    {
        Session.Add("search", searchText.Text.Trim());
        Response.Redirect("SearchResults.aspx");
    }
}
