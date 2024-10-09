using Lottery.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Models;

internal class Player : IPlayer
{
    public Player(int id, string name, int bankBalance)
    {
        Id = id;
        Name = name;
        BankBalance = bankBalance;
    }

    public int Id { get;  }

    public string Name { get;  }

    public int BankBalance { get; set; }
}
