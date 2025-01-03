namespace HockeySim.Game.Actions;

public class DribbleAction : Action
{
    public override int Cost => 2;
    public override bool CanBeCountered => true;

    public override string Description => "Dribbles puck forwards by one section";

    public override bool TryPlay(GameManager gameManager)
    {
        if (gameManager.Puck.At == Puck.Position.Offense)
            return false;
            
        gameManager.Puck.MoveForward();
        return true;
    }
}
