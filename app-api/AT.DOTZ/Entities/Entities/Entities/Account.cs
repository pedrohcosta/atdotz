using Entities.Entities.Validations;
using Entities.Enum;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class Account : Base
    {
        //Conta (ID, Nome, Email, Habilitado, Data, Saldo, Dotz)

        public Account() : base()
        {
            Random Random = new Random();

            Active = true;
            Data = DateTime.Now;
            Number = Random.Next().ToString();

           AccountCard = new List<AccountCard>();
            AccountExtract = new List<AccountExtract>();
        }

        public string Number { get; set; }

        public string Name { get; set; }

        public string Mail { get; set; }
        public bool Active { get; set; }
        public DateTime Data { get; set; }
        public decimal Balance { get; set; }
        public int Dotz { get; set; }
        public List<AccountCard> AccountCard { get; set; }
        public List<AccountExtract> AccountExtract { get; set; }

        public void Payment(Payment payment)
        {
            if (Balance >= payment.Amount)
            {
                int Peso = 10;
                var o = new AccountExtract
                {
                    AccountId = Id,
                    DocumentCode = payment.DocumentCode,
                    Amount = payment.Amount,
                    Observation = payment.Observation,
                    Peso = Peso,
                    Dotz = (int)(payment.Amount / Peso),
                    Type = TypeEvent.Payment
                };
                Balance -= payment.Amount;
                Dotz += (int)(payment.Amount / Peso);
                AccountExtract.Add(o);
            } else {
                AddErro("Saldo", "Saldo insuficiente");
            }
        }

        public override bool IsValid()
        {
            ValidationResult results = new AccountValidation().Validate(this);
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
