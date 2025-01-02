using HockeySim.Game.Player;

namespace HockeySim.Game.Actions;

public abstract class Action : IAction
{
    public bool CanAfford(IPlayer player) => player.EnergyBank >= Cost;
    public abstract bool TryPlay(GameManager gameManager);
    public abstract int Cost { get; }
    public abstract string Description { get; }
    public abstract bool CanBeCountered { get; }
}
