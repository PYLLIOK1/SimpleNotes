using FluentNHibernate.Mapping;
using SimpleNotes.Core.Object;


namespace SimpleNotes.Core.Mapping
{
    public class NoteMap : ClassMap<Note>
    {
        public NoteMap()

        {
            Table("Notes");
            Id(x => x.Id);
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Published).Not.Nullable();
            Map(x => x.Text).Not.Nullable();
            Map(x => x.DateTime).Not.Nullable();
            Map(x => x.Path).Not.Nullable();
            Map(x => x.Ico).Not.Nullable();
            References(x => x.Author)
                .Cascade.SaveUpdate()
                .Not.Nullable();
            HasManyToMany(x => x.Tags) 
                .Cascade.SaveUpdate()
                .Table("Note_Tag");
        }
    }
}
