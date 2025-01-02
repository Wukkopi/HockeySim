namespace HockeySim.Game.Actions;

public class DribbleAction : IAction
{
    public int Cost => 2;
    public bool IsCounterAction => false;

    public string Description => "Dribbles puck forwards by one section";

    public ActionType type => ActionType.Offensive;

    public bool Play(GameManager gameManager)
    {
        throw new NotImplementedException();
    }
}
