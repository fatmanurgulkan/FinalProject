using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Customer:IEntıty
    {
        public string  CustomerId { get; set; }
        public string Contactname { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
    }
 
}
