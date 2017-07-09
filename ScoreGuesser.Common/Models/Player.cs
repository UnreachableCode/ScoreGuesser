namespace ScoreGuesser.Common.Models
{
    public class Player
    {
        public Player(string firstName, string lastName, string imageUrl, float fppg)
        {
            FirstName = firstName;
            LastName = lastName;
            ImageUrl = imageUrl;
            FanduelPointsPerGame = fppg;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string ImageUrl { get; }
        public float FanduelPointsPerGame { get; }
    }
}