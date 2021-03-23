using Entities.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Entities
{
    public class Base : Notifies
    {
        

        public Base()
        {
            Id = Guid.NewGuid();
        }

        

        public Guid Id { get; set; }

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
