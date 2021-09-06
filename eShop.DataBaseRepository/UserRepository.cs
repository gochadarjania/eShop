using eShop.DataBaseRepository.DB;
using eShop.DomainModel.Entity;
using eShop.DomainService.RepositoriInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DataBaseRepository
{
    public class UserRepository : IUserRepository
    {
        public bool Login(UserEntity UserModel)
        {
            using (eShopDbContext context = new eShopDbContext())
            {
                var query = (from user in context.Users
                             where user.Email == UserModel.Email &&
                             user.PasswordHash == UserModel.PasswordHash &&
                             user.IsActive == true &&
                             user.DateDeleted == null
                             select user).FirstOrDefault();

                if (query != null)
                {
                    query.SessionId = UserModel.SessionId;
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public bool ChekSessionID(Guid sessionID)
        {
            using (eShopDbContext context = new eShopDbContext())
            {
                var query = (from user in context.Users
                             where user.SessionId == sessionID &&
                             user.IsActive == true &&
                             user.DateDeleted == null
                             select user).FirstOrDefault();

                return query != null;
            }
        }

        public void LoginOut(Guid sessionID)
        {
            using (eShopDbContext context = new eShopDbContext())
            {
                var query = (from p in context.Users
                            where p.SessionId == sessionID
                            select p).FirstOrDefault();

                query.SessionId = null;
                context.SaveChanges();
            
            }
        }
    }
}

