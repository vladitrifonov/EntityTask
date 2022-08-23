namespace EntityTask.Domain.Entities
{
    public class Entity
    {
        public Guid Id { get; set; }
        public DateTime OperationDate { get; set; }
        public decimal Amount { get; set; }
        public Entity()
        {
            this.Id = Guid.NewGuid();
            this.OperationDate = DateTime.Now;
        }
    }
}
