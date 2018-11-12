using SimpleNotes.Core.Object;


namespace SimpleNotes.Core.Repository.Interface
{
    public interface IUserRepository
    {
        void RegUser(User user);
        User User(string name);
        bool SerchUser(string name, string password);
    }
}
