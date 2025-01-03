namespace HockeySim.Game.Actions;

public class EndTurnAction : Action
{
    public override int Cost => 0;

    public override string Description => $"End turn (draws to {Settings.CardsInHand})";

    public override bool CanBeCountered => false;

    public override bool TryPlay(GameManager gameManager)
    {
        if (!gameManager.InTurn.DrawCards())
            return false;

        gameManager.SwapTurn();
        return true;
    }
}
