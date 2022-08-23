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
        //we can give as many as IResults types in method parameter.
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    //to check parameters which logic is failed.
                    return logic;
                }
            }
            return null;
        }
        
        public static List<IResult> GetErrors(params IResult[] logics)
        {
            List<IResult> errorResults = new List<IResult>();
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    errorResults.Add(logic);
                }
            }
            return errorResults;
        }
    }
}