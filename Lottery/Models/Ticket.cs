using Lottery.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Models
{
    internal class Ticket : ITicket
    {
        public Ticket(int ticketId, int playerId, bool hasBeenDrawn = false)
        {
            Id = ticketId;
            PlayerId = playerId;
            HasBeenDrawn = hasBeenDrawn;
        }

        public int Id { get; }
        public int PlayerId { get; }
        public bool HasBeenDrawn { get; set; }
    }
}
