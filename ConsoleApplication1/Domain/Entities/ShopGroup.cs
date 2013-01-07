using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public enum GroupState
    {
        Open,
        Buying,
        Closed

    };
    public class ShopGroup
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int ProductId { get; set; }
        public virtual GroupState Status { get; set; }
        public virtual DateTime CreationTime { get; set; }
        public virtual DateTime StartBuyingTime { get; set; }
        public virtual int BuyingDuration { get; set; }
        public virtual GroupMember Admin { get; set; }
        public virtual IList<GroupMember> Members { get; set; }


        public ShopGroup()
        {
            Members = new List<GroupMember>();
        }

        public virtual void AddMember(GroupMember member)
        {
            if (Members.Contains(member)) return;

            Members.Add(member);
            member.Groups.Add(this);
        }

    }
}
