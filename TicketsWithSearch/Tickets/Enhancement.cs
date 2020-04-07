namespace TicketsFull.Tickets
{
    public class Enhancement: Ticket
    {
        public double cost { get; set; }

        public double estimate { get; set; }

        public string software { get; set; }

        public string reason { get; set; }

        public override string ToString()
        {
            return $"{ticketId},{status},{summary},{priority},{submitter},{assigned},{watching},{software},{cost},{reason},{estimate}";
        }
    }
}