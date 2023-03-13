using System.ComponentModel.DataAnnotations;

namespace Students.Domain.Common
{
    public abstract class Entity
    {
        [Key] public int Id { get; }
    }
}