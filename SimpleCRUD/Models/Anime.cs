using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleCRUD.Models
{
    public class Anime
    {
        public const int MAX_PER_SEASON = Properties.EPISODES_PER_SEASON;
        public const int NORMAL_DURATION = Properties.NORMAL_DURATION;
        public const int EPISODES_PER_SEASON = Properties.EPISODES_PER_SEASON;
        public const string CURRENT_SEASON = Properties.CURRENT_SEASON;
        public const int SHORT_DURATION = Properties.SHORT_DURATION;

        public int ID { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public GenreEnum.Genre Genre { get; set; }
        public SeasonEnum.Season Season { get; set; }
        public double Rating { get; set; }
        public bool Aring { get; set; }
        public Author Author { get; set; }

    }
}