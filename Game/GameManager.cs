using HockeySim.Game.Actions.Cards;
using HockeySim.Game.Player;

namespace HockeySim.Game;

public class GameManager
{
    public ConsolePlayer Red { get; private set; }
    public ConsoleAI Blue { get; private set; }
    public IPlayer InTurn { get; private set; }
    public DeckManager DeckManager { get; private set; }
    public ActionManager ActionManager { get; private set; }
    public Puck Puck { get; private set; }
    public TurnState TurnState { get; private set; }

    public GameManager() 
    {
        ActionManager = new();
        DeckManager = new();
        DeckManager.Shuffle();
        Red = new("red", DeckManager);
        Blue = new("blue", DeckManager);
        Puck = new(Red);
        InTurn = Red;
        TurnState = new();
        PrepareGame();
    }

    public void SwapTurn() => InTurn = GetOpponent();

    public IPlayer GetOpponent()
    {
        return InTurn.ID switch {
            "red" => Blue,
            "blue" => Red,
        };
    }

    public void PrepareGame()
    {
        Helper.DealEnergy(this, Settings.InitialEnergy);
       
        Red.DrawCards();
        Blue.DrawCards();
    }

    public void CheckGoal()
    {
        if (TurnState.Shot && TurnState.ShotPower > 0)
        {
            InTurn.Goals++;
            Puck.At = Puck.Position.Middle;
            Puck.Owner = GetOpponent();
            TurnState.Reset();
        }
    }

    public void PrintState()
    {
        Console.WriteLine("== Game state ==");
        Console.WriteLine($"Turn: {InTurn.ID}, Deck left: {DeckManager.CardsInDrawPile}");
        Console.WriteLine($"Scores: (red){Red.Goals}, (blue){Blue.Goals}");
        Console.WriteLine($"Puck: ({Puck.Owner.ID}) at {Puck.At}");
        Console.WriteLine($"Red energy: {Red.EnergyBank}, Blue energy: {Blue.EnergyBank}");
        Console.WriteLine();
    }
}
