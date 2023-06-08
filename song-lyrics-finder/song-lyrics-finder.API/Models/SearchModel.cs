using System.Text.Json.Serialization;

namespace song_lyrics_finder.API.Models
{
    public class SearchModel
    {

        public class Rootobject
        {
            public Meta? meta { get; set; }
            public Response? response { get; set; }
        }

        public class Meta
        {
            public int status { get; set; }
        }

        public class Response
        {
            public Hit[]? hits { get; set; }
        }

        public class Hit
        {
            public object[]? highlights { get; set; }
            public string? index { get; set; }
            public string? type { get; set; }
            public Result? result { get; set; }
        }

        public class Result
        {
            public string? _type { get; set; }
            public int annotation_count { get; set; }
            public string? api_path { get; set; }
            public string? artist_names { get; set; }
            public string? full_title { get; set; }
            public string? header_image_thumbnail_url { get; set; }
            public string? header_image_url { get; set; }
            public int id { get; set; }
            public bool instrumental { get; set; }
            public int lyrics_owner_id { get; set; }
            public string? lyrics_state { get; set; }
            public int lyrics_updated_at { get; set; }
            public string? path { get; set; }
            public int pyongs_count { get; set; }
            public string? song_art_image_thumbnail_url { get; set; }
            public string? song_art_image_url { get; set; }
            public Stats? stats { get; set; }
            public string? title { get; set; }
            public string? title_with_featured { get; set; }
            public int updated_by_human_at { get; set; }
            public string? url { get; set; }
            public Primary_Artist? primary_artist { get; set; }
        }

        public class Stats
        {
            public int unreviewed_annotations { get; set; }
            public bool hot { get; set; }
            public int pageviews { get; set; }
        }

        public class Primary_Artist
        {
            public string? _type { get; set; }
            public string? api_path { get; set; }
            public string? header_image_url { get; set; }
            public int id { get; set; }
            public string? image_url { get; set; }
            public string? index_character { get; set; }
            public bool is_meme_verified { get; set; }
            public bool is_verified { get; set; }
            public string? name { get; set; }
            public string? slug { get; set; }
            public string? url { get; set; }
            public int iq { get; set; }
        }

    }
}
