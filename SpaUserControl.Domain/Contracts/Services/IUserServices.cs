﻿using SpaUserControl.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaUserControl.Domain.Contracts.Services
{
    public interface IUserServices : IDisposable
    {

        User Authenticate(string email, string password);

        User GetByEmail(string email);

        void Register(string name, string email, string password, string confirmPassword);

        void ChangeInformation(string email, string name);

        void ChangePassword(string email, string password, string newPassword, string confirmNewPassword);

        void Resetpassword(string email);

        List<User> GetByRange(int skip, int take);

    }
}
