namespace HockeySim.Game.Actions;

public class DefendAction : IAction
{
    public int Cost => 2;

    public string Description => "Defend the goal (+1 for defense)";

    public bool IsCounterAction => true;

    public bool Play(GameManager gameManager)
    {
        throw new NotImplementedException();
    }
}
