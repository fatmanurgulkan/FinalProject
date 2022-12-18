using System;
using Entities.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Category : IEntıty    // cıplak class kalmasın
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }



       


    }
