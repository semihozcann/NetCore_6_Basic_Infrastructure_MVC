using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {

        #region Injection

        IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #endregion


        #region AddAsync

        public async Task AddAsync(User user)
        {
            await _userRepository.AddAsync(user);
            await _userRepository.SaveAsync();


        }

        #endregion

        #region GetByMail

        public async Task<User> GetByMail(string email)
        {
            return await _userRepository.GetAsync(u => u.Email == email);
        }

        #endregion

        #region GetClaims

        public async Task<List<OperationClaim>> GetClaims(User user)
        {
            return await _userRepository.GetClaims(user);
        }

        #endregion


    }
}
