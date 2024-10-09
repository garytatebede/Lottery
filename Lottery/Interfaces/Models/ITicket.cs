using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Interfaces.Models
{
    internal interface ITicket
    {
        int Id { get; }
        int PlayerId { get; }
        bool HasBeenDrawn { get; set; }
    }
}
