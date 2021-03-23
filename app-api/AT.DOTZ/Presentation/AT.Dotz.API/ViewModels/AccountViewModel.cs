using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AT.Dotz.API.ViewModels
{
    public class AccountViewModel
    {
        public Guid Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public string Number { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public bool Active { get; set; }
        public DateTime Data { get; set; }
        public decimal Balance { get; set; }
        public int Dotz { get; set; }
    }

    public class CreateAccountViewModel
    {
        [Required(ErrorMessage = "O campo 'Nome' é obrigatório")]
        [DisplayName("Nome")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo 'E-mail' é obrigatório")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail no formato inválido.")]
        [DisplayName("E-mail")]
        public string Mail { get; set; }
    }

    public class PaymentViewModel
    {   
        [Required(ErrorMessage = "O campo 'Conta' é obrigatório")]
        [DisplayName("Conta")]
        public Guid AccountId { get; set; }
        [Required(ErrorMessage = "O campo 'Documento' é obrigatório")]
        [DisplayName("Documento")]
        public string DocumentCode { get; set; }
        [Required(ErrorMessage = "O campo 'Valor' é obrigatório")]
        [DisplayName("Valor")]
        public decimal Amount { get; set; }
        public string Observation { get; set; }
    }

    public class AccountExtractViewModel
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }
        public string DocumentCode { get; set; }
        public int Type { get; set; }
        public decimal Amount { get; set; }
        public string Observation { get; set; }
        public int Peso { get; set; }
        public int Dotz { get; set; }
    }

    public class AccountCardViewModel
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public string Number { get; set; }
        public int Type { get; set; }
        public bool Active { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }
    }
}
