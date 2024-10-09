using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Models;

internal class PrizeWinner
{
    public PrizeWinner(Ticket ticket, int amount, int position)
    {
        TicketId = ticket.Id;
        PlayerId = ticket.PlayerId;
        Amount = amount;
        Position = position;
    }

    public int TicketId { get; set; }
    public int PlayerId { get; set; }
    public int Amount { get; }
    public int Position { get; }
}
