using System;
using System.Collections.Generic;

namespace song_lyrics_finder.MODEL;

public partial class UserSong
{
    public int UserSongId { get; set; }

    public int? UserId { get; set; }

    public int? SongId { get; set; }

    public virtual Song? Song { get; set; }

    public virtual User? User { get; set; }
}
