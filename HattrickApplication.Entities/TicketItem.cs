namespace HattrickApplication.Entities
{
    public class TicketItem
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public int EventId { get; set; }
        public string TipType { get; set; }
        public decimal TipOdd { get; set; }
        public virtual Ticket Ticket { get; set; }
        public virtual Event Event { get; set; }
    }
}