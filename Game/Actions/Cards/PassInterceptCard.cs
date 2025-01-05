namespace HockeySim.Game.Actions.Cards;

public class PassInterceptCard : Action, ICard
{
    public override int Cost => 2;
    public override bool CanBeCountered => false;
    public override string Description => "Intercepts a regular pass";

    public override bool TryPlay(GameManager gameManager)
    {
        if (gameManager.TurnState.Passed == false)
            return false;
        if (gameManager.Puck.Owner == gameManager.GetOpponent())
            return false;

        gameManager.Puck.SwapOwner(gameManager.GetOpponent());
        return true;
    }
}
