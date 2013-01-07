using System.Collections.Generic;

namespace Domain.Entities
{
    public class GroupMember
    {
        public virtual int SywId { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<ShopGroup> Groups { get; set; }

        public GroupMember()
        {
           Groups = new List<ShopGroup>();
        }


    }
}
