using System.Transactions;

namespace GamesInventory.Models;

public class TransactionUtils
{
    public static bool IsGameOwned(List<GameTx> transactions, string title)
    {
        foreach (var tx in transactions)
        {
            if (tx.Game.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }
        return false;
    }

    public static decimal GetTotalSpentOnStore(List<GameTx> transactions, string storeName)
    {
        decimal totalSpentOnStore = 0m;
        foreach (var tx in transactions)
        {
            if (tx.Store.Name.Equals(storeName, StringComparison.OrdinalIgnoreCase))
            {
                totalSpentOnStore += tx.PurchasePrice;
            }
        }
        return totalSpentOnStore;
    }

    public static List<GameTx> GetMostPaidGame(List<GameTx> transactions)
    {
        decimal maxPrice = 0;
        List<GameTx> mostPaidGames = new List<GameTx>();

        foreach (var tx in transactions)
        {
            if (tx.PurchasePrice > maxPrice)
            {
                maxPrice = tx.PurchasePrice;
            }
        }

        foreach (var tx in mostPaidGames)
        {
            if (tx.PurchasePrice == maxPrice)
            {
                mostPaidGames.Add(tx);
            }
        }

        return mostPaidGames;

    }

    public static decimal GetTotalSpentInDateRange(List<GameTx> transactions, DateOnly starDate, DateOnly endDate)
    {
        decimal totalSpent = 0m;

        foreach (var tx in transactions)
        {
            if (tx.PurchaseDate >= starDate && tx.PurchaseDate <= endDate)
            {
                totalSpent += tx.PurchasePrice;
            }
        }
        return totalSpent;
    }

    public static int GetCountGamesByPlatform(List<GameTx> transactions, string namePlatform)
    {
        int count = 0;
        foreach (var tx in transactions)
        {
            if (tx.Platform.Name.Equals(namePlatform, StringComparison.OrdinalIgnoreCase))
            {
                count++;
            }
        }
        return count;
    }

    public static int GetCountGamesByLauncher(List<GameTx> transactions, string nameLauncher)
    {
        int count = 0;
        foreach (var tx in transactions)
        {
            if (tx.Launcher.Name.Equals(nameLauncher, StringComparison.OrdinalIgnoreCase))
            {
                count++;
            }
        }
        return count;
    }


}// class
