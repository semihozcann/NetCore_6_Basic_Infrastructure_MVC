using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class ExampleRepository : BaseEntityRepository<Example>, IExampleRepository
    {
        //Example nesnesi için veri erişim kodlarını gövdeleri ile birlikte bulundurur. 
        public ExampleRepository(DbContext context) : base(context)
        {
        }
    }
}
