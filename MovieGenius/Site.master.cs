using System;
using System.Web.UI.WebControls;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    Service service;
    RootObject movieObject;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            service = new Service();

            movieObject = service.FindTopRatedMovies(1);

            grdTopRated.DataSource = movieObject.results;
            grdTopRated.DataBind();

            movieObject = service.FindUpcomingMoviesList(1);

            GridView1.DataSource = movieObject.results.GetRange(0,5);
            GridView1.DataBind();
            
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
