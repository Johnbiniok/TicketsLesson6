using System;
using System.IO;

namespace TicketsFull.Tickets
{
    public class Task: Ticket
    {
        public string projectName { get; set; }

        public string dueDate { get; set; }

        public override string ToString()
        {
            return $"{ticketId},{status},{summary},{priority},{submitter},{assigned},{watching},{projectName},{dueDate}";
        }
    }
}