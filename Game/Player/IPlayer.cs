namespace HockeySim.Game.Player;

public interface IPlayer
{
    public string ID { get; }
    public int Goals { get; set; }
    public void PlayTurn(GameManager manager);
    public void PlayCounter(GameManager manager);
}
