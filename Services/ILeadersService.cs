namespace ScoreService.Services
{
    public interface ILeadersService
    {
        List<Leaderboard>? GetCustomersByCustomerid(long customerid, int high, int low);
        List<Leaderboard>? GetCustomersByRank(int start, int end);
        double UpdateScore(long customerid, double score);
    }
}
