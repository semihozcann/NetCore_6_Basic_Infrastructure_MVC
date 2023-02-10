using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Abstract
{
    public abstract class BaseEntity
    {
        //Bütün veri tabanı tablolarında ortak olacak propertyleri burada tanımlayabilirsiniz.

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } 
        public DateTime UpdatedDate{ get; set; }

    }
}
