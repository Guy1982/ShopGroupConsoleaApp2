using System;
using Domain;
using Domain.Entities;
using Domain.Repository;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            // create our NHibernate session factory
           var groupMemberRepository = new GroupMemberRepository();
           var shopGroupRepository = new ShopGroupRepository();
           var timeFactory = new TimeFactory();

            // create our NHibernate session factory
           

            // create a couple of Stores each with some Products and Employees
            var groupMember1 = new GroupMember { Name = "Moshe", SywId = 2345 };
            var groupMember2 = new GroupMember { Name = "Mo", SywId = 2344 };
            var groupMember3 = new GroupMember { Name = "Bla", SywId = 2335 };
            var groupMember4 = new GroupMember { Name = "Miki", SywId = 2245 };
            var groupMember5 = new GroupMember { Name = "Moti", SywId = 1145 };

            var group1 = new ShopGroup
            {
                Name = "TheWinners",
                ProductId = 8484,
                Status = GroupState.Open,
                CreationTime = timeFactory.GetUtcTime(),
                Admin = groupMember1
            };

            var group2 = new ShopGroup
            {
                Name = "TheBest",
                ProductId = 9999,
                Status = GroupState.Open,
                CreationTime = timeFactory.GetUtcTime(),
                Admin = groupMember2
            };



            AddMembersToGroup(group1, groupMember1, groupMember2, groupMember3, groupMember4);
            AddMembersToGroup(group2, groupMember5, groupMember2, groupMember3, groupMember4);


            shopGroupRepository.AddNewShopGroup(group1);
            shopGroupRepository.AddNewShopGroup(group2);

            var groups = shopGroupRepository.GetAllShopGroups();                  
           
            foreach (var group in groups)
            {
                WriteGroupToConsole(group);
            }

            var groupAdmins = groupMemberRepository.GetAllGroupsAdminMembers();

            foreach (var groupAdmin in groupAdmins)
            {
                Console.WriteLine("  AdminUser list id:" + groupAdmin.SywId);
            }

            Console.ReadKey();
        }




        private static void WriteGroupToConsole(ShopGroup shopGroup)
        {
            Console.WriteLine(shopGroup.Name);
            Console.WriteLine("  Members IDs:");

            foreach (var member in shopGroup.Members)
            {
                Console.WriteLine("    " + member.SywId);
            }

            Console.WriteLine("  AdminUser id:" + shopGroup.Admin.SywId);
            Console.WriteLine("  Group State id:" + shopGroup.Status);
            Console.WriteLine("  Group StartBuyingTime:" + shopGroup.StartBuyingTime);
            Console.WriteLine("  Group CreationTime:" + shopGroup.CreationTime);



            Console.WriteLine();
        }

        public static void AddMembersToGroup(ShopGroup shopGroup, params GroupMember[] groupMembers)
        {
            foreach (var groupMember in groupMembers)

                shopGroup.AddMember(groupMember);
        }
    }

}
