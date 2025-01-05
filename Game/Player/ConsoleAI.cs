namespace HockeySim.Game.Player;

public class ConsoleAI : Player
{
    public ConsoleAI(string id, DeckManager deckManager) : base(id, deckManager)
    {
    }

    public override void PlayCounter(GameManager manager)
    {
        
    }

    public override void PlayTurn(GameManager manager)
    {
        TryPlayAction(manager.ActionManager.EndTurn, manager, out _);
    }
}
