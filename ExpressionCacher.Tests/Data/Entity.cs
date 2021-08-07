namespace ExpressionCacher.Tests.Data
{
    public abstract class BaseEntity
    {
        public int Int { get; set; }
        public int? IntNullable { get; set; }
        public string String { get; set; }
        public string? StringNullable { get; set; }
        public bool Boolean { get; set; }
        public bool? BooleanNullable { get; set; }
        public long Long { get; set; }
        public long? LongNullable { get; set; }
        public Status Status { get; set; }
        public char Char { get; set; }
        public char? CharNullable { get; set; }
        public SubEntity A { get; set; }

        #region Nested classes

        public class SubEntity
        {
            public int Id { get; set; }
        }

        #endregion
    }

    public class EntityA : BaseEntity
    {
    }

    public class EntityB : BaseEntity
    {
    }

    public enum Status
    {
        A1,
        A2
    }
}