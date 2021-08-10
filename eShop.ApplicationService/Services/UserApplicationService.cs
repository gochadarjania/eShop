using eShop.ApplicationService.ServiceInterfaces;
using eShop.DataTransferObject;
using eShop.DomainModel.Entity;
using eShop.DomainService.ServiceInterfaces;
using eShop.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.ApplicationService.Services
{
    public class UserApplicationService : IUserApplicationService
    {
        private IUserDomainService _userDomainService;

        public UserApplicationService(IUserDomainService userDomainService)
        {
            _userDomainService = userDomainService;
        }

        public UserAuthResponceDTO Login(LoginDTO loginDTO)
        {
            UserEntity userEntityModel = new UserEntity();

            userEntityModel.Set(AutoMapperExtensions.MapObject<LoginDTO, UserEntity>(loginDTO));

            return new UserAuthResponceDTO()
            {
                Messages = _userDomainService.Login(userEntityModel),
                SessionID = userEntityModel.SessionId
            };
        }
    }
}
