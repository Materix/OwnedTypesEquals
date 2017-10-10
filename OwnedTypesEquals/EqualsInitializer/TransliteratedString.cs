namespace OwnedTypesEquals.EqualsInitializer
{
    public class TransliteratedString
    {
        public string Value { get; set; }

        public string OriginalValue { get; set; }

        public string Language { get; set; }

        protected bool Equals(TransliteratedString other)
        {
            return string.Equals(Value, other.Value) && string.Equals(OriginalValue, other.OriginalValue) && string.Equals(Language, other.Language);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;

            return Equals((TransliteratedString)obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Value != null ? Value.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (OriginalValue != null ? OriginalValue.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Language != null ? Language.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(TransliteratedString value, TransliteratedString other)
        {
            if (ReferenceEquals(value, other))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if ((object)value == null || (object)other == null)
            {
                return false;
            }

            return string.Equals(value.Value, other.Value) &&
                   string.Equals(value.Language, other.Language) &&
                   string.Equals(value.OriginalValue, other.OriginalValue);
        }

        public static bool operator !=(TransliteratedString value, TransliteratedString other)
        {
            if (ReferenceEquals(value, other))
            {
                return false;
            }

            // If one is null, but not both, return false.
            if ((object)value == null || (object)other == null)
            {
                return true;
            }

            return !string.Equals(value.Value, other.Value) ||
                   !string.Equals(value.Language, other.Language) ||
                   !string.Equals(value.OriginalValue, other.OriginalValue);
        }
    }
}
