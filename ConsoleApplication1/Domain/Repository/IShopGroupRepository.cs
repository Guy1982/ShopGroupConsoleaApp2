using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

namespace Domain.Repository
{
    public interface IShopGroupRepository
    {
        void AddNewShopGroup(ShopGroup group);
        ShopGroup GetShoupGroup(int groupId);
        IList<ShopGroup> GetAllShopGroups();

    }

    public class ShopGroupRepository : IShopGroupRepository
    {
        private readonly SessionProvider _sessionProvider;

        public ShopGroupRepository()
        {
            _sessionProvider = new SessionProvider();
        }
       
        public void AddNewShopGroup(ShopGroup group)
        {
            _sessionProvider.WithSession(session => session.Save(group));
        }

        public ShopGroup GetShoupGroup(int groupId)
        {
            var shopGroup = _sessionProvider.Query<ShopGroup>(q => q.Where(x => x.Id == groupId)).FirstOrDefault();
            return shopGroup;
        }

        public IList<ShopGroup> GetAllShopGroups()
        {
            return _sessionProvider.Query<ShopGroup>(q => q);
        } 
    }
  
}
