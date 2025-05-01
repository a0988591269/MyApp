namespace MyApp.Domain.Entities
{
    public class Character
    {
        public Guid Id { get; set; }
        public string Nickname { get; set; }
        public string Classes { get; set; }
        public int Level { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid PlayerId { get; set; }
        public Player Player { get; set; }
    }
}
