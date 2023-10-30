namespace ScoreService
{
    public class Leaderboard
    {
        public Leaderboard(long customerID, double score, int rank)
        {
            CustomerID = customerID;
            Score = score;
            Rank = rank;
        }

        public long CustomerID { get; set; }
        public double Score { get; set; }
        public int Rank { get; set; }
    }
}