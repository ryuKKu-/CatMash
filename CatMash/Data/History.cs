using System;

namespace CatMash.Data
{
    public class History
    {
        public int HistoryId { get; set; }
        public DateTime Date { get; set; }
        public int Rating { get; set; }

        public string CatId { get; set; }
        public virtual Cat Cat { get; set; }

        public int MatchId { get; set; }
        public virtual Match Match { get; set; }
    }
}
