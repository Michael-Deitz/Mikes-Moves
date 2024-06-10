namespace MikesMoves.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public UserProfile Sender { get; set; }
        public UserProfile Receiver { get; set; }
    }

}