using HockeySim.Game.Player;

namespace HockeySim.Game.Actions;

public interface IAction
{
    int Cost { get; }
    string Description { get; }
    bool CanBeCountered { get; }
    bool CanAfford(IPlayer player);
    bool TryPlay(GameManager gameManager);
}
