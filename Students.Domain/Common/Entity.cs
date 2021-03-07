using System.ComponentModel.DataAnnotations;

namespace Students.Domain.Common
{
    public abstract class Entity
    {
        protected Entity(int id)
        {
            _Id = id;
        }
        
        [Key]
        public int _Id { get; protected set; }

        
    }
}