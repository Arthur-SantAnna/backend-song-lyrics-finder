using System;
using System.Collections.Generic;

namespace song_lyrics_finder.MODEL;

public partial class Song
{
    public int SongId { get; set; }

    public int SongApiId { get; set; }

    public virtual ICollection<UserSong> UserSongs { get; set; } = new List<UserSong>();
}
