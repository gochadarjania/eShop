using eShop.DomainModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DomainService.ServiceInterfaces
{
    public interface IUserDomainService
    {
        List<string> Login(UserEntity User);
        bool ChekSessionIsValid(Guid SessionID);
        void LoginOut(Guid sessionID);

    }
}
