using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;

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


                List<Movie> details = new List<Movie>();

                movie = service.MovieInfo(MovieID);

                TitleLabel.Text = movie.Title + " | Movie Genius";
                

                if (movie.Genres.Count > 0)
                {
                    string genres = "";
                    for (int i = 0; i < movie.Genres.Count; i++)
                    {
                        genres += movie.Genres[i];
                        if (i + 1 < movie.Genres.Count)
                            genres += ", ";
                    }
                    movie.Genres[0] = genres;
                }
                else
                    movie.Genres.Add("");

                if (movie.Directors.Count > 0)
                {
                    string directors = "";
                    for (int i = 0; i < movie.Directors.Count; i++)
                    {
                        directors += movie.Directors[i];
                        if (i + 1 < movie.Directors.Count)
                            directors += ", ";
                    }
                    movie.Directors[0] = directors;
                }
                else
                    movie.Directors.Add("");

                if (movie.Cast.Count > 0)
                {
                    string cast = "";
                    for (int i = 0; i < movie.Cast.Count; i++)
                    {
                        cast += movie.Cast[i].Name;
                        if (i + 1 < movie.Cast.Count)
                            cast += ", ";
                    }
                    movie.Cast[0].Name = cast;
                }
                else
                {
                    movie.Cast.Add(new CastMember());
                    movie.Cast[0].Name = "";
                }



                string youtubeLink = service.MovieTrailer(movie.Title);

                movie.Links[0].Url = PrepareURL(Server.UrlPathEncode(youtubeLink));
                details.Add(movie);
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