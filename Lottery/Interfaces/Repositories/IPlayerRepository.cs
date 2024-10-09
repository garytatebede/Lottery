using Lottery.Interfaces.Models;
using Lottery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Interfaces.Repositories;

internal interface IPlayerRepository
{
    Player Create(string name, int bankBalance);
    Player Get(int id);
    IEnumerable<Player> GetAll();
    void AdjustBankBalance(int id, int delta);
}
