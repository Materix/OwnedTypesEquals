using System.ComponentModel.DataAnnotations;

namespace OwnedTypesEquals.Initializer
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }

        public TransliteratedString Name { get; set; } = new TransliteratedString();
    }
}