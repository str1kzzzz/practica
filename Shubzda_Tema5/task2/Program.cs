using System;
class Player
{
    public string Name;

    public Player(string name)
    {
        Name = name;
    }
}
class GameWorld
{
    public string Title;

    public GameWorld(string title)
    {
        Title = title;
    }
}
class Developer
{
    public string Name;

    public Developer(string name)
    {
        Name = name;
    }
}
class VideoGame
{
    public string Name;
    public Player[] Players;
    public GameWorld World;
    public Developer Developer;
    public VideoGame(string name, Player[] players, Developer developer)
    {
        Name = name;
        Players = players;
        Developer = developer;
        World = new GameWorld("Игровой мир " + name);
    }
    public void StartGame()
    {
        Console.WriteLine("Игра: " + Name);
        Console.WriteLine("Разработчик: " + Developer.Name);
        Console.WriteLine("Мир: " + World.Title);
        Console.WriteLine("Игроки:");
        for (int i = 0; i < Players.Length; i++)
        {
            Console.WriteLine(Players[i].Name);
        }
        Console.WriteLine();
    }
}
class Program
{
    static void Main()
    {
        Developer d1 = new Developer("Ubisoft");
        Developer d2 = new Developer("Rockstar");
        Player[] p1 = new Player[2];
        p1[0] = new Player("Игорь");
        p1[1] = new Player("Анна");
        Player[] p2 = new Player[3];
        p2[0] = new Player("Олег");
        p2[1] = new Player("Мария");
        p2[2] = new Player("Дима");
        VideoGame[] games = new VideoGame[2];
        games[0] = new VideoGame("Far Cry", p1, d1);
        games[1] = new VideoGame("GTA", p2, d2);
        for (int i = 0; i < games.Length; i++)
        {
            games[i].StartGame();
        }
    }
}