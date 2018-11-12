using NHibernate;
using SimpleNotes.Core.Object;
using SimpleNotes.Core.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNotes.Core.Repository.Implementation
{
    public class TagRepository : ITagRepository
    {
        private readonly ISession _session;
        public TagRepository(ISession session)
        {
            _session = session;
        }
        public void TagC(string[] Tag, int id )
        {
            foreach (var item in Tag)
            {
                var entity = _session.QueryOver<Tag>()
                .And(u => u.Name == item)
                .SingleOrDefault();
                if(entity == null)
                {
                    entity = new Tag
                    {
                        Name = item
                    };
                    _session.SaveOrUpdate(entity);
                }
                string sql = "INSERT INTO Note_Tag (Note_id, Tag_id) VALUES('note', 'tag')";
                sql = sql.Replace("log", id.ToString()).Replace("pas", entity.Id.ToString());
                IQuery q = _session.CreateSQLQuery(sql);
                int a = q.ExecuteUpdate();
            }
        }
    }
}
