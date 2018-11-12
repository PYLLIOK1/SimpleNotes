using System.Collections.Generic;

namespace SimpleNotes.Core.Object
{
    public class Tag
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        private IList<Note> _note;
        public virtual IList<Note> Notes
        {
            get
            {
                return _note ?? (_note = new List<Note>());
            }
            set { _note = value; }
        }
    }
}
