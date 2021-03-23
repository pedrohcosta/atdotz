using Entities.Entities.Validations;
using Entities.Enum;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class Payment : Base
    {
        
        public Payment() : base()
        {        
        }

        public Guid AccountId { get; set; }       
        public string DocumentCode { get; set; }
        public decimal Amount { get; set; }
        public string Observation { get; set; }

        public override bool IsValid()
        {
            ValidationResult results = new PaymentValidation().Validate(this);
            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    AddErro(failure.PropertyName, failure.ErrorMessage);
                }
            }
            return results.IsValid;
        }
    }
}
