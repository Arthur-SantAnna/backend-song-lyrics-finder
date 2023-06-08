namespace song_lyrics_finder.API.Models
{
    public class LyricsModel
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
            public Lyrics? lyrics { get; set; }
        }

        public class Lyrics
        {
            public string? _type { get; set; }
            public string? api_path { get; set; }
            public Lyrics1? lyrics { get; set; }
            public string? path { get; set; }
            public int song_id { get; set; }
            public Trackingdata? trackingData { get; set; }
        }

        public class Lyrics1
        {
            public Body? body { get; set; }
        }

        public class Body
        {
            public string? html { get; set; }
            public object[]? children { get; set; }
            public string? tag { get; set; }
            public string? plain { get; set; }
        }

        public class Trackingdata
        {
            public int SongID { get; set; }
            public string? Title { get; set; }
            public string? PrimaryArtist { get; set; }
            public int PrimaryArtistID { get; set; }
            public string? PrimaryAlbum { get; set; }
            public int PrimaryAlbumID { get; set; }
            public string? Tag { get; set; }
            public string? PrimaryTag { get; set; }
            public int PrimaryTagID { get; set; }
            public bool Music { get; set; }
            public string? AnnotatableType { get; set; }
            public int AnnotatableID { get; set; }
            public bool featured_video { get; set; }
            public int[]? cohort_ids { get; set; }
            public bool has_verified_callout { get; set; }
            public bool has_featured_annotation { get; set; }
            public DateTime created_at { get; set; }
            public string? created_month { get; set; }
            public int created_year { get; set; }
            public string? song_tier { get; set; }
            public bool HasRecirculatedArticles { get; set; }
            public string? LyricsLanguage { get; set; }
            public bool HasAppleMatch { get; set; }
            public string? ReleaseDate { get; set; }
            public int NRMTier { get; set; }
            public string? NRMTargetDate { get; set; }
            public bool HasDescription { get; set; }
            public bool HasYoutubeURL { get; set; }
            public bool HasTranslationQA { get; set; }
            public int CommentCount { get; set; }
            public bool hot { get; set; }
            public string? web_interstitial_variant { get; set; }
            public bool two_column_song_page { get; set; }
            public string? platform_variant { get; set; }
        }

    }
}
