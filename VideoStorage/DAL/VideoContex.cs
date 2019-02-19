using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoStorage.Models;
using System.Data.Entity;

namespace VideoStorage.DAL
{
    public class VideoContex : DbContext
    {
        public DbSet<Video> Videos { get; set; }

        public VideoContex()
        {
            Database.SetInitializer(new VideoContextInitializer());
        }
    }
}