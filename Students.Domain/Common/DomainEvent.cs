using System.Collections.Generic;

namespace Students.Domain.Common
{

    public interface IHasDomainEvent
    {
        public List<DomainEvent> DomainEvents { get; set; }
        
    }

    public abstract class DomainEvent 
    { }
}