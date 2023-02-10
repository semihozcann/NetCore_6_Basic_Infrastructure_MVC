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
        Task<IDataResult<ExampleDto>> GetAsync(int exampleId);
        Task<IDataResult<ExampleListDto>> GetAllAsync();
        Task<IResult> AddAsync(ExampleAddDto exampleAddDto);
        Task<IResult> UpdateAsync(ExampleUpdateDto exampleUpdateDto);
        Task<IResult> DeleteAsync(int exampleId);
    }
}
