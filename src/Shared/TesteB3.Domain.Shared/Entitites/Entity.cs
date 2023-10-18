namespace TesteB3.Domain.Shared.Entitites
{
    public abstract class Entity
    {
        public int Id { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; private set; } 
    }
}
