using SimpleNotes.Core.Object;
using SimpleNotes.Core.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleNotes.Models
{
    public class MyListViewSearchModel
    {
        public MyListViewSearchModel(INoteRepository _noteRepository, int Id)
        {
            Notes = _noteRepository.MyGetNoteList(Id).ToList();
        }
        public IList<Note> Notes { get; set; }
    }
}