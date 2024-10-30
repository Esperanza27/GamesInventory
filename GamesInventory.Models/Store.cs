namespace GamesInventory.Models;
public class Store
{
    public string Name { get; }
    public Store(string name) => Name = string.IsNullOrWhiteSpace(name) ? throw new ArgumentException("il valore non puo essere null o spazi", nameof(name)) : name.Trim();

    public override bool Equals(object? obj) =>
        obj is Store store && Name.Equals(store.Name, StringComparison.InvariantCultureIgnoreCase);

    public override int GetHashCode()=>
        Name.GetHashCode(StringComparison.InvariantCultureIgnoreCase);

}//class
