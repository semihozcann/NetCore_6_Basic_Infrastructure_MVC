using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Example : BaseEntity ,IEntity
    {
        //IEntity interface'sini implement ederek referans alırız.
        //BaseEntity impelente ederek içerisinde bulunan propertyleri Example nesnemize de vermiş oluruz.


        public string Name { get; set; }
        public string Description { get; set; }
    }
}
