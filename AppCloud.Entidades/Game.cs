namespace AppCloud.Entidades
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set;}

        public int LauncherId { get; set;}
        public Launcher? Launcher { get; set;}
    }
}
