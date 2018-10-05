using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Movies : System.Web.UI.Page
{
    Service service;
    RootObject movies;

    public int TotalCount
    {
        set { ViewState.Add("totalcount", value); }
        get { return (int)ViewState["totalcount"]; }
    }

    public int CurrentPage
    {
        set { ViewState.Add("currentPage", value); }
        get { return ViewState["currentPage"] == null ? 1 : (int)ViewState["currentPage"]; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        service = new Service();

        if (!Page.IsPostBack)
            FetchData(CurrentPage);
    }

    private void FetchData(int pageNumber)
    {
        try
        {
            string button = Session["button"] == null ? "" : Session["button"].ToString();

            if (!button.Equals(string.Empty))
            {
                switch (button)
                {
                    case "upcomingmovies":
                        Heading.Text = "Upcoming Movies";
                        TitleLabel.Text = "Upcoming Movies | Movie Genius";
                        movies = service.FindUpcomingMoviesList(1);
                        break;

                    case "popularmovies":
                        Heading.Text = "Popular Movies";
                        TitleLabel.Text = "Popular Movies | Movie Genius";
                        movies = service.FindPopularMovies(1);
                        break;

                    case "topratedmovies":
                        Heading.Text = "Top Rated Movies";
                        TitleLabel.Text = "Top Rated Movies | Movie Genius";
                        movies = service.FindTopRatedMovies(1);
                        break;

                    default://"intheatres":
                        Heading.Text = "In Theatres";
                        TitleLabel.Text = "In Theatres | Movie Genius";
                        movies = service.FindMoviesInTheaterList(pageNumber);
                        break;

                    //case "openingmovies":
                    //    Heading.Text = "Opening Movies";
                    //    TitleLabel.Text = "Opening Movies | Movie Genius";
                    //    movies = service.FindOpeningMovies();
                    //    break;

                    
                    
                    //default: 
                    //    Heading.Text = "Upcoming Movies";
                    //    TitleLabel.Text = "Upcoming Movies | Movie Genius";
                    //    movies = service.FindUpcomingMoviesList(10);
                    //    break;
                }

                PagedDataSource page = new PagedDataSource();
                page.AllowCustomPaging = true;
                page.AllowPaging = true;
                page.DataSource = movies.results.ToArray();
                page.PageSize = 10;
                MoviesRepeater.DataSource = page;
                MoviesRepeater.DataBind();

                if (!IsPostBack)
                {
                    TotalCount = movies.total_results;
                    CreatePagingControl();
                }
                else
                {
                    plcPaging.Controls.Clear();
                    CreatePagingControl();
                }
            }
            else
                Response.Redirect("Default.aspx");
        }
        catch (Exception) { }
    }

    private void CreatePagingControl()
    {
        if (CurrentPage > 1)
        {
            LinkButton lnk = new LinkButton();
            lnk.Click += new EventHandler(Paging_Click);
            lnk.ID = "previous";
            lnk.Text = "Previous";
            lnk.CommandArgument = (CurrentPage - 1).ToString();
            plcPaging.Controls.Add(lnk);
        }
        int itr = CurrentPage - 7 < 0 ? 0 : CurrentPage - 7;
        for (int i = itr; i < (TotalCount / 10) + 1; i++)
        {
            if (i + 1 == CurrentPage)
            {
                Label current = new Label();
                current.CssClass = "active_pagination_link";
                current.Text = (i + 1).ToString();
                plcPaging.Controls.Add(current);
            }
            else
            {
                LinkButton lnk = new LinkButton();
                lnk.Click += new EventHandler(Paging_Click);
                lnk.ID = "lnkPage" + (i + 1).ToString();
                lnk.Text = (i + 1).ToString();
                lnk.CommandArgument = (i + 1).ToString();
                plcPaging.Controls.Add(lnk);
            }
            if (i == itr + 15)
                break;
        }
        if (CurrentPage < (TotalCount / 10) + 1)
        {
            LinkButton lnk = new LinkButton();
            lnk.Click += new EventHandler(Paging_Click);
            lnk.ID = "next";
            lnk.Text = "Next";
            lnk.CommandArgument = (CurrentPage + 1).ToString();
            plcPaging.Controls.Add(lnk);
        }
    }

    void Paging_Click(object sender, EventArgs e)
    {
        LinkButton lnk = sender as LinkButton;
        CurrentPage = int.Parse(lnk.CommandArgument);
        FetchData(CurrentPage);
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
}
