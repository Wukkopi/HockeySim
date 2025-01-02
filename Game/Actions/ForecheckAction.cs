namespace HockeySim.Game.Actions;

public class ForecheckAction : IAction
{
    public int Cost => 2;
    public bool IsCounterAction => false;

    public string Description => "Takes the possession of the puck";

    public bool Play(GameManager gameManager)
    {
        throw new NotImplementedException();
    }
}
