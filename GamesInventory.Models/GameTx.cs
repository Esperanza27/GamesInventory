namespace GamesInventory.Models;
public enum MediaType
{
    Digital,
    Physical
}
public class GameTx
{
    public DateOnly PurchaseDate { get; }
    public decimal PurchasePrice { get; }
    public Game Game { get; }
    public Platform Platform { get; }
    public Store Store { get; }
    public Launcher Launcher { get; }

    public MediaType MediaType { get; }

    public GameTx(DateOnly purchaseDate, decimal purchasePrice, Game game, Platform platform, Store store, Launcher launcher, MediaType mediaType)
    {
        PurchaseDate = purchaseDate;
        PurchasePrice = purchasePrice;
        Game = game ?? throw new ArgumentNullException(nameof(game));
        Platform = platform ?? throw new ArgumentNullException(nameof(platform));
        Store = store ?? throw new ArgumentNullException(nameof(store));
        Launcher = launcher ?? throw new ArgumentNullException(nameof(launcher));
        MediaType = mediaType;
    }
}
