using Lottery.Interfaces.Repositories;
using Lottery.Models;

namespace Lottery.Repositories;

internal class TicketRepository : ITicketRepository
{
    List<Ticket> _tickets;

    public TicketRepository(List<Ticket>? tickets = null)
    {
        _tickets = tickets ?? [];
    }

    public Ticket Create(int playerId)
    {
        var newId = _tickets.Count + 1;
        var ticket = new Ticket(newId, playerId);

        _tickets.Add(ticket);

        return ticket;
    }

    public Ticket Get(int ticketId)
    {
        return _tickets.First(x => x.Id == ticketId);
    }

    public IEnumerable<Ticket> GetAll()
    {
        return _tickets;
    }

    // is this worth a method in the repository
    public void SetTicketToDrawn(int ticketId)
    {
        var ticket = _tickets.First(x => x.Id == ticketId);

        // Same as above, need to verify
        ticket.HasBeenDrawn = true;
    }
}
