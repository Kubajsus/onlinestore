namespace onlinestore;


    public interface IStoreService
    {
        Order CreateOrder(OrderRequestModel orderRequestModel);
        Item AddItem(Item item);
    }
