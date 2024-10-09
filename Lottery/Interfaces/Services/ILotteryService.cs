using Lottery.Models;

namespace Lottery.Interfaces.Services;

internal interface ILotteryService
{
    void StartLottery();
    void BuyTicket(int playerId);
    IEnumerable<PrizeWinner> DrawTickets();
}
