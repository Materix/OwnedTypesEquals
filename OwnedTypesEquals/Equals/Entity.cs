using System.ComponentModel.DataAnnotations;

namespace OwnedTypesEquals.Equals
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }

        public TransliteratedString Name { get; set; }
    }
}