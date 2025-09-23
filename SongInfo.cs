using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

  namespace Ampli_Music_Player
    {
        public class SongInfo
        {
            public string Title { get; set; }
            public string Artist { get; set; }
            public string Album { get; set; }
            public string FilePath { get; set; } // Local file
            public string PreviewUrl { get; set; } // Spotify preview
            public string ImageUrl { get; set; } // Album art

            public override string ToString()
            {
                return $"{Title} - {Artist}";
            }
        }
    }


