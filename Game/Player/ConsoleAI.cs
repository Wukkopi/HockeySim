namespace HockeySim.Game.Player;

public class ConsoleAI : Player
{
    public ConsoleAI(string id, DeckManager deckManager) : base(id, deckManager)
    {
    }

    public override void PlayCounter(GameManager manager)
    {
        throw new NotImplementedException();
    }

    public override void PlayTurn(GameManager manager)
    {
        throw new NotImplementedException();
    }
}
