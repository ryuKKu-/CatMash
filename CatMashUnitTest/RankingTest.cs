using CatMash.Data;
using CatMash.Rating;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CatMashUnitTest
{
    [TestClass]
    public class RankingTest
    {
        [TestMethod]
        public void ComputeRatingIfCatAWins()
        {
            var catA = new Cat
            {
                CatId = "a",
                Looses = 0,
                Wins = 0,
                Rating = 1200
            };

            var catB = new Cat
            {
                CatId = "b",
                Looses = 0,
                Wins = 0,
                Rating = 1200
            };

            var expectedRatingA = 1220;
            var expectedRatingB = 1180;

            var elo = new EloRating(catA.Rating, catB.Rating, true, false, catA.TotalMatches, catB.TotalMatches);

            var (newRatingA, newRatingB) = elo.GetNewResults();

            Assert.AreEqual(expectedRatingA, newRatingA);
            Assert.AreEqual(expectedRatingB, newRatingB);
        }


        [TestMethod]
        public void ComputeRatingNbMatchAbove30()
        {
            var catA = new Cat
            {
                CatId = "a",
                Looses = 15,
                Wins = 16,
                Rating = 1220
            };

            var catB = new Cat
            {
                CatId = "b",
                Looses = 0,
                Wins = 0,
                Rating = 1200
            };

            var expectedRatingA = 1230;
            var expectedRatingB = 1180;

            var elo = new EloRating(catA.Rating, catB.Rating, true, false, catA.TotalMatches, catB.TotalMatches);

            var (newRatingA, newRatingB) = elo.GetNewResults();

            Assert.AreEqual(expectedRatingA, newRatingA);
            Assert.AreEqual(expectedRatingB, newRatingB);
        }
    }
}
