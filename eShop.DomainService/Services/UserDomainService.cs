using eShop.DomainModel.Entity;
using eShop.DomainService.RepositoriInterfaces;
using eShop.DomainService.ServiceInterfaces;
using eShop.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static eShop.DomainModel.Entity.UserEntity;

namespace eShop.DomainService.Services
{
    public class UserDomainService : IUserDomainService
    {
        IUserRepository _userRepository;
        public UserDomainService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool ChekSessionIsValid(Guid SessionID)
        {
            return _userRepository.ChekSessionID(SessionID);
        }

        public List<string> Login(UserEntity user)
        {
            List<string> validationResponse = new List<string>();
            validationResponse = user.Isvalid(UserValidationType.Login);

            if (validationResponse.Count == 0)
            {
                if (!_userRepository.Login(user.Get(UserOperationType.Login)))
                {
                    return new List<string>() { "EMAIL_PASSWORD_ACTIVATE_NOT_VALID" };
                }
                return validationResponse;
            }
            else
            {
                return validationResponse;
            }
        }

        public void LoginOut(Guid sessionID)
        {
            _userRepository.LoginOut(sessionID);
        }
    }
}
