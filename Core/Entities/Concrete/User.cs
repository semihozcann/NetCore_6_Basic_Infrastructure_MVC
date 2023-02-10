using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class User : BaseEntity, IEntity
    {
        //Sisteme kayıt yapan kullanıcı ve yönetilerin kayıt bilgilerini tutan nesnedir. Basit haldedir içeriği zenginleştirilebilir.

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }

    }
}
