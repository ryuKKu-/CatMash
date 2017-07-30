using System.ComponentModel.DataAnnotations.Schema;

namespace CatMash.Data
{
    public partial class Match
    {
        public int MatchId { get; set; }

        public int Result { get; set; }
        public int RatingA { get; set; }
        public int RatingB { get; set; }

        [ForeignKey("CatAId")]
        public virtual Cat CatA { get; set; }

        [ForeignKey("CatBId")]
        public virtual Cat CatB { get; set; }
    }
}
