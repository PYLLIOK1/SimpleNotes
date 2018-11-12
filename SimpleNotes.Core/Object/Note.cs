using System;
using System.Collections.Generic;

namespace SimpleNotes.Core.Object
{
    public class Note
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Text { get; set; }
        public virtual bool Published { get; set; }
        public virtual DateTime DateTime { get; set; }
        public virtual User Author { get; set; }
        private IList<Tag> _tag;
        public virtual IList<Tag> Tags
        {
            get
            {
                return _tag ?? (_tag = new List<Tag>());
            }
            set { _tag = value; }
        }
        public virtual string Path { get; set; }
        public virtual string Ico { get; set; }

    }
}
