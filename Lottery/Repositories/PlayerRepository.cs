using Lottery.Interfaces.Repositories;
using Lottery.Models;

namespace Lottery.Repositories;

internal class PlayerRepository : IPlayerRepository
{
    List<Player> _players;

    public PlayerRepository(List<Player>? players = null)
    {
        _players = players ?? [];
    }

    public Player Create(string name, int bankBalance)
    {
        var newId = _players.Count + 1;
        var player = new Player(newId, name, bankBalance);

        _players.Add(player);

        return player;
    }

    public Player Get(int id)
    {
        return _players.First(x => x.Id == id);
    }

    public IEnumerable<Player> GetAll()
    {
        return _players;
    }

    public void AdjustBankBalance(int id, int delta)
    {
        var player = _players.First(x => x.Id == id);

        if (player.BankBalance + delta < 0)
            return; // Would want to do something if the player could not afford

        player.BankBalance += delta;
    }
}
