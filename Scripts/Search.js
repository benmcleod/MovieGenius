/// <reference path="jquery-1.11.0.min.js" />

var apikey = "xv4ug7nk4rcppc29jjak36pp";

$(document).ready(function () {
    var searchField = $('[id$=searchText]');
    searchField.autocomplete({
        source: function (request, response) {
            $.ajax("http://api.rottentomatoes.com/api/public/v1.0/movies.json", {
                data: {
                    apikey: apikey,
                    page_limit: 5,
                    q: request.term
                },
                dataType: "jsonp",
                success: function (data) {
                    response($.map(data.movies, function (movie) {
                        return {
                            label: movie.title,
                            thumb: movie.posters.thumbnail,
                            id: movie.id,
                            year: movie.year,
                            cast: movie.abridged_cast,
                            rating: movie.ratings.audience_score
                        }
                    }));
                }
            });
        },
        minLength: 2,
        select: function (event, ui) {

            $.ajax({
                type: "POST",
                url: "Search.svc/addSession",
                data: '{"movieID":"' + ui.item.id + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    window.location.href = "MovieDetails.aspx";
                },
                error: function (err) {
                    alert(err.status + "    " + err.statusText);
                }
            });
        },
        open: function () {
            $(this).autocomplete("widget").css({
                "width": 350,
                "left": 850
            });
        }
    });
    searchField.data("ui-autocomplete")._renderMenu = function (ul, items) {
        var that = this;

        ul.prepend("<li>Movies<li>");

        $.each(items, function (index, item) {
            that._renderItemData(ul, item);

        });
    }

    searchField.data("ui-autocomplete")._renderItem = function (ul, item) {
        var li = $("<li>");

        if (item.label) {
            var a = $('<a style="width:335px">');

            if (item.thumb) {
                $('<img width=\"34\" height=\"50\">').addClass("thumb").attr('src', item.thumb).appendTo(a);
            }
            if (item.rating) {
                $('<span>').addClass('rating').text(item.rating).appendTo(a);
            }

            $('<div style="clear:both">').addClass("searchcenter").appendTo(a);

            if (item.label) {
                $('<span>').addClass('searchtitle').text(item.label + " (" + item.year + ")").appendTo(a);
            }

            $('</br>').appendTo(a);

            if (item.cast) {
                $('<span>').addClass('cast').text(item.cast[0].name + ", " + item.cast[1].name).appendTo(a);
            }

            $('</div>').appendTo(a);

            a.appendTo(li);
        }
        else {
            $('<a>').html(item.label).appendTo(li);
        }
        return li.appendTo(ul);
    };

});