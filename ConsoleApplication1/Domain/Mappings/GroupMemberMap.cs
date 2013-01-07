using Domain.Entities;
using FluentNHibernate.Mapping;

namespace Domain.Mappings
{
    public class GroupMemberMap : ClassMap<GroupMember>
    {
        public GroupMemberMap()
        {
            Id(x => x.SywId).GeneratedBy.Assigned();
            Map(x => x.Name);
            HasManyToMany(x => x.Groups)
              .Cascade.All()
              .Inverse()
              .Table("shopgroup_groupmember");         
        }
    }
}
