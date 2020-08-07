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
        public string VideoTrailer { get; set; }
        public string NationalityID { get; set; }
        public int YearMovie { get; set; }
        public int? AgeID { get; set; }
        public DateTime OpeningTime { get; set; }
        public int? SubTitleID { get; set; }
        public string MovieTypeID { get; set; }
        public string MovieTicketTypeID { get; set; }
        public string DirectorID { get; set; }
        public string ActorID { get; set; }
        public int? MovieTimeDuration { get; set; }
        public string Note { get; set; }
        public IFormFile MovieTrailer { get; set; }

    }
}
