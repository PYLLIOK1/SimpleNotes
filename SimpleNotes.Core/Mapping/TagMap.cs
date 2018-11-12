using FluentNHibernate.Mapping;
using SimpleNotes.Core.Object;


namespace SimpleNotes.Core.Mapping
{
    public class TagMap : ClassMap<Tag>
    {
        public TagMap()
        {
            Table("Tags");
            Id(x => x.Id);
            Map(x => x.Name)
                .Length(50)
                .Not.Nullable();
            HasManyToMany(x => x.Notes)
                .Cascade.All().Inverse()
                .Table("Note_Tag");
        }
    }
}
