using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        //İş kurallarınıın hepsini sırayla kontrol eden bir fonksiyondur. 
        //Run isminde static bir metot yazılmıştır.
        //Bütün iş kuralları geriye IResult döndüğü için Run metoduna paramatre olarak bir IResult array verilmiştir.

        public static Task<IResult> Run(params Task<IResult>[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Result.Success)
                {
                    return logic;
                }

            }
            return null;
        }
    }
}
