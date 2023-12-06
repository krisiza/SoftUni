using ValidationAttributes.Attributes.Contracts;

namespace ValidationAttributes.Attributes
{
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
            => obj is not null;
    }
}
