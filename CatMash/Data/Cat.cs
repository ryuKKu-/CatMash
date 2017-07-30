using System.Collections.Generic;

namespace CatMash.Data
{
    public partial class Cat
    {
        public string CatId { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public int Wins { get; set; }
        public int Looses { get; set; }

        public virtual ICollection<History> Histories { get; set; }

        public Cat()
        {
            Histories = new List<History>();
        }
    }
}
