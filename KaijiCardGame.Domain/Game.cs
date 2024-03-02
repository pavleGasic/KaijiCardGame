namespace KaijiCardGame.Domain
{
    public class Game
    {
        public  int PlayerOneId { get; set; }
        public int PlayerTwoId { get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime DateFinished { get; set; }
        public int PlayerOnePoints { get; set; }
        public int PlayerTwoPoints { get; set; }
        public int Winer { get; set; }
        public Player PlayerOne { get; set; } = new Player();
        public Player PlayerTwo { get; set; } = new Player();
        public GameType GameType { get; set; }
    }
}