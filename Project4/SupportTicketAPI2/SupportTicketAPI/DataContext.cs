using SupportTicketApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportTicketAPI
{
    public class DataContext
    {
        public static List<SupportTicket> Tickets = new List<SupportTicket> {
            //new SupportTicket { Title = "First Ticket", Description = "First Description", Id = Guid.NewGuid()},
            //new SupportTicket { Title = "Second Ticket", Description = "Second Description" , Id = Guid.NewGuid()},
            //new SupportTicket { Title = "Third Ticket", Description = "Third Description", Id = Guid.NewGuid()},
            //new SupportTicket { Title = "Fourth Ticket", Description = "Fourth Description", Id = Guid.NewGuid()},
        };
    }
}
