using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.BLL
{
    public interface ITicket
    {
        List<Ticket> GetTicketList();
        List<Receipt> GetReceiptList();

        Ticket TicketDetails(Ticket ticket);

        bool CancelTicket(int TicketId);

        bool ChangeTicket(int TicketId, Ticket editTicket);

        bool CreateTicket(Ticket newTicket);

    }
}
