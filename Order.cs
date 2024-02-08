namespace onlinestore
{
    public class Order
    {
        public int Id { get; set; }
        public IEnumerable<Item> Items { get; set; }   
        public DateTime WhenOrdered { get; set; }
        public float TotalPrice { get; set; }
    }
}
