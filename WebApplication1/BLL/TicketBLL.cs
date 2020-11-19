using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.DAL;
using WebApplication1.Models;

namespace WebApplication1.BLL
{
    public class TicketBLL : ITicket
    {
        private TicketInterface ticket_repo;

        public TicketBLL()
        {
            ticket_repo = new Ticket_DAL();
        }

        public bool CancelTicket(int TicketId)
        {
            return ticket_repo.CancelTicket(TicketId);
        }

        public bool ChangeTicket(int TicketId, Ticket editTicket)
        {
            return ticket_repo.ChangeTicket(TicketId, editTicket);
        }

        public bool CreateTicket(Ticket newTicket)
        {
            return ticket_repo.CreateTicket(newTicket);
        }

        public List<Receipt> GetReceiptList()
        {
            return ticket_repo.GetReceiptList();
        }

        public List<Ticket> GetTicketList()
        {
            return ticket_repo.GetTicketList();
        }

        public Ticket TicketDetails(Ticket ticket)
        {
            return ticket_repo.TicketDetails(ticket);
        }
    }
}