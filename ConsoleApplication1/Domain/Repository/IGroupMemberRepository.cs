using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

namespace Domain.Repository
{
    public interface IGroupMemberRepository
    {
        void AddNewGroupMember(GroupMember member);
        IList<GroupMember> GetShoupGroupMembers(int groupId);
        GroupMember GetShoupGroupAdminMember(int groupId);
        IList<GroupMember> GetAllGroupsMembers();
        IList<GroupMember> GetAllGroupsAdminMembers();

    }

    public class GroupMemberRepository : IGroupMemberRepository
    {
        private readonly SessionProvider _sessionProvider;

        public GroupMemberRepository()
        {
            _sessionProvider = new SessionProvider();
        }
       
        public void AddNewGroupMember(GroupMember member)
        {
            _sessionProvider.WithSession(session => session.Save(member));
        }

        public IList<GroupMember> GetShoupGroupMembers(int groupId)
        {
            var group = _sessionProvider.Query<ShopGroup>(q => q.Where(x => x.Id == groupId)).FirstOrDefault();
            return group == null ? null : group.Members;
        }

        public GroupMember GetShoupGroupAdminMember(int groupId)
        {
            var group = _sessionProvider.Query<ShopGroup>(q => q.Where(x => x.Id == groupId)).FirstOrDefault();
            return group == null ? null : group.Admin;
        }

        public IList<GroupMember> GetAllGroupsMembers()
        {
            return _sessionProvider.Query<GroupMember>(q => q);
        }

        public IList<GroupMember> GetAllGroupsAdminMembers()
        {
            return _sessionProvider.QueryOver<ShopGroup, GroupMember>(q => q.Select(x => x.Admin));
        }
    }
  
}
