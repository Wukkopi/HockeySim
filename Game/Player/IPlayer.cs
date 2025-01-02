using HockeySim.Game.Actions.Cards;

namespace HockeySim.Game.Player;

public interface IPlayer
{
    public string ID { get; }
    public int Goals { get; set; }
    public int EnergyBank { get; }
    public void PlayTurn(GameManager manager);
    public void PlayCounter(GameManager manager);
    public void AssignAsEnergy(ICard card);
    public void ConsumeEnergy(int amount);
}
