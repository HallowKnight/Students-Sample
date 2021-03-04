using System.Collections.Generic;
using MediatR;

namespace Students.Domain.Common
{

    public interface IHasDomainEvent
    {
        public List<DomainEvent> DomainEvents { get; set; }
        
    }

    public class DomainEvent 
    {
        
        public int Id { get; set; }
    }
}