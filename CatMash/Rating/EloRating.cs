using System;

namespace CatMash.Rating
{
    public class EloRating
    {
        private int _ratingA { get; set; }
        private int _ratingB { get; set; }

        private bool _resultA { get; set; }
        private bool _resultB { get; set; }

        private double _expectedA { get; set; }
        private double _expectedB { get; set; }

        private int _newRatingA { get; set; }
        private int _newRatingB { get; set; }

        public EloRating(int ratingPlayerA, int ratingPlayerB, bool resultPlayerA, bool resultPlayerB, int nbMatchA, int nbMatchB)
        {
            _ratingA = ratingPlayerA;
            _ratingB = ratingPlayerB;
            _resultA = resultPlayerA;
            _resultB = resultPlayerB;

            _expectedA = GetExpectedScore(_ratingB, _ratingA);
            _expectedB = GetExpectedScore(_ratingA, _ratingB);

            _newRatingA = GetNewRating(_ratingA, _expectedA, _resultA, nbMatchA);
            _newRatingB = GetNewRating(_ratingB, _expectedB, _resultB, nbMatchB);
        }

        private double GetExpectedScore(int ratingOpponent, int ratingPlayer)
        {
            return 1 / (1 + (Math.Pow(10, (ratingOpponent - ratingPlayer) / 400)));
        }

        private int GetNewRating(int currentRating, double expectedScore, bool result, int nbMatch)
        {
            int k = 32;

            if (nbMatch <= 30)
                k = 40;
            else if (currentRating < 2400)
                k = 20;
            else if (currentRating >= 2400)
                k = 10;

            return Convert.ToInt32(currentRating + k * ((result ? 1 : 0) - expectedScore));
        }

        public (int newRatingA, int newRatingB) GetNewResults() => (_newRatingA, _newRatingB);
    }
}
