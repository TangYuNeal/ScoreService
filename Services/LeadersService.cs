using System.Collections.Concurrent;
using System.Collections.Generic;

namespace ScoreService.Services
{
    public class LeadersService : ILeadersService
    {
        public List<Leaderboard> leaders = new List<Leaderboard>();

        public List<Leaderboard>? GetCustomersByCustomerid(long customerid, int high, int low)
        {
            var customer = leaders.Where(a => a.CustomerID == customerid).First();
            if (customer == null) return null;
            return leaders.Where(a => a.Rank >= customer.Rank - low && a.Rank <= customer.Rank + high)?.ToList();
        }

        public List<Leaderboard>? GetCustomersByRank(int start, int end)
        {
            return leaders.Where(a => a.Rank >= start && a.Rank <= end)?.ToList();
        }

        public double UpdateScore(long customerid, double score)
        {
            double result = score;
            lock (leaders)
            {
                var isExists = leaders.Any(a => a.CustomerID == customerid);
                if (!isExists)
                {
                    Leaderboard customer = new Leaderboard(customerid, score, 0);
                    leaders.Add(customer);
                }
                else
                {
                    var customer = leaders.Where(a => a.CustomerID == customerid).First();
                    customer.Score += score;
                    result = customer.Score;
                }
                SortAndUpdateRank(leaders);
            }
            return result;
        }

        public void SortAndUpdateRank(List<Leaderboard> leaders)
        {
            // 根据分数降序排列  
            leaders.Sort((a, b) =>
            {
                if (a.Score != b.Score)
                {
                    return b.Score.CompareTo(a.Score);
                }
                else
                {
                    return a.CustomerID.CompareTo(b.CustomerID);
                }
            });

            // 更新rank  
            int rank = 1;
            for (int i = 0; i < leaders.Count; i++)
            {
                leaders[i].Rank = rank;
                rank++;
            }
        }
    }
}
