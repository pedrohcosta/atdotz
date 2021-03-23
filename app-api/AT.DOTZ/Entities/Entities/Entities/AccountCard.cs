using Entities.Entities.Validations;
using FluentValidation.Results;
using Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    public class AccountCard : Base
    {
        //ContaCartao (Id, ContaId, Numero, TipoCartao, Habilitado, Data)

        
        public AccountCard() : base()
        {
            Active = true;
            Data = DateTime.Now;
        }
      
        public Guid AccountId { get; set; }
        public Account Account { get; set; }

        public string Number { get; set; }
        public TypeCard Type { get; set; }
        public bool Active { get; set; }

        public DateTime Data { get; set; }

        public override bool IsValid()
        {
            ValidationResult results = new AccountCardValidation().Validate(this);
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
