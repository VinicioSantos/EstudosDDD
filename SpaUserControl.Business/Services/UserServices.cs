using SpaUserControl.Common.Resources;
using SpaUserControl.Domain.Contracts.Repositories;
using SpaUserControl.Domain.Contracts.Services;
using SpaUserControl.Domain.Models;
using System;
using System.Collections.Generic;

namespace SpaUserControl.Business.Services
{
    public class UserServices : IUserServices
    {

        private IUserRepository _repository;


        public UserServices(IUserRepository repository)
        {
            this._repository = repository;
        }

        public User Authenticate(string email, string password)
        {

            var user = GetByEmail(email);

            return user;

        }

        public void ChangeInformation(string email, string name)
        {
            var user = GetByEmail(email);
            user.ChangeName(name);
            user.Validate();

            _repository.Update(user);

        }

        public void ChangePassword(string email, string password, string newPassword, string confirmNewPassword)
        {
            var user = Authenticate(email, password);

            user.SetPassword(newPassword, confirmNewPassword);
            user.Validate();

            _repository.Update(user);
        }


        public User GetByEmail(string email)
        {
            var user = _repository.Get(email);

            if (user == null)
                throw new Exception(Errors.UserNotFound);

            return user;
        }

        public void Register(string name, string email, string password, string confirmPassword)
        {
            var hasUser = _repository.Get(email);

            if (hasUser != null)
                throw new Exception(Errors.DuplicateUser);

            var user = new User(name, email);
            user.SetPassword(password, confirmPassword);
            user.Validate();

            _repository.Create(user);
        }

        public void Resetpassword(string email)
        {
            throw new NotImplementedException();
        }

        public List<User> GetByRange(int skip, int take)
        {
            return _repository.Get(skip, take);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }


    }
}
