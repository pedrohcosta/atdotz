using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Notifications
{
    public class Notifies
    {
        public Notifies()
        {
            Notitycoes = new List<Notifies>();
        }

        [NotMapped]
        public string PropertyName { get; set; }

        [NotMapped]
        public string Message { get; set; }

        [NotMapped]
        public List<Notifies> Notitycoes;


        public void AddErro(string propertyName, string message)
        {
            Notitycoes.Add(new Notifies
            {
                Message = message,
                PropertyName = propertyName
            });
        }

        public bool ValidPropertyString(string value, string propertyName)
        {

            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(propertyName))
            {
                Notitycoes.Add(new Notifies
                {
                    Message = "Campo Obrigatório",
                    PropertyName = propertyName
                });

                return false;
            }

            return true;
        }

        public bool ValidPropertyInt(int value, string propertyName)
        {

            if (value < 1 || string.IsNullOrWhiteSpace(propertyName))
            {
                Notitycoes.Add(new Notifies
                {
                    Message = "Valor deve ser maior que 0",
                    PropertyName = propertyName
                });

                return false;
            }

            return true;

        }


        public bool ValidPropertyDecimal(decimal value, string propertyName)
        {

            if (value < 1 || string.IsNullOrWhiteSpace(propertyName))
            {
                Notitycoes.Add(new Notifies
                {
                    Message = "Valor deve ser maior que 0",
                    PropertyName = propertyName
                });

                return false;
            }

            return true;

        }
    }
}
