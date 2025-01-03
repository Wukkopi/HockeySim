using HockeySim.Game.Player;

namespace HockeySim.Game;

public class Puck(IPlayer owner)
{
    public enum Position
    {
        Defense,
        Middle,
        Offense,
    }
    public IPlayer Owner = owner;
    public Position At = Position.Middle;

    public void SwapOwner(IPlayer newOwner)
    {
        Owner = newOwner;
        At = At switch
        {
            Position.Defense => Position.Offense,
            Position.Offense => Position.Defense,
            Position.Middle => Position.Middle,
            _ => throw new Exception("Invalid position"),
        };
    }

    public void MoveForward()
    {
        At = At switch
        {
            Position.Defense => Position.Middle,
            Position.Middle => Position.Offense,
            _ => At
        };
    }
}