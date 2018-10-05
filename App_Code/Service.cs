using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Configuration;


public class Service
{
    private const string LIST_POPULAR = @"https://api.themoviedb.org/3/movie/popular?api_key={0}&language=en-US&page={1}";

    private const string LIST_TOP_RATED = @"https://api.themoviedb.org/3/movie/top_rated?api_key={0}&language=en-US&region=CA|US&page={1}";

    private const string LIST_IN_THEATERS = @"https://api.themoviedb.org/3/movie/now_playing?api_key={0}&language=en-US&page={1}"; //http://api.rottentomatoes.com/api/public/v1.0/lists/movies/in_theaters.json?apikey={0}&page={1}&page_limit=10";

    private const string LIST_UPCOMING = @"https://api.themoviedb.org/3/movie/upcoming?api_key={0}&language=en-US&region=CA|US&page={1}"; //http://api.rottentomatoes.com/api/public/v1.0/lists/movies/upcoming.json?apikey={0}&page_limit={1}";

    private const string MOVIE_INFO = @"https://api.themoviedb.org/3/movie/{1}?api_key={0}&language=en-US&append_to_response=credits,videos"; // http://api.rottentomatoes.com/api/public/v1.0/movies/{1}.json?apikey={0}";

    private const string LIST_RECOMMENDATIONS = @"https://api.themoviedb.org/3/movie/{2}/recommendations?api_key={0}&language=en-US&page={1}";

    private const string LIST_MULTI_SEARCH = @"https://api.themoviedb.org/3/search/movie?api_key={0}&language=en-US&query={2}&page={1}&include_adult=false"; // https://api.themoviedb.org/3/search/multi?api_key={0}&language=en-US&query={2}&page={1}&include_adult=false";

    //private const string LIST_BOX_OFFICE = @"http://api.rottentomatoes.com/api/public/v1.0/lists/movies/box_office.json?country=us&apikey={0}&page_limit=10";

    //private const string LIST_CURRENT_DVD = @"http://api.rottentomatoes.com/api/public/v1.0/lists/dvds/current_releases.json?apikey={0}&page={1}&page_limit=10";

    //private const string LIST_TOP_RENTALS_DVD = @"http://api.rottentomatoes.com/api/public/v1.0/lists/dvds/top_rentals.json?limit=10&country=us&apikey={0}";

    //private const string LIST_NEW_RELEASE_DVD = @"http://api.rottentomatoes.com/api/public/v1.0/lists/dvds/new_releases.json?apikey={0}&page={1}&page_limit=10";

    //private const string LIST_UPCOMING_DVD = @"http://api.rottentomatoes.com/api/public/v1.0/lists/dvds/upcoming.json?apikey={0}&page={1}&page_limit=10";

    //private const string LIST_SEARCH_MOVIE = @"http://api.rottentomatoes.com/api/public/v1.0/movies.json?apikey={0}&q={1}&page_limit=10&page={2}";

    //private const string LIST_OPENING_MOVIE = @"http://api.rottentomatoes.com/api/public/v1.0/lists/movies/opening.json?limit=16&country=us&apikey={0}";

    //private const string MOVIE_REVIEWS = @"http://api.rottentomatoes.com/api/public/v1.0/movies/{0}/reviews.json?apikey={1}&page_limit=10";

    //private const string MOVIE_SIMILAR = @"http://api.rottentomatoes.com/api/public/v1.0/movies/{0}/similar.json?apikey={1}&limit=5";


    public RootObject FindMultiSearch(int page, string searchText)
    {
        var url = string.Format(LIST_MULTI_SEARCH, WebConfigurationManager.AppSettings["ApiKeyTMDB"], page, searchText);
        string jsonResponse = GetJsonResponse(url);
        RootObject results = JsonConvert.DeserializeObject<RootObject>(jsonResponse);
        return results;
    }

    public RootObject FindRecommendations(int page, int id)
    {
        var url = string.Format(LIST_RECOMMENDATIONS, WebConfigurationManager.AppSettings["ApiKeyTMDB"], page, id);
        string jsonResponse = GetJsonResponse(url);
        RootObject results = JsonConvert.DeserializeObject<RootObject>(jsonResponse);
        return results;
    }


    public RootObject FindPopularMovies(int page)
    {

        var url = string.Format(LIST_POPULAR, WebConfigurationManager.AppSettings["ApiKeyTMDB"], page);
        string jsonResponse = GetJsonResponse(url);
        RootObject results = JsonConvert.DeserializeObject<RootObject>(jsonResponse);
        return results;
    }

    public RootObject FindTopRatedMovies(int page)
    {
        var url = string.Format(LIST_TOP_RATED, WebConfigurationManager.AppSettings["ApiKeyTMDB"], page);
        string jsonResponse = GetJsonResponse(url);
        RootObject results = JsonConvert.DeserializeObject<RootObject>(jsonResponse);
        return results;
    }

    public RootObject FindMoviesInTheaterList(int page)
    {
        var url = string.Format(LIST_IN_THEATERS, WebConfigurationManager.AppSettings["ApiKeyTMDB"], page);
        string jsonResponse = GetJsonResponse(url);
        RootObject results = JsonConvert.DeserializeObject<RootObject>(jsonResponse);
        return results;
    }


    public RootObject FindUpcomingMoviesList(int page)
    {
        var url = string.Format(LIST_UPCOMING, WebConfigurationManager.AppSettings["ApiKeyTMDB"], page);
        var jsonResponse = GetJsonResponse(url);
        RootObject results = JsonConvert.DeserializeObject<RootObject>(jsonResponse);
        return results;
    }


    public Result MovieInfo(int MovieID)
    {
        var url = string.Format(MOVIE_INFO, WebConfigurationManager.AppSettings["ApiKeyTMDB"], MovieID);
        var jsonResponse = GetJsonResponse(url);
        Result results = JsonConvert.DeserializeObject<Result>(jsonResponse);
        return results;
    }


    //public MovieObject FindBoxOfficeList()
    //{

    //    var url = string.Format(LIST_BOX_OFFICE, WebConfigurationManager.AppSettings["ApiKeyRT"]);
    //    string jsonResponse = GetJsonResponse(url);
    //    MovieObject results = JsonConvert.DeserializeObject<MovieObject>(jsonResponse);

    //    return results;
    //}


    //public MovieObject FindTopRentalDVDs()
    //{
    //    var url = string.Format(LIST_TOP_RENTALS_DVD, WebConfigurationManager.AppSettings["ApiKeyRT"]);
    //    var jsonResponse = GetJsonResponse(url);
    //    MovieObject results = JsonConvert.DeserializeObject<MovieObject>(jsonResponse);

    //    return results;

    //}


    //public MovieObject FindCurrentDVDs(int page)
    //{

    //    var url = string.Format(LIST_CURRENT_DVD, WebConfigurationManager.AppSettings["ApiKeyRT"], page);
    //    var jsonResponse = GetJsonResponse(url);
    //    MovieObject results = JsonConvert.DeserializeObject<MovieObject>(jsonResponse);

    //    return results;

    //}


    //public MovieObject FindNewReleasedDVDs(int page)
    //{

    //    var url = string.Format(LIST_NEW_RELEASE_DVD, WebConfigurationManager.AppSettings["ApiKeyRT"], page);
    //    var jsonResponse = GetJsonResponse(url);
    //    MovieObject results = JsonConvert.DeserializeObject<MovieObject>(jsonResponse);

    //    return results;

    //}


    //public MovieObject FindOpeningMovies()
    //{
    //    var url = string.Format(LIST_OPENING_MOVIE, WebConfigurationManager.AppSettings["ApiKeyRT"]);
    //    var jsonResponse = GetJsonResponse(url);
    //    MovieObject results = JsonConvert.DeserializeObject<MovieObject>(jsonResponse);

    //    return results;

    //}


    //public MovieObject FindUpcomingDVDs(int page)
    //{
    //    var url = string.Format(LIST_UPCOMING_DVD, WebConfigurationManager.AppSettings["ApiKeyRT"], page);
    //    var jsonResponse = GetJsonResponse(url);
    //    MovieObject results = JsonConvert.DeserializeObject<MovieObject>(jsonResponse);

    //    return results;

    //}


    //public MovieObject SearchMovie(string MovieName, int page)
    //{

    //    var url = string.Format(LIST_SEARCH_MOVIE, WebConfigurationManager.AppSettings["ApiKeyRT"], MovieName, page);
    //    var jsonResponse = GetJsonResponse(url);
    //    MovieObject results = JsonConvert.DeserializeObject<MovieObject>(jsonResponse);

    //    return results;
    //}


    ////public ReviewSearchResults MovieReviews(int MovieID)
    ////{
    ////    var url = string.Format(MOVIE_REVIEWS, MovieID, WebConfigurationManager.AppSettings["ApiKeyRT"]);
    ////    var jsonResponse = GetJsonResponse(url);
    ////    ReviewSearchResults results = JsonConvert.DeserializeObject<ReviewSearchResults>(jsonResponse);

    ////    return results;
    ////}


    //public MovieObject MovieSimilar(int MovieID)
    //{
    //    var url = string.Format(MOVIE_SIMILAR, MovieID, WebConfigurationManager.AppSettings["ApiKeyRT"]);
    //    var jsonResponse = GetJsonResponse(url);

    //    MovieObject results = JsonConvert.DeserializeObject<MovieObject>(jsonResponse);

    //    return results;
    //}


    //public string MovieTrailer(string title, int Year)
    //{



    //    var request = System.Net.WebRequest.Create("http://private-3d34-themoviedb.apiary.io/3/search/movie?api_key=" + WebConfigurationManager.AppSettings["ApiKeyMDB"] + "&query=" + title + "&append_to_response=trailers&page=1") as System.Net.HttpWebRequest;
    //    request.Method = "GET";
    //    request.Accept = "application/json";
    //    request.ContentLength = 0;
    //    string responseContent;

    //    using (var response = request.GetResponse() as System.Net.HttpWebResponse)
    //    {
    //        using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
    //        {
    //            responseContent = reader.ReadToEnd();

    //            MovieVideo result = JsonConvert.DeserializeObject<MovieVideo>(responseContent);
    //            DateTime d = new DateTime(Year, 1, 1);
    //            var id = result.results.Find(p => DateTime.Parse(p.release_date).Year == d.Year).id;

    //            var request2 = System.Net.WebRequest.Create("http://private-3d34-themoviedb.apiary.io/3/movie/" + id.ToString() + "/trailers?api_key=" + WebConfigurationManager.AppSettings["ApiKeyMDB"]) as System.Net.HttpWebRequest;
    //            request2.Method = "GET";
    //            request2.Accept = "application/json";
    //            request2.ContentLength = 0;
    //            using (var response2 = request2.GetResponse() as System.Net.HttpWebResponse)
    //            {
    //                using (var reader2 = new System.IO.StreamReader(response2.GetResponseStream()))
    //                {
    //                    responseContent = reader2.ReadToEnd();
    //                    var o2 = JObject.Parse(responseContent);

    //                    var youtube =
    //                        from p in o2["youtube"]
    //                        select (string)p["source"];

    //                    if (youtube.Count() > 0)
    //                        responseContent = youtube.First();
    //                    else responseContent = "";
    //                }
    //            }


    //        }
    //    }
    //    return responseContent;

    //}

    private static string GetJsonResponse(string url)
    {
        //// stop from overusing API calls per second.
        //System.Threading.Thread.Sleep(300);

        //Stream clientstream;
        //try
        //{
        //    clientstream = client.OpenRead(url);
        //    var responseStream = new System.IO.Compression.GZipStream(clientstream, CompressionMode.Decompress);
        //    var reader = new StreamReader(responseStream);
        //    var text = reader.ReadToEnd();
        //    return text;

        //}
        //catch (Exception)
        //{
        using (var client = new WebClient())
        {

            client.Encoding = Encoding.UTF8;
            return client.DownloadString(url);

        }
        // }
    }

}