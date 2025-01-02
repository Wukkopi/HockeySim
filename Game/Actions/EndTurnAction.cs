namespace HockeySim.Game.Actions;

public class EndTurnAction : IAction
{
    public int Cost => 0;

    public string Description => "End turn (draws to 5)";

    public bool IsCounterAction => false;

    public bool Play(GameManager gameManager)
    {
        throw new NotImplementedException();
    }
}
