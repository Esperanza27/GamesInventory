namespace GamesInventory.Models;

public class Launcher
{
    public string Name { get; }
    public Launcher(string name) => Name = string.IsNullOrWhiteSpace(name) ? throw new ArgumentException("il valore non puo essere null o spazi", nameof(name)) : name.Trim();

    public override bool Equals(object? obj)=>
        obj is Launcher launcher && Name.Equals(launcher.Name, StringComparison.InvariantCultureIgnoreCase);
       
    public override int GetHashCode() =>
        Name.GetHashCode(StringComparison.InvariantCultureIgnoreCase);

}
