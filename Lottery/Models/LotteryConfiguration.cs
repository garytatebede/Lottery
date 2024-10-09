using Lottery.Interfaces.Models;

namespace Lottery.Models
{
    internal class LotteryConfiguration : ILotteryConfiguration
    {
        public LotteryConfiguration(IEnumerable<ILotteryPrize> lotteryPrizes, int price)
        {
            LotteryPrizes = lotteryPrizes;
            TicketPrice = price;
        }

        public IEnumerable<ILotteryPrize> LotteryPrizes { get; }

        public int TicketPrice { get; }
    }
}
