namespace HockeySim.Game.Actions;

public class ForecheckAction : Action
{
    public override int Cost => 2;
    public override bool CanBeCountered => false;

    public override string Description => "Takes the possession of the puck";

    public override bool TryPlay(GameManager gameManager)
    {
        throw new NotImplementedException();
    }
}
