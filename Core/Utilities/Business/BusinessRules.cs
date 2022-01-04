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
        public static IResult Run(params IResult[] logics)//farklı sayılarda business function gelebilir params kullandık
        {
            foreach (var logic in logics)//gelen functionlara bak
            {
                if (!logic.Success)//başarılı değilse hata
                {
                    return logic;
                }
            }
            return null;
        }
    }
}
