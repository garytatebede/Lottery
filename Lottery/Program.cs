using Lottery.Models;
using Lottery.Repositories;
using Lottery.Services;

List<LotteryPrize> lotteryPrizes = 
    [
    new LotteryPrize(40, 1, 1),
    new LotteryPrize(20, 2, 2),
    new LotteryPrize(5, 4, 3)
    ];


LotteryService _lotteryService = new
    (
    new LotteryConfiguration(lotteryPrizes, 1),
    new PlayerRepository(),
    new TicketRepository()
    );

_lotteryService.Setup();
_lotteryService.StartLottery();
_lotteryService.DebugPrint();