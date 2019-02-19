using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Text.RegularExpressions;
using VideoStorage.Models;

namespace VideoStorage.DAL
{
    public class VideoContextInitializer : DropCreateDatabaseIfModelChanges<VideoContex>
    {
        protected override void Seed(VideoContex context)
        {
            var urlPattern = "https://drive.google.com/uc?id=yourID";
            var regPattern = @"^https://drive.google.com/open_id=[A-Za-z0-9\s_-]+$";
            var pathes = new string[]{ "https://drive.google.com/open?id=1UbGfHF1s6N5YCGbiKSgAjqRlT3mihptO",
                                       "https://drive.google.com/open?id=17QKrPfcMjM90SJdwVfVI28cGUhmv_2QM",
                                       "https://drive.google.com/open?id=1uyXyT1TlAeAi9FybXH1Hd9RxLVki3cSk",
                                       "https://drive.google.com/open?id=1UDbmjV7U4cTrkHJHF845-SUNpImt0pfl",
                                       "https://drive.google.com/open?id=1e4912Ffj8ltwFhBh0WXKwQNMQ2rfYRn0"
            };
            pathes = (from p in pathes
                      select p.Replace('?', '_')).ToArray();
            pathes = (from p in pathes
                      where GetPath(p, urlPattern, regPattern) != null
                      select GetPath(p, urlPattern, regPattern)
                     ).ToArray();
            context.Videos.AddRange(from p in pathes select new Video { Path = p });
        }

        private string GetPath(string path, string urlPattern, string regPattern)
        {
            if (Regex.IsMatch(path, regPattern))
            {
                int start = path.IndexOf("=") + 1;
                return urlPattern.Replace("yourID", path.Substring(start));
            }
            return null;
        }
    }
}