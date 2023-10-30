using Microsoft.AspNetCore.Mvc;
using ScoreService.Services;

namespace ScoreService.Controllers
{
    [ApiController]
    public class LeaderboardController : ControllerBase
    {

        public ILeadersService _leadersService;

        public LeaderboardController(ILeadersService _leadersService)
        {
            this._leadersService = _leadersService;
        }

        [HttpPost("/customer/{customerid}/score/{score}")]
        public double UpdateScore(long customerid, double score)
        {
            return _leadersService.UpdateScore(customerid, score);
        }

        [HttpGet("/leaderboard")]
        public List<Leaderboard> GetCustomersByRank(int start, int end)
        {
            return _leadersService.GetCustomersByRank(start, end);
        }

        [HttpGet("/leaderboard/{customerid}")]
        public List<Leaderboard> GetCustomersByCustomerid(long customerid, int high, int low)
        {
            return _leadersService.GetCustomersByCustomerid(customerid, high, low);
        }
    }
}