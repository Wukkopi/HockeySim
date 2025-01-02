namespace HockeySim.Game.Actions;

public class DribbleAction : Action
{
    public override int Cost => 2;
    public override bool CanBeCountered => true;

    public override string Description => "Dribbles puck forwards by one section";

    public override bool TryPlay(GameManager gameManager)
    {
        throw new NotImplementedException();
    }
}
