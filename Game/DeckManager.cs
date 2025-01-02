using HockeySim.Game.Actions.Cards;

namespace HockeySim.Game;

public class DeckManager
{
    private Stack<ICard> drawPile = new Stack<ICard>(Helper.BuildDeck());
    private List<ICard> discardPile = new();

    public int CardsInDrawPile => drawPile.Count;

    public void Shuffle()
    {
        drawPile.Shuffle();
    }

    public bool TryDrawCard(out ICard card)
    {
        return drawPile.TryPop(out card);
    }

    public void Discard(ICard card)
    {
        discardPile.Add(card);
    }
}
