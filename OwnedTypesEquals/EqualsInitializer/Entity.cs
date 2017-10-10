using System.ComponentModel.DataAnnotations;

namespace OwnedTypesEquals.EqualsInitializer
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }

        public TransliteratedString Name { get; set; } = new TransliteratedString();
    }
}