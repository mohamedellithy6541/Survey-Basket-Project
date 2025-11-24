using System.ComponentModel.DataAnnotations;

namespace SurveyBasket.Api.Validation_Attribute
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class MaxLenghtSmallerThanNumberAttribute(int size) : ValidationAttribute
    {
        private readonly int _size = size;

        public override bool IsValid(object? value)
        {
            if (value is null) return false;
            if (value is int intval)
            {
                var text = Math.Abs(intval).ToString();
                return (text.Length <= _size)? true:false;
            }
            return true;
        }
    }
}
