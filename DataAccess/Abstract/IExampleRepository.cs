using Core.DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IExampleRepository : IEntityRepository<Example>
    {
        // Example nesnesi için veri erişim fonksiyonlarının imzalarını tutar. 
        //İmzalar IEntityRepository içerisinden gelir jenerik yapı olduğundan burada Example nesnesi için çalışacağını bildirdik. Böylece bütün fonksiyonlar bu nesne için çalışacaktır.
    }
}
