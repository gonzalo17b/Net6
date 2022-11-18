using System.ComponentModel.DataAnnotations;

namespace BusBookingApi.ValidationAttributes
{
    public class ContieneLetraAttribute : ValidationAttribute
    {

        public override bool IsValid(object? value)
        {
            if (value?.ToString()?.Length != 9) return false;

            return true;
        }
    }
}
