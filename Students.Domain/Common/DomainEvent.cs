using System.Collections.Generic;

namespace Students.Domain.Common;

public interface IHasDomainEvent
{
    public List<DomainEvent> DomainEvents { get; set; }
}

public class DomainEvent
{
    public int Id { get; set; }
}