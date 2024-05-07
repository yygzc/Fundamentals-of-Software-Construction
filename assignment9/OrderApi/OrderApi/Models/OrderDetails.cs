using System.ComponentModel.DataAnnotations;

namespace OrderApi.Models
{
    public class OrderDetails
    {
        [Key]
        public int DetailId { get; set; }
        public string ItemName { get; set; }
        [Required]
        public int Index { get; set; } //序号
        public double ItemPrice { get; set; }
        public int Quantity { get; set; }

        public int OrderNumber { get; set; } //自动识别为外键
        public Order Order { get; set; } //多对一关联

        public OrderDetails() { }
        public OrderDetails(int index, string itemName, double itemPrice, int quantity)
        {
            Index = index;
            ItemName = itemName;
            ItemPrice = itemPrice;
            Quantity = quantity;
        }
        public double Amount { get => ItemPrice * Quantity; }
        //确保添加的每个订单的订单明细不重复
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            OrderDetails other = (OrderDetails)obj;
            return ItemName.Equals(other.ItemName);
        }
        public override string ToString()
        {
            return $"Commodity Name: {ItemName}" + $"Quantity: {Quantity}" + $"Amount: {Amount}C";
        }
    }
}
