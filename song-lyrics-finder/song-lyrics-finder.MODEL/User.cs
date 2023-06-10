using System;
using System.Collections.Generic;

namespace song_lyrics_finder.MODEL;

public partial class User
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Nickname { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<UserSong> UserSongs { get; set; } = new List<UserSong>();
}
