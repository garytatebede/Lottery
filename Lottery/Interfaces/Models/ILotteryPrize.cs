using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Interfaces.Models
{
    internal interface ILotteryPrize
    {
        int AmountOfWinners { get; }
        int Prize { get; }
    }
}
