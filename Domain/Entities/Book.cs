using NetDevPack.Domain;

namespace Domain.Entities
{
    public class Book : Entity, IAggregateRoot
    {
        public string Author { get; set; }
        public string Title { get; set; }
    }
}
