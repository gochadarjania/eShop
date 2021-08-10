using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace eShop.DomainModel.Entity
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public Guid? SessionId { get; set; }
        public bool IsActive { get; set; }
        public string ActivateCode { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordHashRepeat { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateChanged { get; set; }
        public DateTime? DateDeleted { get; set; }

        public void Set(UserEntity user)
        {
            Id = user.Id;
            SessionId = user.SessionId;
            IsActive = user.IsActive;
            ActivateCode = user.ActivateCode;
            Email = user.Email;
            PasswordHash = user.PasswordHash;
            FirstName = user.FirstName;
            LastName = user.LastName;
            DateCreated = user.DateCreated;
            DateChanged = user.DateChanged;
            DateDeleted = user.DateDeleted;
        }

        public UserEntity Get(UserOperationType userOperation)
        {
            switch (userOperation)
            {
                case UserOperationType.Login:
                    this.SessionId = Guid.NewGuid();
                    break;
                case UserOperationType.Registration:

                    break;
                case UserOperationType.Activation:

                    break;
                default:
                    break;
            }

            return this;
        }

        public List<string> Isvalid(UserValidationType validationType)
        {
            switch (validationType)
            {
                case UserValidationType.Login:
                    return LoginValidation();
                    //break;
                case UserValidationType.Registration:
                    return RegistrationValidation();
                   // break;
                case UserValidationType.Activation:
                    return ActivationValidation();
                   // break;
                default:
                    return new List<string>();
                    //break;
            }
        }

        private List<string> LoginValidation()
        {

            List<string> errorResult = new List<string>();

            if (string.IsNullOrEmpty(this.Email))
            {
                errorResult.Add(UserErrors.EMAIL_IS_EMPTY.ToString());
            }

            if (!Regex.IsMatch(this.Email, @"[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
            {
                errorResult.Add(UserErrors.EMAIL_IS_NOT_VALID.ToString());
            }

            if (string.IsNullOrEmpty(this.PasswordHash))
            {
                errorResult.Add(UserErrors.PASSWORD_IS_EMPTY.ToString());
            }

            return errorResult;
        }
        private List<string> RegistrationValidation()
        {
            return new List<string>();

        }
        private List<string> ActivationValidation()
        {
            return new List<string>();

        }

        public enum UserErrors
        {
            EMAIL_IS_EMPTY = 0,
            EMAIL_IS_NOT_VALID = 1,
            PASSWORD_IS_EMPTY = 2,
            PASSWORD_IS_NOT_MATCH = 3
        }

        public enum UserValidationType
        {
            Login = 0,
            Registration = 1,
            Activation = 2
        }

        public enum UserOperationType
        {
            Login = 0,
            Registration = 1,
            Activation = 2
        }
    }
}
