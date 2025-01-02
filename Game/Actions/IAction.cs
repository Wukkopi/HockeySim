namespace HockeySim.Game.Actions;

public interface IAction
{
    int Cost { get; }
    string Description { get; }
    bool IsCounterAction { get; }
    bool Play(GameManager gameManager);
}
