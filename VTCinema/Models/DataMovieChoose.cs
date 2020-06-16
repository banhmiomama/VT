using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VTCinema.Models
{
    public class DataMovieChoose
    {
        public int? MovieID { get; set; }
        public string NameVN { get; set; }
        public string NameEN { get; set; }
        public string Image { get; set; }
        public int? NationalityID { get; set; }
        public DateTime YearMovie { get; set; }
        public int? AgeID { get; set; }
        public DateTime OpeningTime { get; set; }
        public int? SubTitleID { get; set; }
        public int? MovieTypeID { get; set; }
        public int? MovieTicketTypeID { get; set; }
        public int? DirectorID { get; set; }
        public int? ActorID { get; set; }
        public int? MovieTimeDuration { get; set; }
        public IFormFile MovieTrailer { get; set; }

    }
}
