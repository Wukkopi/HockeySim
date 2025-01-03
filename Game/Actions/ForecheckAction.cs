namespace HockeySim.Game.Actions;

public class ForecheckAction : Action
{
    public override int Cost => 2;
    public override bool CanBeCountered => false;

    public override string Description => "Takes the possession of the puck";

    public override bool TryPlay(GameManager gameManager)
    {
        if (gameManager.Puck.Owner == gameManager.InTurn)
            return false;
            
        gameManager.Puck.SwapOwner(gameManager.GetOpponent());
        return true;
    }
}
