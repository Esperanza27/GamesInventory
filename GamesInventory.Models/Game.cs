using System.Xml.Linq;

namespace GamesInventory.Models;

public class Game
{
    public string Title { get;}
    public string Slug { get;}// clean title 
    public virtual bool IsDlc => false;

    public Game(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Il valore non può essere null o spazi", nameof(title));

        Title = title.Trim();
        Slug = GenerateSlug(Title);
    }

    private string GenerateSlug(string title)
    {
        return title.ToLower().Replace(" ", "-");
    }

    public override bool Equals(object? obj)=>

        obj is Game game && Title.Equals(game.Title, StringComparison.InvariantCultureIgnoreCase)&& IsDlc == game.IsDlc;
  
    public override int GetHashCode()
    {
        return HashCode.Combine(Title, IsDlc);
    }
}
