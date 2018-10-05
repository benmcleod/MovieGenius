using System;
using System.Collections.Generic;
public class Genre
{
    public int id { get; set; }
    public string name { get; set; }
}

public class ProductionCompany
{
    public int id { get; set; }
    public string logo_path { get; set; }
    public string name { get; set; }
    public string origin_country { get; set; }
}

public class ProductionCountry
{
    public string iso_3166_1 { get; set; }
    public string name { get; set; }
}

public class SpokenLanguage
{
    public string iso_639_1 { get; set; }
    public string name { get; set; }
}

public class Cast
{
    public int cast_id { get; set; }
    public string character { get; set; }
    public string credit_id { get; set; }
    public int gender { get; set; }
    public int id { get; set; }
    public string name { get; set; }
    public int order { get; set; }
    public string profile_path { get; set; }
}

public class Crew
{
    public string credit_id { get; set; }
    public string department { get; set; }
    public int gender { get; set; }
    public int id { get; set; }
    public string job { get; set; }
    public string name { get; set; }
    public string profile_path { get; set; }
}

public class Credits
{
    public List<Cast> cast { get; set; }
    public List<Crew> crew { get; set; }
}


public class Videos
{
    public List<Result> results { get; set; }
}

public class Result
{
    public string id { get; set; }
    public string iso_639_1 { get; set; }
    public string iso_3166_1 { get; set; }
    public string key { get; set; }
    public string name { get; set; }
    public string site { get; set; }
    public int size { get; set; }
    public string type { get; set; }
    public bool adult { get; set; }
    public string backdrop_path { get; set; }
    public object belongs_to_collection { get; set; }
    public int budget { get; set; }
    public List<Genre> genres { get; set; }
    public string homepage { get; set; }
    public string imdb_id { get; set; }
    public string original_language { get; set; }
    public string original_title { get; set; }
    public string overview { get; set; }
    public double popularity { get; set; }
    public string poster_path { get; set; }
    public List<ProductionCompany> production_companies { get; set; }
    public List<ProductionCountry> production_countries { get; set; }
    public string release_date { get; set; }
    public int revenue { get; set; }
    public int runtime { get; set; }
    public List<SpokenLanguage> spoken_languages { get; set; }
    public string status { get; set; }
    public string tagline { get; set; }
    public string title { get; set; }
    public bool video { get; set; }
    public double vote_average { get; set; }
    public int vote_count { get; set; }
    public Credits credits { get; set; }
    public List<int> genre_ids { get; set; }
    public Videos videos { get; set; }
}

public class Dates
{
    public string maximum { get; set; }
    public string minimum { get; set; }
}

public class RootObject
{
    public List<Result> results { get; set; }
    public int page { get; set; }
    public int total_results { get; set; }
    public Dates dates { get; set; }
    public int total_pages { get; set; }
}

//public class ReleaseDates
//{
//    public DateTime theater { get; set; }
//    public DateTime dvd { get; set; }
//}

//public class Ratings
//{
//    public string critics_rating { get; set; }
//    public int critics_score { get; set; }
//    public string audience_rating { get; set; }
//    public int audience_score { get; set; }
//}

//public class Posters
//{
//    public string thumbnail { get; set; }
//    public string profile { get; set; }
//    public string detailed { get; set; }
//    public string original { get; set; }
//}

//public class AbridgedCast
//{
//    public string name { get; set; }
//    public string id { get; set; }
//    public List<string> characters { get; set; }
//}

//public class AbridgedDirector
//{
//    public string name { get; set; }
//}

//public class AlternateIds
//{
//    public string imdb { get; set; }
//}

//public class Links
//{
//    public string self { get; set; }
//    public string alternate { get; set; }
//    public string cast { get; set; }
//    public string clips { get; set; }
//    public string reviews { get; set; }
//    public string similar { get; set; }
//}

//public class Movie
//{
//    public int id { get; set; }
//    public string title { get; set; }
//    public int year { get; set; }
//    public List<string> genres { get; set; }
//    public string mpaa_rating { get; set; }
//    public int runtime { get; set; }
//    public string critics_consensus { get; set; }
//    public ReleaseDates release_dates { get; set; }
//    public Ratings ratings { get; set; }
//    public string synopsis { get; set; }
//    public Posters posters { get; set; }
//    public List<AbridgedCast> abridged_cast { get; set; }
//    public List<AbridgedDirector> abridged_directors { get; set; }
//    public string studio { get; set; }
//    public AlternateIds alternate_ids { get; set; }
//    public Links links { get; set; }
//}

//public class Links2
//{
//    public string self { get; set; }
//    public string next { get; set; }
//}

//public class MovieObject
//{
//    public int total { get; set; }
//    public List<Movie> movies { get; set; }
//    public Links2 links { get; set; }
//    public string link_template { get; set; }
//}