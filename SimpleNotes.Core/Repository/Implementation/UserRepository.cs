using NHibernate;
using SimpleNotes.Core.Object;
using SimpleNotes.Core.Repository.Interface;

namespace SimpleNotes.Core.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ISession _session;
        public UserRepository(ISession session)
        {
            _session = session;
        }

        public bool SerchUser(string name, string password)
        {
            var entity = _session.QueryOver<User>()
                .And(u => u.Name == name && u.Password == password)
                .SingleOrDefault();
            if (entity != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RegUser(User user)
        {
            string sql = "INSERT INTO Users (Name, Password) VALUES('log', 'pas')";
            sql = sql.Replace("log", user.Name).Replace("pas", user.Password);
            IQuery q = _session.CreateSQLQuery(sql);
            int a = q.ExecuteUpdate();
        }

        public User User(string name)
        {

            var entity = _session.QueryOver<User>()
                .And(u => u.Name == name)
                .SingleOrDefault();
            return entity;
        }
    }
}
