using System.Transactions;

namespace GamesInventory.Models;

public class GameInventory
{
    private List<GameTx> transactions = new List<GameTx>();

    public void AddTransaction(GameTx transaction)
    {
        transactions.Add(transaction);
    }

    public void RemoveTransaction(GameTx transaction)
    {
        transactions.Remove(transaction);
    }

    public bool IsGameOwned(string title)
    {
        return TransactionUtils.IsGameOwned(transactions, title);
    }

    public decimal GetTotalSpentOnStore(string storeName)
    {
        return TransactionUtils.GetTotalSpentOnStore(transactions, storeName);
    }

    // Qual è il gioco (o i giochi) che ho pagato di più?
    public List<GameTx> GetMostPaidGame()
    {
        return TransactionUtils.GetMostPaidGame(transactions);

    }

    //  Quanto ho speso in un certo intervallo di tempo?

    public decimal GetTotalSpentInDateRange(DateOnly starDate, DateOnly endDate)
    {

        return TransactionUtils.GetTotalSpentInDateRange(transactions, starDate, endDate);
    }

    //Quanti giochi possiedo per una certa piattaforma/launcher

    public int GetCountGamesByPlatform(string namePlatform )
    {   
        return TransactionUtils.GetCountGamesByPlatform(transactions, namePlatform);
    }
    public int GetCountGamesByLauncher(string nameLauncher)
    {
        return TransactionUtils.GetCountGamesByLauncher(transactions, nameLauncher);
    }


}//class
