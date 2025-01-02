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

    public GameManager()
    {
        ActionManager = new();
        DeckManager = new();
        DeckManager.Shuffle();
        Red = new("red", DeckManager);
        Blue = new("blue", DeckManager);
        Puck = new(Red);
        InTurn = Red;
        PrepareGame();
    }

    public void PrepareGame()
    {
        for (var i = 0; i < Settings.InitialEnergy; i++)
        {
            ICard card;

            DeckManager.TryDrawCard(out card);
            Red.AssignAsEnergy(card);

            DeckManager.TryDrawCard(out card);
            Blue.AssignAsEnergy(card);
        }
        Red.DrawCards();
        Blue.DrawCards();
    }

    public void PrintState()
    {
        Console.WriteLine("== Game state ==");
        Console.WriteLine($"Turn: {InTurn.ID}");
        Console.WriteLine($"Puck: ({Puck.Owner.ID}) at {Puck.At}");
        Console.WriteLine($"Red energy: {Red.EnergyBank}, Blue energy: {Blue.EnergyBank}");
        Console.WriteLine();
    }
}
