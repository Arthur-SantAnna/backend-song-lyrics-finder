using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace song_lyrics_finder.MODEL
{
    public class CreateUser
    {
        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Nickname { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
