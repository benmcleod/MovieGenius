using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

public partial class MovieDetails : System.Web.UI.Page
{
    Service service;
    Result movie;

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

                //if (movie.genres.Count > 0)
                //{
                //    // Add ", " inbetween each genre
                //    movie.genres[0].name = string.Join(", ", movie.genres);
                //}
                //else {
                //    movie.genres.Add(new Genre());
                //}
                //if (movie.abridged_directors.Count > 0)
                //{
                //    // Add ", " inbetween each director
                //    movie.abridged_directors[0].name = string.Join(", ", movie.abridged_directors.ConvertAll(m => m.name).ToArray());
                //}
                //else
                //{
                //    movie.abridged_directors.Add(new AbridgedDirector());
                //    movie.abridged_directors[0].name = "";
                //}

                //if (movie.credits.cast.Count > 0)
                //{
                //    // Add ", " inbetween each cast member
                //    movie.credits.cast[0].name = string.Join(", ", movie.credits.cast.ConvertAll(m => m.name).ToArray());
                //}
                //else
                //{
                //    //movie.credits.cast.Add(new AbridgedCast());
                //    movie.credits.cast[0].name = "";
                //}

                //string youtubeLink = service.MovieTrailer(movie.title, movie.year);
                //movie.links.self = PrepareURL(Server.UrlPathEncode(youtubeLink));

                List<Result> details = new List<Result>(1) { movie };
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

    protected static string GetDirector(Credits credits)
    {
        List<string> directors = new List<string>();
        directors = credits.crew.FindAll(x => x.job.Equals("Director")).Select(x => x.name).ToList();

        return string.Join(", ", directors);
    }

    protected static string GetCast(Credits credits)
    {
        List<string> cast = new List<string>();
        cast = credits.cast.Select(x => x.name).ToList();

        return string.Join(", ", cast);
    }

    protected static string GetGenre(List<Genre> genre)
    {

        return string.Join(", ", genre.Select(x => x.name));
    }

    protected static string GetVideo(Videos videos)
    {
        return "https://www.youtube.com/embed/" + videos.results.First().key;
    }

    
}