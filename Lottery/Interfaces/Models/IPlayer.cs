using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Interfaces.Models
{
    internal interface IPlayer
    {
        int Id { get; }
        string Name { get; }
        int BankBalance { get; }
    }
}
