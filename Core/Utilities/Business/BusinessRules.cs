using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics) // params ile istedeigin kadar parametre yollama 
        {
            foreach (var logic in logics)
            {
                if (!logic.Success) //basarısız olanı bildırıyor. kural bu logic dedıgı.
                {
                    return logic;
                }
            }
            return null;
        }
    }
}
