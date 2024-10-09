using Lottery.Interfaces.Models;
using Lottery.Interfaces.Repositories;
using Lottery.Interfaces.Services;
using Lottery.Models;

namespace Lottery.Services;

internal class LotteryService : ILotteryService
{
    private ILotteryConfiguration _lotteryConfiguration { get; }
    private IPlayerRepository _playerRepository { get; }
    private ITicketRepository _ticketRepository { get; }

    public LotteryService(
        ILotteryConfiguration lotteryConfiguration,
        IPlayerRepository playerRepository,
        ITicketRepository ticketRepository)
    {
        _lotteryConfiguration = lotteryConfiguration;
        _playerRepository = playerRepository;
        _ticketRepository = ticketRepository;
    }

    public void StartLottery()
    {
        var winners = DrawTickets();

        foreach (var winner in winners)
        {
            var playerWinner = _playerRepository.Get(winner.PlayerId);
            _playerRepository.AdjustBankBalance(winner.PlayerId, winner.Amount);

            Console.WriteLine($"{playerWinner.Name} has won the #{winner.Position} prize worth {winner.Amount}");
        }
    }

    public IEnumerable<PrizeWinner> DrawTickets()
    {
        List<PrizeWinner> prizeWinners = [];

        foreach (LotteryPrize prize in _lotteryConfiguration.LotteryPrizes)
        {
            for (int i = 0; i < prize.AmountOfWinners; i++)
            {
                var ticket = DrawRandomTicket();

                prizeWinners.Add(new PrizeWinner(ticket, prize.Prize, prize.Priority));
            }
        }

        return prizeWinners;
    }

    private Ticket DrawRandomTicket()
    {
        var tickets = _ticketRepository.GetAll();

        var validTickets = tickets.Where(x => !x.HasBeenDrawn).ToList();

        // Get a random index
        var random = new Random();

        var drawnTicket = validTickets[random.Next(0, validTickets.Count)];

        Console.WriteLine($"Ticket {drawnTicket.Id} by {_playerRepository.Get(drawnTicket.PlayerId).Name} has been drawn!");
        _ticketRepository.SetTicketToDrawn(drawnTicket.Id);

        return drawnTicket;
    }

    public void BuyTicket(int playerId)
    {
        var player = _playerRepository.Get(playerId);

        if (player.BankBalance < _lotteryConfiguration.TicketPrice)
            return; // this is a duplicate of the check in the repository

        // Not the best to use a negative of the value
        _playerRepository.AdjustBankBalance(playerId, -_lotteryConfiguration.TicketPrice);

        var ticket = _ticketRepository.Create(player.Id);

        Console.WriteLine($"{player.Name} bought ticket #{ticket.Id}");
    }

    // Bottom two methods are test methods that I wasn't sure where else to put
    public void Setup()
    {
        _playerRepository.Create("Gary", 10);
        for (int i = 1; i < 10; i++)
        {
            _playerRepository.Create($"Bot {i}", 10);
        }

        var players = _playerRepository.GetAll();

        foreach (var player in players)
        {
            var random = new Random();

            for (int i = 0; i < random.Next(1, 4); i++)
                BuyTicket(player.Id);
        }
    }

    // Post game debug prints
    public void DebugPrint()
    {
        Console.WriteLine("------------\nTickets:");
        foreach (var ticket in _ticketRepository.GetAll())
        {
            var player = _playerRepository.Get(ticket.PlayerId);
            Console.WriteLine($"Ticket {ticket.Id}, {player.Name}, {(ticket.HasBeenDrawn ? "" : "not ")}drawn.");
        }

        Console.WriteLine("------------\nPlayers:");
        foreach (var player in _playerRepository.GetAll())
        {
            Console.WriteLine($"{player.Name} has {player.BankBalance} in the bank.");
        }
    }
}
