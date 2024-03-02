namespace KaijiCardGame.Domain
{
    public class Player
    {
        public int Id { get; set; }
        public string Nickname { get; set; } = "";
        public int Trophies { get; set; }
        public int Tokens { get; set; }
        public int Level { get; set; }
        public int ExperiencePoints { get; set; }
        public Country Country { get; set; } = new Country();
        public ICollection<Game> Games { get; } = new List<Game>();
    }
}