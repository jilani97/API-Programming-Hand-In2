using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class Ticket_DAL : TicketInterface
    {
        public bool CancelTicket(int TicketId)
        {
            using (var db = new TrainTicketContext())
            {
                try
                {
                    Ticket changeTicket = db.Tickets.Find(TicketId);
                    changeTicket.IsValid = false;

                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool ChangeTicket(int TicketId, Ticket editTicket)
        {
            using (var db = new TrainTicketContext())
            {
                try
                {
                    Ticket changeTicket = db.Tickets.Find(TicketId);
                    changeTicket.AdultsTravelling = editTicket.AdultsTravelling;
                    changeTicket.ChildrenTravelling = editTicket.ChildrenTravelling;
                    changeTicket.DestinationFrom = editTicket.DestinationFrom;
                    changeTicket.DestinationTo = editTicket.DestinationTo;
                    changeTicket.StudentsTravelling = editTicket.StudentsTravelling;
                    changeTicket.TravelDate = editTicket.TravelDate;
                    changeTicket.TravelTime = editTicket.TravelTime;
                    changeTicket.IsValid = editTicket.IsValid;
                    changeTicket.route = editTicket.route;
                                       
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {                  
                  return false;
                }
            }
        }

        public bool CreateReceipt(Ticket ticket)
        {
            var CreateReceipt = new Receipt()
            {
                PurchaseDate = DateTime.Now,
                Ticket = ticket
            };

            var db = new TrainTicketContext();
            try
            {
                db.Receipts.Add(CreateReceipt);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CreateTicket(Ticket newTicket)
        {            
            var db = new TrainTicketContext();

            var CreateTicket = new Ticket()
            {
                AdultsTravelling = newTicket.AdultsTravelling,
                ChildrenTravelling = newTicket.ChildrenTravelling,
                DestinationFrom = newTicket.DestinationFrom,
                DestinationTo = newTicket.DestinationTo,
                IsValid = newTicket.IsValid,
                route = newTicket.route,
                StudentsTravelling = newTicket.StudentsTravelling,
                TravelDate = newTicket.TravelDate,
                TravelTime = newTicket.TravelTime,
                User = db.Users.Where(x => x.UserId == 1).FirstOrDefault()
            };

            try
            {
                db.Tickets.Add(CreateTicket);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Receipt> GetReceiptList()
        {
            var db = new TrainTicketContext();
            List<Receipt> allReceipts = db.Receipts.ToList();
            return allReceipts;
        }

        public List<Ticket> GetTicketList()
        {
            var db = new TrainTicketContext();
            List<Ticket> allTickets = db.Tickets.ToList();
            return allTickets;
        }

        public Ticket TicketDetails(Ticket ticket)
        {
            var db = new TrainTicketContext();
            Ticket ticketId = db.Tickets.Where(x => x.TicketId == ticket.TicketId).FirstOrDefault();
            return ticketId;
        }
    }
}