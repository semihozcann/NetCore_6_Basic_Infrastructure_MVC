using Core.Entities.Concrete;
using Core.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {

        Task<List<OperationClaim>> GetClaims(User user);
        Task AddAsync(User user);
        Task<User> GetByMail(string email);

    }
}
