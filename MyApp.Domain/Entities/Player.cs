namespace MyApp.Domain.Entities
{
    public class Player
    {
        public Guid Id { get; set; }
        public string Account { get; set; }
        public string AccountType { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<Character> Characters { get; set; }
        public Player()
        {
            CreatedDate = DateTime.Now;
        }
    }
}
