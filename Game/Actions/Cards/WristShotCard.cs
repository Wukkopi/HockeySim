namespace HockeySim.Game.Actions.Cards;

public class WristShotCard : ICard
{
    public int Cost => 3;
    
    public bool IsCounterAction => false;

    public string Description => "Make a wristshot (+1 for goal making)";

    public bool Play(GameManager gameManager)
    {
        throw new NotImplementedException();
    }
}
