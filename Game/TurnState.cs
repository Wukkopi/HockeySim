namespace HockeySim.Game;

public class TurnState
{
    public int ShotPower { get; set; }
    public bool Shot { get; set; }
    public bool Dribbled { get; set; }
    public bool Passed { get; set; }

    public void Reset()
    {
        ShotPower = 0;
        Shot = false;
        Dribbled = false;
        Passed = false;
    }

}
