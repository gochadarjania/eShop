using eShop.DomainModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DomainService.RepositoriInterfaces
{
    public interface IUserRepository
    {
        bool Login(UserEntity User);
        bool ChekSessionID(Guid sessionID);
    }
}
