using System.Collections.Generic;


namespace SimpleNotes.Core.Object
{
    public class User
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Password { get; set; }
        private IList<Note> _notes;
        public virtual IList<Note> Notes
        {
            get
            {
                return _notes ?? (_notes = new List<Note>());
            }
            set { _notes = value; }
        }
    }
}
