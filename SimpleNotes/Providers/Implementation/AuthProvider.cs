using SimpleNotes.Core.Object;
using SimpleNotes.Core.Repository.Interface;
using SimpleNotes.Models;
using SimpleNotes.Providers.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace SimpleNotes.Providers.Implementation
{
    public class AuthProvider : IAuthProvider
    {
        private readonly IUserRepository _userRepository;
        public AuthProvider(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool IsLoggedIn
        {
            get
            {
                return HttpContext.Current.User.Identity.IsAuthenticated;
            }
        }

        public bool Login(UserModel model)
        {
            bool user = _userRepository.SerchUser(model.Name, model.Password);
            if (user == true)
            {
                FormsAuthentication.SetAuthCookie(model.Name, false);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }

        public bool Register(RegModel model)
        {
            bool user = _userRepository.SerchUser(model.Name, model.Password);
            if (user != true)
            {
                _userRepository.RegUser(new User { Name = model.Name, Password = model.Password });
                return true;
            }
            else
            {
                return false;
            }
        }

        public int SearchUser(string name)
        {
            User user = _userRepository.User(name);
            return user.Id;
        }
    }
}