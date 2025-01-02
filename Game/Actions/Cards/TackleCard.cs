namespace HockeySim.Game.Actions.Cards;

public class TackleCard : ICard
{
    public int Cost => 3;

    public bool IsCounterAction => true;

    public string Description => "Tackes a dribbling player";

    public bool Play(GameManager gameManager)
    {
        throw new NotImplementedException();
    }
}
