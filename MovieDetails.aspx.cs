using System;
using System.Collections.Generic;
using System.Web.UI;

public partial class MovieDetails : System.Web.UI.Page
{
    Service service;
    Movie movie;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            try
            {
                int MovieID = Session["MovieID"] == null ? 0 : Convert.ToInt32(Session["MovieID"]);

                if (MovieID == 0)
                {
                    lblNoMovieSelected.Text = "No Movie Selected";
                    return;
                }
                service = new Service();
                movie = service.MovieInfo(MovieID);

                TitleLabel.Text = movie.title + " | Movie Genius";

                if (movie.genres.Count > 0)
                {
                    // Add ", " inbetween each genre
                    movie.genres[0] = string.Join(", ", movie.genres.ToArray());
                }
                else
                    movie.genres.Add("");

                if (movie.abridged_directors.Count > 0)
                {
                    // Add ", " inbetween each director
                    movie.abridged_directors[0].name = string.Join(", ", movie.abridged_directors.ConvertAll(m => m.name).ToArray());
                }
                else
                {
                    movie.abridged_directors.Add(new AbridgedDirector());
                    movie.abridged_directors[0].name = "";
                }

                if (movie.abridged_cast.Count > 0)
                {
                    // Add ", " inbetween each cast member
                    movie.abridged_cast[0].name = string.Join(", ", movie.abridged_cast.ConvertAll(m => m.name).ToArray());
                }
                else
                {
                    movie.abridged_cast.Add(new AbridgedCast());
                    movie.abridged_cast[0].name = "";
                }

                string youtubeLink = service.MovieTrailer(movie.title, movie.year);
                movie.links.self = PrepareURL(Server.UrlPathEncode(youtubeLink));

                List<Movie> details = new List<Movie>(1){movie};
                //details.Add(movie);

                MoviesRepeater.DataSource = details;
                MoviesRepeater.DataBind();

            }
            catch (Exception)
            {
            }
        }
    }

    public string PrepareURL(string value)
    {
        value = value.Replace("'", "&#39;");
        return value;
    }
}