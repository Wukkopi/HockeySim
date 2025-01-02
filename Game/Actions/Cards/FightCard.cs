namespace HockeySim.Game.Actions.Cards;

public class FightCard : ICard
{
    public int Cost => 0;

    public bool IsCounterAction => false;

    public string Description => "Players start to fight (-1 energy for both teams)";

    public bool Play(GameManager gameManager)
    {
        throw new NotImplementedException();
    }
}
