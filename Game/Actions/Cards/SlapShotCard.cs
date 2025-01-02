namespace HockeySim.Game.Actions.Cards;

public class SlapShotCard : ICard
{
    public int Cost => 5;
    
    public bool IsCounterAction => false;

    public string Description => "Hard slap shot (+2 for goal making)";

    public bool Play(GameManager gameManager)
    {
        throw new NotImplementedException();
    }
}
