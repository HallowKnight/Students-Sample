using System.ComponentModel.DataAnnotations;

namespace Students.Domain.Common
{
    public abstract class Entity
    {
        [Key]
        private int _Id;

        public virtual int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }
    }
}