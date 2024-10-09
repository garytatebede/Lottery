using Lottery.Models;

namespace Lottery.Interfaces.Repositories;

internal interface ITicketRepository
{
    Ticket Create(int playerId);
    Ticket Get(int ticketId);
    IEnumerable<Ticket> GetAll();
    void SetTicketToDrawn(int ticketId);
}
