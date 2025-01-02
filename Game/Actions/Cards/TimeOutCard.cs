namespace HockeySim.Game.Actions.Cards;

public class TimeOutCard : Action, ICard
{
    public override int Cost => 4;
    public override bool CanBeCountered => false;
    public override string Description => "Coach calls for timeout (draws 2 cards)";

    public override bool TryPlay(GameManager gameManager)
    {
        throw new NotImplementedException();
    }
}
