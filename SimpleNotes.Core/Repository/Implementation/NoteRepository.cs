using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using SimpleNotes.Core.Object;
using SimpleNotes.Core.Repository.Interface;


namespace SimpleNotes.Core.Repository.Implementation
{
    public class NoteRepository : INoteRepository
    {
        private readonly ISession _session;
        public NoteRepository(ISession session)
        {
            _session = session;
        }
        public void Add(string name, int author, string ico, string path, bool published, string text, string[] Tag)
        {
            DateTime date = DateTime.Now;
            //string sql = "IF (OBJECT_ID('NoteAdd') IS NOT NULL) DROP PROCEDURE NoteAdd";

            
            //sql = "CREATE PROCEDURE[dbo].[NoteAdd]" +
            //    "(@Name nvarchar(255), @DateTime datetime2(7), @Path nvarchar(255), @Ico nvarchar(255), @Author int, @Text nvarchar(255), @Published bit) " +
            //    "AS BEGIN INSERT INTO Notes(Name, DateTime, Path, Ico, Author_id, Text, Published)VALUES(@Name, @DateTime, @Path, @Ico, @Author, @Text, @Published)END";
            //query = _session.CreateSQLQuery(sql);
            //a = query.ExecuteUpdate();
            IQuery query = _session.CreateSQLQuery("exec NoteAdd :Name, :Data, :Path, :Ico, :Author, :Text, :Published");
            query.SetParameter("Name", name);
            query.SetParameter("Data", date);
            query.SetParameter("Path", path);
            query.SetParameter("Ico", ico);
            query.SetParameter("Author", author);
            query.SetParameter("Text", text);
            query.SetParameter("Published", published);
            int a = query.ExecuteUpdate();
            int id_note = Notes(name, author);
            foreach (var item in Tag)
            {
                var entity = _session.QueryOver<Tag>()
                .And(u => u.Name == item)
                .SingleOrDefault();
                if (entity == null)
                {
                    entity = new Tag
                    {
                        Name = item
                    };
                    _session.SaveOrUpdate(entity);
                }
                string sql = "INSERT INTO Note_Tag (Note_id, Tag_id) VALUES('note', 'tag')";
                sql = sql.Replace("note", id_note.ToString()).Replace("tag", entity.Id.ToString());
                IQuery q = _session.CreateSQLQuery(sql);
                int b = q.ExecuteUpdate();
            }


        }

        public Note GetNote(int id)
        {
            var Note = _session.Get<Note>(id);
            return Note;
        }

        public IList<Note> GetNoteList()
        {
            int num = 30;
            var Notes = _session.QueryOver<Note>()
                .And(x=>x.Published == true)
                .List();
            foreach (var b in Notes)
            {
                if (b.Name.Length > num)
                {
                    b.Name = b.Name.Substring(0, num) + "...";
                }
            }
            return Notes.ToList();
        }
        public IList<Note> MyGetNoteList(int id)
        {
            int num = 30;
            var Notes = _session.QueryOver<Note>()
                .Where(x => x.Author.Id == id)
                .List();
            foreach (var b in Notes)
            {
                if (b.Name.Length > num)
                {
                    b.Name = b.Name.Substring(0, num) + "...";
                }
            }
            return Notes.ToList();
        }

        public int Notes(string name, int user)
        {
            var entity = _session.QueryOver<Note>()
                .Where(x => x.Name == name && x.Author.Id == user)
                .SingleOrDefault();
            return entity.Id;
        }

        public void Update(int id, string text, bool published)
        {
            var Note = GetNote(id);
            Note.Text = text;
            Note.Published = published;
            using (ITransaction transaction = _session.BeginTransaction())
            {
                _session.Save(Note);
                transaction.Commit();
            }
        }
    }
}
