namespace BusBookingApi.ValidationAttributes
{
    using System.ComponentModel.DataAnnotations;

    public class DniAttribute : ValidationAttribute
    {
        public DniAttribute(string message)
            : base(message)
        {
        }

        public DniAttribute()
            :  this ("El formato del DNI no es válido")
        {
        }

        public override bool IsValid(object? value)
        {

            if (value?.ToString()?.Length != 9) return false;

            return true;
        }
       
    }
}
