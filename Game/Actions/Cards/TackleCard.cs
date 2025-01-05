namespace HockeySim.Game.Actions.Cards;

public class TackleCard : Action, ICard
{
    public override int Cost => 3;
    public override bool CanBeCountered => false;
    public override string Description => "Tackes a dribbling player";

    public override bool TryPlay(GameManager gameManager)
    {
        if (gameManager.TurnState.Dribbled == false)
            return false;
        if (gameManager.Puck.Owner == gameManager.GetOpponent())
            return false;

        gameManager.Puck.SwapOwner(gameManager.GetOpponent());
        return true;
    }
}
