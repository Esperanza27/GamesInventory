namespace GamesInventory.Models;

public class Platform
{
    public string Name { get; }
    public Platform(string name)=> 
        Name = string.IsNullOrWhiteSpace(name) 
        ? throw new ArgumentException("Il valore non può essere null o contenere solo spazi.", nameof(name)) 
        : name.Trim();

    public override bool Equals(object? obj) =>
         obj is Platform platform && Name.Equals(platform.Name, StringComparison.InvariantCultureIgnoreCase);


    public override int GetHashCode()=>
        Name.GetHashCode(StringComparison.InvariantCultureIgnoreCase);
    


}//class
