
namespace GamesInventory.Models;
public class Dlc : Game
{
    public Game MainGame { get; }
    public Dlc(string title, Game mainGame) : base(title)
    {
        if (mainGame is null)
            throw new ArgumentNullException(nameof(mainGame));
        if (mainGame.IsDlc)
            throw new ArgumentException("il valore non puo essere null o Dlc", nameof(mainGame));

        MainGame = mainGame;
    }

    public override bool IsDlc => true;

    public override bool Equals(object? obj)=> obj is Dlc dlc && base.Equals(dlc) && MainGame.Equals(dlc.MainGame);
 
    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), MainGame);
    }
}
