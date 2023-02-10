using AutoMapper;
using Entities.Concrete;
using Entities.Dtos.Examples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.AutoMapper
{
    public class MapperProfile : Profile
    {
        //Oluşturulan DTo nesneleri ile Entity nesnesinin propertylerini eşleştirmek için Map işlemi yapılmalıdır.
        public MapperProfile()
        {
            CreateMap<ExampleAddDto, Example>();
            CreateMap<ExampleUpdateDto, Example>();
            CreateMap<Example, ExampleUpdateDto>();
        }
    }
}
