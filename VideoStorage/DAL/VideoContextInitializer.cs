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
            var pathes = new string[]{ "https://drive.google.com/file/d/1kzKULoII9LDKtQyB_DXzHLEbqB_B0ogt/preview",
                                       "https://drive.google.com/file/d/1SvwlQSu4hLDY9emkdHIQiUyjcYQxji1i/preview",
                                       "https://drive.google.com/file/d/1qEImT2Ex-Xq5inimP5L4AWhDhqdRkDyI/preview",
                                       "https://drive.google.com/file/d/1FLB-s9N2Zk2AUCVpsIwyKPkEQAcvCNe0/preview"
            };
            context.Videos.AddRange(from p in pathes select new Video { Path = p });
            context.SaveChanges();
        }

    }
}