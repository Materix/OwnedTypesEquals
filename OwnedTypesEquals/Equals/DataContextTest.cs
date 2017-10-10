using System.Linq;
using FluentAssertions;
using Xunit;

namespace OwnedTypesEquals.Equals
{
    public class DataContextTest
    {
        private readonly DataContextCreator _dataContextCreator;

        public DataContextTest()
        {
            _dataContextCreator = new DataContextCreator();
        }

        [Fact]
        public void EmptyTransliteratedString()
        {
            // Given
            using (var context = _dataContextCreator.CreateContext())
            {
                context.Add(new Entity
                {
                    Name = new TransliteratedString() // Because owned type cannot be null
                });
                context.SaveChanges();
            }

            Entity entity;

            // When

            using (var context = _dataContextCreator.CreateContext())
            {
                entity = context.Set<Entity>().First();

                // When
                context.SaveChanges(); // <-- Does not fail
            }

            // Then
            entity.Should().NotBeNull();
            entity.Name.Should().NotBeNull();
        }

        [Fact]
        public void NonEmptyTransliteratedString()
        {
            // Given
            const string value = "value";
            using (var context = _dataContextCreator.CreateContext())
            {
                context.Add(new Entity
                {
                    Name = new TransliteratedString
                    {
                        Value = value
                    }
                });
                context.SaveChanges();
            }

            Entity entity;

            // When
            using (var context = _dataContextCreator.CreateContext())
            {
                entity = context.Set<Entity>().First();

                context.SaveChanges(); // <-- Does not fail
            }

            // Then
            entity.Should().NotBeNull();
            entity.Name.Should().NotBeNull();
            entity.Name.Value.Should().Be(value);
        }
    }
}