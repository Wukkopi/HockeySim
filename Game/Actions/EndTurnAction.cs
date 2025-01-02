namespace HockeySim.Game.Actions;

public class EndTurnAction : Action
{
    public override int Cost => 0;

    public override string Description => "End turn (draws to 5)";

    public override bool CanBeCountered => false;

    public override bool TryPlay(GameManager gameManager)
    {
        throw new NotImplementedException();
    }
}
