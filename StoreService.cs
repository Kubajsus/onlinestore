using Microsoft.EntityFrameworkCore;
namespace onlinestore
{
    public class StoreService : IStoreService
    {
        private readonly StoreDbContext db;

        public StoreService(StoreDbContext db)
        {
            this.db = db;
        }
        public Order CreateOrder(OrderRequestModel orderRequestModel)
        {
            var newOrder = new Order()
            {
                Items = GetItemsByIds(orderRequestModel.ItemIds),
                WhenOrdered = DateTime.Now,            };

            float totalPrice = db.Items.Where(d => orderRequestModel.ItemIds.Contains(d.Id)).Sum(d => d.Price);
            newOrder.TotalPrice = totalPrice;

            db.Orders.Add(newOrder);
            db.SaveChanges();

            return newOrder;
        }

        private List<Item> GetItemsByIds(IEnumerable<int> itemIds)
        {
            return db.Items
                .Where(d => itemIds.Contains(d.Id))
                .ToList();
        }

        public Item AddItem(Item item)
        {
            var newItem = new Item()
            {
                Name = item.Name,
                Description = item.Description,
                Price = item.Price
            };
            db.Add(newItem);
            db.SaveChanges();
            return newItem;
        }

    }
}
