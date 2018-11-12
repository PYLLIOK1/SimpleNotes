using SimpleNotes.Core.Object;
using SimpleNotes.Core.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace SimpleNotes.Models
{
    public class ListViewSearchModel
    {
        public ListViewSearchModel(INoteRepository _noteRepository, string search)
        {
            Notes = _noteRepository.GetNoteList().Where(x => x.Name.Contains(search) || x.Author.Name.Contains(search) || x.DateTime.ToString().Contains(search)).ToList();
        }
        public IList<Note> Notes { get; set; }
    }
}