using HockeySim.Game.Actions;

namespace HockeySim.Game;

public class ActionManager
{
    public IAction Dribble = new DribbleAction();
    public IAction Forecheck = new ForecheckAction();
    public IAction Pass = new PassAction();
    public IAction Shoot = new ShootAction();
    public IAction Defend = new DefendAction();
    public IAction EndTurn = new EndTurnAction();
}
