using Microsoft.AspNetCore.Mvc;
using SupportTicketApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportTicketAPI.Controllers 
{
    [ApiController]
    [Route("Ticket")]
    public class SupportTicketController : ControllerBase
    {

        [HttpGet("test")]
        public string Test()
        {
            return "Hello, World!";
        }

        [HttpGet("GetAll")]
        public ActionResult<List<SupportTicket>> Get()
        {
            return Ok(DataContext.Tickets);
        }

        [HttpPost("AddOrUpdate")]
        public ActionResult<SupportTicket> AddOrUpdate([FromBody]SupportTicket ticket)
        {
            if(ticket == null)
            {
                return BadRequest();
            }

            if(ticket.Id == Guid.Empty)
            {
                ticket.Id = Guid.NewGuid();
                DataContext.Tickets.Add(ticket);
            } else
            {
                var ticketToSync = DataContext.Tickets.FirstOrDefault(t => t.Id.Equals(ticket.Id));
                var index = DataContext.Tickets.IndexOf(ticketToSync);
                DataContext.Tickets.RemoveAt(index);
                DataContext.Tickets.Insert(index, ticket);
            }


            return Ok(ticket);
        }

        [HttpPost("Delete")]
        public ActionResult<SupportTicket> Delete([FromBody]Guid id)
        {
            var ticketToRemove = DataContext.Tickets.FirstOrDefault(t => t.Id.Equals(id));
            if(ticketToRemove?.Id != Guid.Empty)
            {
                DataContext.Tickets.Remove(ticketToRemove);
            }

            return ticketToRemove;
        }
    }
}
