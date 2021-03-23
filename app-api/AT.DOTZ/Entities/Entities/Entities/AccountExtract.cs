using Entities.Entities.Validations;
using FluentValidation.Results;
using Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    public class AccountExtract : Base
    {
        //ContaHistorico (ContaId, Data, Doc, Valor, Tipo, Observacao, Peso, Dotz) 

        public AccountExtract() : base()
        {
            Data = DateTime.Now;
           /// Id = Guid.Parse("");
        }
        
        public Guid AccountId { get; set; }
        public Account Account { get; set; }
        
        public DateTime Data { get; set; }
        public string DocumentCode { get; set; }
        public TypeEvent Type { get; set; }
        public decimal Amount { get; set; }
        public string Observation { get; set; }
        public int Peso { get; set; }
        public int Dotz { get; set; }

        public override bool IsValid()
        {
            ValidationResult results = new AccountExtractValidation().Validate(this);
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
