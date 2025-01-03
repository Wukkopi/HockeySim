namespace HockeySim.Game.Actions.Cards;

public class FightCard : Action, ICard
{
    private const int power = 1;

    public override int Cost => 0;
    public override bool CanBeCountered => false;
    public override string Description => $"Players start to fight (-{power} energy for both teams)";

    public override bool TryPlay(GameManager gameManager)
    {
        gameManager.Blue.ConsumeEnergy(power);
        gameManager.Red.ConsumeEnergy(power);
        return true;
    }
}
