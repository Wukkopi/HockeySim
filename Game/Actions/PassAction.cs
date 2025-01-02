namespace HockeySim.Game.Actions;

public class PassAction : IAction
{
    public int Cost => 3;
    public bool IsCounterAction => false;

    public string Description => "Passes the puck forwards by one area (+1 boost for goal making)";

    public bool Play(GameManager gameManager)
    {
        throw new NotImplementedException();
    }
}
