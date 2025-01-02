namespace HockeySim.Game.Actions;

public class ShootAction : Action
{
    public override int Cost => 4;
    public override bool CanBeCountered => true;
    public override string Description => "Try to shoot a goal (+1 for shooting)";
    public override bool TryPlay(GameManager gameManager)
    {
        throw new NotImplementedException();
    }
}
