using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Diagnostics;


public static class Parser
{
    public static Review ParseReview(string json)
    {
        JObject jObject = JObject.Parse(json);
        Review review = new Review();

        review.critic = ParseCritic(jObject["critic"]);
        review.date = ParseDate(jObject["date"]);
        review.freshness = ParseFreshness(jObject["freshness"]);
        review.publication = ParsePublication(jObject["publication"]);
        review.quote = ParseQuote(jObject["quote"]);
        review.Links = ParseLinks(jObject["links"]);

        return review;


    }

    private static string ParseQuote(JToken jToken)
    {
        return jToken.Value<string>();
    }

    private static string ParsePublication(JToken jToken)
    {
        return jToken.Value<string>();
    }

    private static string ParseFreshness(JToken jToken)
    {
        return jToken.Value<string>();
    }

    private static string ParseDate(JToken jToken)
    {
        return jToken.Value<string>();
    }

    private static string ParseCritic(JToken jToken)
    {
        return jToken.Value<string>();
    }

    public static Movie ParseMovie(string json)
    {
        JObject jObject = JObject.Parse(json);
        Movie movie = new Movie();

        movie.RottenTomatoesId = ParseRottenTomatoesId(jObject["id"]);
        movie.Title = ParseTitle(jObject["title"]);
        movie.Year = ParseYear(jObject["year"]);
        movie.MpaaRating = ParseMpaaRating(jObject["mpaa_rating"]);
        movie.Runtime = ParseRunTime(jObject["runtime"]);
        movie.Synopsis = ParseSynopsis(jObject["synopsis"]);
        movie.Directors = ParseDirectors(jObject["abridged_directors"]);
        movie.Genres = ParseGenres(jObject["genres"]);
        movie.Cast = ParseCastMembers(jObject["abridged_cast"]);
        movie.Links = ParseLinks(jObject["links"]);
        movie.Posters = ParsePosters(jObject["posters"]);
        movie.Ratings = ParseRatings(jObject["ratings"]);
        movie.ReleaseDates = ParseReleaseDates(jObject["release_dates"]);

        return movie;
    }

    public static ReviewSearchResults ParseReviewSearchResults(string json)
    {
        JObject jObject = JObject.Parse(json);

        var result = new ReviewSearchResults();

        if (jObject["total"] != null)
            result.TotalCount = (int)jObject["total"];

        var reviews = (JArray)jObject["reviews"];
        if (reviews != null)
        {
            foreach (var review in reviews)
            {
                Review r = ParseReview(review.ToString());
                result.Add(r);
            }
        }

        return result;
    }


    public static MovieSearchResults ParseMovieSearchResults(string json)
    {
        JObject jObject = JObject.Parse(json);

        var result = new MovieSearchResults();

        if (jObject["total"] != null)
            result.ResultCount = (int)jObject["total"];

        var movies = (JArray)jObject["movies"];
        if (movies != null)
        {
            foreach (var movie in movies)
            {
                Movie m = ParseMovie(movie.ToString());
                m.SiblingsCount = result.ResultCount;
                result.Add(m);
            }
        }

        return result;
    }

    private static List<ReleaseDate> ParseReleaseDates(JToken jToken)
    {
        List<ReleaseDate> releaseDates = new List<ReleaseDate>();
        var jsonArray = (JObject)jToken;

        if (jsonArray == null)
            return releaseDates;

        foreach (var releaseDate in jsonArray)
        {
            ReleaseDate newDate = new ReleaseDate();
            newDate.Type = (string) releaseDate.Key;

            var tmpDate = ((string)releaseDate.Value).Substring(0, ((string)releaseDate.Value).Count());
            newDate.Date = DateTime.Parse(tmpDate);
                
            releaseDates.Add(newDate);
        }

        return releaseDates;
    }

    private static List<Rating> ParseRatings(JToken jToken)
    {
        List<Rating> ratings = new List<Rating>();
        var jsonArray = (JObject)jToken;

        if (jsonArray == null)
            return ratings;

        foreach (var rating in jsonArray)
        {
            Rating newRating = new Rating() { Type = (string)rating.Key, Score = rating.Value.ToString()=="-1" ? "Not Yet" : (string)rating.Value.ToString() };
            ratings.Add(newRating);
        }

        return ratings;
    }

    private static List<Poster> ParsePosters(JToken jToken)
    {
        List<Poster> posters = new List<Poster>();
        var jsonArray = (JObject)jToken;

        if (jsonArray == null)
            return posters;

        foreach (var poster in jsonArray)
        {
            Poster newPoster = new Poster() { Type = (string)poster.Key, Url = (string)poster.Value };
            posters.Add(newPoster);
        }

        return posters;
    }

    private static List<Link> ParseLinks(JToken jToken)
    {
        List<Link> links = new List<Link>();
        var jsonArray = (JObject) jToken;

        if (jsonArray == null)
            return links;

        foreach (var link in jsonArray)
        {
            Link newLink = new Link {Type = (string) link.Key, Url = (string) link.Value};
            links.Add(newLink);
        }

        return links;
    }

    private static List<CastMember> ParseCastMembers(JToken jToken)
    {
        List<CastMember> cast = new List<CastMember>();
        var jsonArray = (JArray) jToken;

        if (jsonArray == null)
            return cast;

        foreach (var castMember in jsonArray)
        {
            CastMember member = new CastMember();
            member.Name = (string)castMember["name"];

            var characters = (JArray) castMember["characters"];
            if (characters != null)
            {
                foreach (var character in characters)
                {
                    member.Characters.Add((string) character);
                }
            }

            cast.Add(member);
        }

        return cast;
    }

    private static List<string> ParseGenres(JToken jToken)
    {
        List<string> genres = new List<string>();
        var jsonArray = (JArray) jToken;

        if (jsonArray == null)
            return genres;

        genres.AddRange(jsonArray.Select(genre => (string) genre));
        return genres;
    }

    private static List<string> ParseDirectors(JToken jToken)
    {
        List<string> directors = new List<string>();
        var jsonArray = (JArray) jToken;

        if (jsonArray == null) 
            return directors;

        directors.AddRange(jsonArray.Select(director => (string) director["name"]));
        return directors;
    }

    private static string ParseSynopsis(JToken jToken)
    {
        return jToken.Value<string>();
    }

    private static int? ParseRunTime(JToken jToken)
    {
        return jToken.Value<string>() == String.Empty ? -1 : jToken.Value<int>();
    }

    private static string ParseMpaaRating(JToken jToken)
    {
        return jToken == null ? String.Empty : jToken.Value<string>();
    }

    private static int ParseYear(JToken jToken)
    {
        return jToken.Value<string>() == String.Empty ? -1 : jToken.Value<int>();
    }

    private static string ParseTitle(JToken jToken)
    {
        return jToken.Value<string>();
    }

    private static int ParseRottenTomatoesId(JToken jToken)
    {
        return jToken.Value<int>();
    }
}
