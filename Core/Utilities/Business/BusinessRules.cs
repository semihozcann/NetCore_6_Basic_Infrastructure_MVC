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
        //Metotlar asenkron çalıştığından Task ile işaretlenmiştir.
        //Yazılan Run metodu parametre olarak aldığı bütün metotları tek tek kontrol eder ve ErrorResult dönen olursa o hatayı kullanıcıya gönderir.

        public static Task<IResult> Run(params Task<IResult>[] logics)
        {
            foreach (var logic in logics) //Bütün metotları gez
            {
                if (!logic.Result.Success) //Metot sonucu başarılı değilse
                {
                    return logic; //Başarısız olan metotdu gönder
                }

            }
            return null; //Bütün metotlar başarılı ise null değer gönder.
        }
    }
}
