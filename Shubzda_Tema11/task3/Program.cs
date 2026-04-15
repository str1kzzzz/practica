using System;
interface ICommand
{
    void Execute();
}
class GameCharacter
{
    public void Jump()
    {
        Console.WriteLine("Прыжок");
    }
    public void Attack()
    {
        Console.WriteLine("Атака");
    }
    public void Defend()
    {
        Console.WriteLine("Защита");
    }
}
class JumpCommand : ICommand
{
    GameCharacter c;
    public JumpCommand(GameCharacter c1)
    {
        c = c1;
    }
    public void Execute()
    {
        c.Jump();
    }
}
class AttackCommand : ICommand
{
    GameCharacter c;
    public AttackCommand(GameCharacter c1)
    {
        c = c1;
    }
    public void Execute()
    {
        c.Attack();
    }
}
class DefendCommand : ICommand
{
    GameCharacter c;
    public DefendCommand(GameCharacter c1)
    {
        c = c1;
    }
    public void Execute()
    {
        c.Defend();
    }
}
class GameController
{
    public ICommand Command;
    public void Press()
    {
        Command.Execute();
    }
}
class Program
{
    static void Main()
    {
        GameCharacter c = new GameCharacter();
        GameController g = new GameController();
        g.Command = new JumpCommand(c);
        g.Press();
        g.Command = new AttackCommand(c);
        g.Press();
        g.Command = new DefendCommand(c);
        g.Press();
    }
}