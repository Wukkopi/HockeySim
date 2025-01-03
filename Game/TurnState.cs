namespace HockeySim.Game;

public class TurnState
{
    public int ShotPower { get; set; }

    public void Reset()
    {
        ShotPower = 0;
    }

}
