using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Interfaces.Models;

internal interface ILotteryConfiguration
{
    IEnumerable<ILotteryPrize> LotteryPrizes { get; }
    int TicketPrice { get; }
}
