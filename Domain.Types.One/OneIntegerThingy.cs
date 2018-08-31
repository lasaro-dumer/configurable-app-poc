namespace Domain.Types.One
{
    public class OneIntegerThingy
    {
        public int OneProperty { get; set; }
        public int AnotherProperty { get; set; }
        public int YetAnotherProperty { get; set; }

        public override string ToString()
        {
            return $"{OneProperty}.{AnotherProperty}.{YetAnotherProperty}";
        }
    }
}
