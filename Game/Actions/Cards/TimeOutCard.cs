namespace HockeySim.Game.Actions.Cards;

public class TimeOutCard : Action, ICard
{
    private const int amount = 2;
    public override int Cost => 4;
    public override bool CanBeCountered => false;
    public override string Description => $"Coach calls for timeout (draws {amount} cards)";

    public override bool TryPlay(GameManager gameManager)
    {
        if (gameManager.DeckManager.CardsInDrawPile < amount)
            return false;
            
        for (var i = 0; i < amount; i++)
        {
            gameManager.DeckManager.TryDrawCard(out var card);
            gameManager.InTurn.Hand.Add(card);
        }
        return true;
    }
}
