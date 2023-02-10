using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.Dtos.Examples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IExampleService
    {
        //Bu kısım yapılmak istenilen işlemlerin metot imzalarını tutar. 
        //Repositoryden farklıdır. Core katmanında bulunan Repository nesneleri veri erişim kodlarını barındırır ve bize manager classı içerisinde istediğimiz her işlemi yapabilmemizi sağlar. Burada da manager classı içerisinde yapacağımız işleme göre imzalarımızı yazabiliriz.
        //Bu kısımda yapılan işleme göre metot isimleri verilir ve ilgili imzalar oluşturulur.

        Task<IDataResult<ExampleDto>> GetByIdAsync(int exampleId);
        Task<IDataResult<ExampleListDto>> GetAllAsync();
        Task<IResult> AddAsync(ExampleAddDto exampleAddDto);
        Task<IResult> UpdateAsync(ExampleUpdateDto exampleUpdateDto);
        Task<IResult> DeleteAsync(int exampleId);
    }
}
