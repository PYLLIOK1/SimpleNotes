using FluentNHibernate.Mapping;
using SimpleNotes.Core.Object;

namespace SimpleNotes.Core.Mapping
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("Users");
            Id(x => x.Id);
            Map(x => x.Name)
                .Length(50)
                .Not.Nullable();
            Map(x => x.Password)
                .Length(50)
                .Not.Nullable();
            HasMany(x => x.Notes).Inverse();
        }
    }
}
