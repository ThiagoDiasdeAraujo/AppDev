using System.ComponentModel.DataAnnotations;

namespace WebApp.Validations
{
    public class ExpectedValue : ValidationAttribute
    {
        private object expectedValue;

        public ExpectedValue(object value)
        {
            expectedValue = value;
        }

        public override bool IsValid(object value)
        {
            if (value.Equals(expectedValue))
            {
                return true;
            }
            return false;
        }
    }
}
