using System.Collections.Generic;

namespace Repository.Library
{
    public class Show : StreamingContent
    {
        public Show() {}
        //show off inheritance using base constructor.
        public Show(string title, string description, double starRating, MaturityRating maturityRating, bool isFamilyFriendly, int seasonCount, int episodeCount, int averageRunTimeInMinutes) : base(title,description,starRating,maturityRating,isFamilyFriendly)
        {
            seasonCount = SeasonCount;
            episodeCount = EpisodeCount;
            averageRunTimeInMinutes = AverageRunTimeInMinutes;
        }
        public List<Episode> Episodes { get; set; } = new List<Episode>();

        public int SeasonCount {get;set;}
        public int EpisodeCount { get; set; }
        public int AverageRunTimeInMinutes { get; set; }
    }

    public class Episode : StreamingContent
    {
        public int SeasonNumber { get; set; }

        public Show Show { get; set; }
    }
}