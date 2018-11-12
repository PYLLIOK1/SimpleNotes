using SimpleNotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNotes.Providers.Interface
{
    public interface IAuthProvider
    {
        bool IsLoggedIn { get; }
        bool Login(UserModel model);
        bool Register(RegModel model);
        void Logout();
    }
}
