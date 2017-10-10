using System.ComponentModel.DataAnnotations;

namespace OwnedTypesEquals.Nothing
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }

        public TransliteratedString Name { get; set; }
    }
}