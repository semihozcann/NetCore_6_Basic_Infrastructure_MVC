using Core.Entities.Abstract;

namespace Core.Entities.Concrete
{
    public class OperationClaim : BaseEntity, IEntity
    {
        //Yetkilendirme için bu nesne üzerinden istediğimiz isimde yetkili isimleri oluşturabiliriz. (admin, manager vb.)

        public string Name { get; set; }
    }
}
