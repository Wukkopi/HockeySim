namespace HockeySim.Game.Actions.Cards;

public class QuickPassCard : Action, ICard
{
    public override int Cost => 2;
    public override bool CanBeCountered => false;
    public override string Description => "Make a fast pass (prevents interception)";

    public override bool TryPlay(GameManager gameManager)
    {
        throw new NotImplementedException();
    }
}
