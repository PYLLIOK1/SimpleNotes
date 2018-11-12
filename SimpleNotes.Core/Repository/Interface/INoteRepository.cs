using SimpleNotes.Core.Object;
using System.Collections.Generic;

namespace SimpleNotes.Core.Repository.Interface
{
    public interface INoteRepository
    {
        IList<Note> GetNoteList();
        IList<Note> MyGetNoteList(int Id);
        void Add(string name, int author, string ico, string path, bool Published, string Text, string[] tag);
        void Update(int id, string text, bool published);
        Note GetNote(int id);
    }
}
