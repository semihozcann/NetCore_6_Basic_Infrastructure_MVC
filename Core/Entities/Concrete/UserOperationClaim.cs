using Core.Entities.Abstract;

namespace Core.Entities.Concrete
{
    public class UserOperationClaim : BaseEntity, IEntity
    {
        //User ile OperationClaim nesneleri arasındaki ilişkiyi bu nesne üzrerinden kurarız. Aralarında çoka çok ilişki olduğundan bu nesne aracı tablo görevi görür.

        public int UserId { get; set; }
        public int OperationClaimId { get; set; }

        public User User { get; set; }
        public OperationClaim OperationClaim { get; set; }


    }
}
