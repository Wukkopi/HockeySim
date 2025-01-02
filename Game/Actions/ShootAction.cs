namespace HockeySim.Game.Actions;

public class ShootAction : IAction
{
    public int Cost => 4;
    public bool IsCounterAction => false;

    public string Description => "Try to shoot a goal (+1 for shooting)";

    public ActionType type => ActionType.Offensive;

    public bool Play(GameManager gameManager)
    {
        throw new NotImplementedException();
    }
}
