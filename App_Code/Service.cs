using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Web;
using System.Net;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using Newtonsoft.Json.Linq;


public class Service 
{
    private const string LIST_BOX_OFFICE = @"http://api.rottentomatoes.com/api/public/v1.0/lists/movies/box_office.json?country=us&apikey={0}&page_limit=10";

    private const string LIST_IN_THEATERS = @"http://api.rottentomatoes.com/api/public/v1.0/lists/movies/in_theaters.json?apikey={0}&page={1}&page_limit=10";

    private const string LIST_UPCOMING = @"http://api.rottentomatoes.com/api/public/v1.0/lists/movies/upcoming.json?apikey={0}&page_limit=10";

    private const string LIST_CURRENT_DVD = @"http://api.rottentomatoes.com/api/public/v1.0/lists/dvds/current_releases.json?apikey={0}&page={1}&page_limit=10";

    private const string LIST_TOP_RENTALS_DVD = @"http://api.rottentomatoes.com/api/public/v1.0/lists/dvds/top_rentals.json?limit=10&country=us&apikey={0}";

    private const string LIST_NEW_RELEASE_DVD = @"http://api.rottentomatoes.com/api/public/v1.0/lists/dvds/new_releases.json?apikey={0}&page={1}&page_limit=10";

    private const string LIST_UPCOMING_DVD = @"http://api.rottentomatoes.com/api/public/v1.0/lists/dvds/upcoming.json?apikey={0}&page={1}&page_limit=10";

    private const string LIST_SEARCH_MOVIE = @"http://api.rottentomatoes.com/api/public/v1.0/movies.json?apikey={0}&q={1}&page_limit=10&page={2}";

    private const string LIST_OPENING_MOVIE = @"http://api.rottentomatoes.com/api/public/v1.0/lists/movies/opening.json?limit=16&country=us&apikey={0}";

    private const string MOVIE_INFO = @"http://api.rottentomatoes.com/api/public/v1.0/movies/{1}.json?apikey={0}";

    private const string MOVIE_REVIEWS = @"http://api.rottentomatoes.com/api/public/v1.0/movies/{0}/reviews.json?apikey={1}&page_limit=10";

    private const string MOVIE_SIMILAR = @"http://api.rottentomatoes.com/api/public/v1.0/movies/{0}/similar.json?apikey={1}&limit=5";


    public MovieSearchResults FindBoxOfficeList()
    {

        var url = string.Format(LIST_BOX_OFFICE, WebConfigurationManager.AppSettings["ApiKeyRT"]);
        string jsonResponse = GetJsonResponse(url);
        var results = Parser.ParseMovieSearchResults(jsonResponse);

        return results;
    }


    public MovieSearchResults FindMoviesInTheaterList(int page)
    {

        var url = string.Format(LIST_IN_THEATERS, WebConfigurationManager.AppSettings["ApiKeyRT"], page);
        string jsonResponse = GetJsonResponse(url);
        var results = Parser.ParseMovieSearchResults(jsonResponse);

        return results;
    }


    public MovieSearchResults FindUpcomingMoviesList()
    {

        var url = string.Format(LIST_UPCOMING, WebConfigurationManager.AppSettings["ApiKeyRT"]);
        var jsonResponse = GetJsonResponse(url);
        var results = Parser.ParseMovieSearchResults(jsonResponse);

        return results;
    }


    public MovieSearchResults FindTopRentalDVDs()
    {
        var url = string.Format(LIST_TOP_RENTALS_DVD, WebConfigurationManager.AppSettings["ApiKeyRT"]);
        var jsonResponse = GetJsonResponse(url);
        var results = Parser.ParseMovieSearchResults(jsonResponse);

        return results;

    }


    public MovieSearchResults FindCurrentDVDs(int page)
    {

        var url = string.Format(LIST_CURRENT_DVD, WebConfigurationManager.AppSettings["ApiKeyRT"], page);
        var jsonResponse = GetJsonResponse(url);
        var results = Parser.ParseMovieSearchResults(jsonResponse);

        return results;

    }


    public MovieSearchResults FindNewReleasedDVDs(int page)
    {

        var url = string.Format(LIST_NEW_RELEASE_DVD, WebConfigurationManager.AppSettings["ApiKeyRT"], page);
        var jsonResponse = GetJsonResponse(url);
        var results = Parser.ParseMovieSearchResults(jsonResponse);

        return results;

    }


    public MovieSearchResults FindOpeningMovies()
    {
        var url = string.Format(LIST_OPENING_MOVIE, WebConfigurationManager.AppSettings["ApiKeyRT"]);
        var jsonResponse = GetJsonResponse(url);
        var results = Parser.ParseMovieSearchResults(jsonResponse);

        return results;

    }


    public MovieSearchResults FindUpcomingDVDs(int page)
    {
        var url = string.Format(LIST_UPCOMING_DVD, WebConfigurationManager.AppSettings["ApiKeyRT"], page);
        var jsonResponse = GetJsonResponse(url);
        var results = Parser.ParseMovieSearchResults(jsonResponse);

        return results;

    }


    public MovieSearchResults SearchMovie(string MovieName, int page)
    {

        var url = string.Format(LIST_SEARCH_MOVIE, WebConfigurationManager.AppSettings["ApiKeyRT"], MovieName, page);
        var jsonResponse = GetJsonResponse(url);
        var results = Parser.ParseMovieSearchResults(jsonResponse);

        return results;
    }


    public Movie MovieInfo(int MovieID)
    {

        var url = string.Format(MOVIE_INFO, WebConfigurationManager.AppSettings["ApiKeyRT"], MovieID);
        var jsonResponse = GetJsonResponse(url);
        var results = Parser.ParseMovie(jsonResponse);

        return results;
    }


    public ReviewSearchResults MovieReviews(int MovieID)
    {
        var url = string.Format(MOVIE_REVIEWS, MovieID, WebConfigurationManager.AppSettings["ApiKeyRT"]);
        var jsonResponse = GetJsonResponse(url);
        var results = Parser.ParseReviewSearchResults(jsonResponse);

        return results;
    }


    public MovieSearchResults MovieSimilar(int MovieID)
    {
        var url = string.Format(MOVIE_SIMILAR, MovieID, WebConfigurationManager.AppSettings["ApiKeyRT"]);
        var jsonResponse = GetJsonResponse(url);
        var results = Parser.ParseMovieSearchResults(jsonResponse);

        return results;
    }


    public string MovieTrailer(string title)
    {
        
        

        var request = System.Net.WebRequest.Create("http://private-3d34-themoviedb.apiary.io/3/search/movie?api_key=" + WebConfigurationManager.AppSettings["ApiKeyMDB"] + "&query=" + title + "&append_to_response=trailers&page=1") as System.Net.HttpWebRequest;
        request.Method = "GET";
        request.Accept = "application/json";
        request.ContentLength = 0;
        string responseContent;

        using (var response = request.GetResponse() as System.Net.HttpWebResponse)
        {
            using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
            {
                responseContent = reader.ReadToEnd();


                JObject o = JObject.Parse(responseContent);

                var id =
                    from p in o["results"]
                    select (int)p["id"];


                var request2 = System.Net.WebRequest.Create("http://private-3d34-themoviedb.apiary.io/3/movie/" + id.First().ToString() + "/trailers?api_key=" + WebConfigurationManager.AppSettings["ApiKeyMDB"]) as System.Net.HttpWebRequest;
                request2.Method = "GET";
                request2.Accept = "application/json";
                request2.ContentLength = 0;
                using (var response2 = request2.GetResponse() as System.Net.HttpWebResponse)
                {
                    using (var reader2 = new System.IO.StreamReader(response2.GetResponseStream()))
                    {
                        responseContent = reader2.ReadToEnd();
                        o = JObject.Parse(responseContent);

                        var youtube =
                            from p in o["youtube"]
                            select (string)p["source"];

                        if (youtube.Count() > 0)
                            responseContent = youtube.First();
                        else responseContent = "";
                    }
                }


            }
        }
        return responseContent;

    }

    private static string GetJsonResponse(string url)
    {
        // stop from overusing API calls per second.
        System.Threading.Thread.Sleep(200);
        
        Stream clientstream;
        try
        {
            var client = new WebClient();
            clientstream = client.OpenRead(url);
            var responseStream = new System.IO.Compression.GZipStream(clientstream, CompressionMode.Decompress);
            var reader = new StreamReader(responseStream);
            return reader.ReadToEnd();

        }
        catch (Exception)
        {
            using (var client = new WebClient())
            {
                
                client.Encoding = Encoding.UTF8;
                return client.DownloadString(url);

            }
        }
    }

}