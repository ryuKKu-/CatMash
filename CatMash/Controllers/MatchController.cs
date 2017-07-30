using CatMash.Data;
using CatMash.Extensions;
using CatMash.Models;
using CatMash.Rating;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using static CatMash.Data.Match;

namespace CatMash.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class MatchController : Controller
    {
        private CatMashContext _context;

        public MatchController(CatMashContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<Match> CreateMatch([FromQuery] string winnerId, [FromQuery] MatchResult? position)
        {
            var cats = _context.Cats;
            Cat playerA;
            Cat playerB;

            if(!string.IsNullOrEmpty(winnerId) && position != null)
            {
                if(position == MatchResult.PLAYER_A_WIN)
                {
                    playerA = cats.FirstOrDefault(x => x.CatId == winnerId);
                    playerB = cats.Where(x => x.CatId != playerA.CatId).RandomElement();
                }
                else
                {
                    playerB = cats.FirstOrDefault(x => x.CatId == winnerId);
                    playerA = cats.Where(x => x.CatId != playerB.CatId).RandomElement();
                }
            }
            else
            {
                playerA = cats.RandomElement();
                playerB = cats.Where(x => x.CatId != playerA.CatId).RandomElement();
            }

            var match = new Match
            {
                CatA = playerA,
                CatB = playerB,
                RatingA = playerA.Rating,
                RatingB = playerB.Rating,
                Result = (int)MatchResult.PROGRESS
            };

            await _context.Matches.AddAsync(match);
            await _context.SaveChangesAsync();

            return match;
        }

        [HttpPost("{matchId}")]
        public async Task<IActionResult> Result([FromRoute] int matchId, [FromBody] ResultModel model)
        {
            try
            {
                var match = _context.Matches
                    .Include(x => x.CatA)
                    .Include(x => x.CatB)
                    .FirstOrDefault(x => x.MatchId == matchId);

                if (match != null)
                {
                    var catA = match.CatA;
                    var catB = match.CatB;

                    var rating = new EloRating(catA.Rating, 
                      catB.Rating,
                      model.Result == MatchResult.PLAYER_A_WIN,
                      model.Result == MatchResult.PLAYER_B_WIN, 
                      catA.TotalMatches, 
                      catB.TotalMatches);

                    var (newRatingA, newRatingB) = rating.GetNewResults();

                    var now = DateTime.UtcNow;

                    catA.Rating = newRatingA;
                    catA.Wins = model.Result == MatchResult.PLAYER_A_WIN ? catA.Wins + 1 : catA.Wins;
                    catA.Looses = model.Result == MatchResult.PLAYER_B_WIN ? catA.Looses + 1 : catA.Looses;
                    catA.Histories.Add(new History
                    {
                        Date = now,
                        Rating = newRatingA,
                        MatchId = matchId
                    });

                    catB.Rating = newRatingB;
                    catB.Wins = model.Result == MatchResult.PLAYER_B_WIN ? catB.Wins + 1 : catB.Wins;
                    catB.Looses = model.Result == MatchResult.PLAYER_A_WIN ? catB.Looses + 1 : catB.Looses;
                    catB.Histories.Add(new History
                    {
                        Date = now,
                        Rating = newRatingB,
                        MatchId = matchId
                    });

                    match.Result = (int)model.Result;

                    await _context.SaveChangesAsync();

                    var winnerId = model.Result == MatchResult.PLAYER_A_WIN ? catA.CatId : catB.CatId;

                    return Ok(winnerId);
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}