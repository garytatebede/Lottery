using Lottery.Interfaces.Models;

namespace Lottery.Models;

internal class LotteryPrize : ILotteryPrize
{
    public int AmountOfWinners { get; }
    public int Prize { get; }
    public int Priority { get; }
    public LotteryPrize(int prize, int amountOfWinners, int priority)
    {
        AmountOfWinners = amountOfWinners;
        Prize = prize;
        Priority = priority;
    }
}
