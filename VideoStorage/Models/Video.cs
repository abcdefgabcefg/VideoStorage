using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VideoStorage.Models
{
    public class Video
    {
        public int ID { get; set; }
        [MaxLength(150)]
        [Required]
        public string Path { get; set; }
    }
}