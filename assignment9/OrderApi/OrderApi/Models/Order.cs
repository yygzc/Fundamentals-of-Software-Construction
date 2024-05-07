using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrderApi.Models
{
    public class Order
    {
        [Key]
        public int OrderNumber { get; set; }
        public Client Client { get; set; }
        [Required]
        public string ClientName { get => (Client != null) ? Client.ClientName : ""; }
        public DateTime CreateTime { get; set; }
        public double TotalAmount => OrderDetails.Sum(detail => detail.Amount);

        public List<OrderDetails> OrderDetails { get; set; } //一对多导航
        public Order()
        {
            OrderDetails = new List<OrderDetails>(); CreateTime = DateTime.Now;
        }
        public Order(int orderNumber, Client client)
        {
            OrderNumber = orderNumber;
            OrderDetails = new List<OrderDetails>();
            Client = client;
            CreateTime = DateTime.Now;
        }
        //添加订单细节
        public void AddOrderDetails(OrderDetails detail)
        {
            if (!OrderDetails.Contains(detail))
            {
                OrderDetails.Add(detail);
            }
        }
        //显示订单信息
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Order Number: {OrderNumber}");
            sb.AppendLine("Order Details:");
            foreach (var detail in OrderDetails)
            {
                sb.AppendLine(detail.ToString());
            }
            sb.AppendLine($"Total Amount: {TotalAmount:C}");
            return sb.ToString();
        }
        //重写Equals方法，确保添加的订单不重复
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Order other = (Order)obj;
            return OrderNumber == other.OrderNumber;
        }
    }
}
