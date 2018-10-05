using System;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    Service service;
    RootObject movieObject;

    protected void Page_Load(object sender, EventArgs e)
    {
        TitleLabel.Text = "Movie Genius";

        service = new Service();

        movieObject = service.FindPopularMovies(1);

        FeaturedRepeater.DataSource = movieObject.results;
        FeaturedRepeater.DataBind();

        FetchData(CurrentPage);
    }

    private void FetchData(int pageNumber)
    {
        try
        {
            movieObject = service.FindMoviesInTheaterList(pageNumber);

            PagedDataSource page = new PagedDataSource();
            page.AllowCustomPaging = true;
            page.AllowPaging = true;
            page.DataSource = movieObject.results;
            page.PageSize = 10;
            MoviesRepeater.DataSource = page;
            MoviesRepeater.DataBind();

            if (!IsPostBack)
            {
                TotalCount = movieObject.total_results;
                CreatePagingControl();
            }
            else
            {
                plcPaging.Controls.Clear();
                CreatePagingControl();
            }
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
        if (CurrentPage < (TotalCount / 10)+1)
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

}
