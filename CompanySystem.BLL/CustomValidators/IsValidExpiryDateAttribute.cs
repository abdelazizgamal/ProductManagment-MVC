using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace CompanySystem.BLL
{
    public class IsValidExpiryDateAttribute : ValidationAttribute, IClientModelValidator
    {
        private readonly int minMonths;

        public IsValidExpiryDateAttribute()
        {
            minMonths = 1;
        }
        public IsValidExpiryDateAttribute(int _minMonths)
        {
            minMonths = _minMonths;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            if (value == null)
            {
                return new ValidationResult("ExpiryDate Is Required!!");
            }
            if (value is not DateOnly EXP)
            {
                return new ValidationResult("Invalid Date format!!");
            }

            var today = DateOnly.FromDateTime(DateTime.Today);

            int expiry = ((EXP.Year - today.Year) * 12) + (EXP.Month - today.Month);
            if (expiry < minMonths)
            {
                return new ValidationResult("Expiry less than 1 month!!");
            }
            return ValidationResult.Success;
        }
        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-minMonths", $"Minimum Expiry Months is {minMonths}.");
            context.Attributes.Add("data-val-minMonths-months", minMonths.ToString());
        }
    }
}
