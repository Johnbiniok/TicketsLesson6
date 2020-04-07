namespace TicketsFull.Tickets
{
    public class Debug: Ticket
    {
        public string severity { get; set; }
        public override string ToString()
        {
            return $"{ticketId},{status},{summary},{priority},{submitter},{assigned},{watching},{severity}";
        }
    }
}