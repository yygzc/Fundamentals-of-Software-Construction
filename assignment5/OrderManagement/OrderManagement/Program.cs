/*
写一个订单管理的控制台程序，
能够实现添加订单、删除订单、修改订单、查询订单（按照订单号、商品名称、客户、订单金额等进行查询）功能，
并对各个Public方法编写测试用例

提示：主要的类有Order（订单）、OrderDetails（订单明细），OrderService（订单服务），
订单数据可以保存在OrderService中一个List中
在Program里面可以调用OrderService的方法完成各种订单操作。

要求：
（1）使用LINQ语言实现各种查询功能，查询结果按照订单总金额排序返回。
（2）在订单删除、修改失败时，能够产生异常并显示给客户错误信息。
（3）作业的订单和订单明细类需要重写Equals方法，确保添加的订单不重复，每个订单的订单明细不重复。
（4）订单、订单明细、客户、货物等类添加ToString方法，用来显示订单信息。
（5） OrderService提供排序方法对保存的订单进行排序。默认按照订单号排序，也可以使用Lambda表达式进行自定义排序。
 */

using System.Text;

namespace OrderManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 订单管理功能
            OrderService orderService = new OrderService();

            // 添加订单
            Order order1 = new Order(1);
            order1.AddOrderDetails(new OrderDetails(new Commodity(1, "Product A", 10), new Client(1, "Client A", "Address A"), 100));
            orderService.AddOrder(order1);

            // 添加重复订单（异常情况）
            try
            {
                orderService.AddOrder(order1);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            
            // 删除订单
            try
            {
                orderService.DeleteOrder(1);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            
            orderService.DisplayOrders();

            // 删除不存在的订单（异常情况）
            try
            {
                orderService.DeleteOrder(2);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            

            // 添加新订单
            Order order2 = new Order(2);
            order2.AddOrderDetails(new OrderDetails(new Commodity(2, "Product B", 20), new Client(2, "Client B", "Address B"), 200));
            orderService.AddOrder(order2);
            
            Order order3 = new Order(3);
            order3.AddOrderDetails(new OrderDetails(new Commodity(3, "Product X", 50), new Client(3, "Client X", "Address X"), 100));
            orderService.AddOrder(order3);

            // 修改订单
            Order modifiedOrder = new Order(2);
            modifiedOrder.AddOrderDetails(new OrderDetails(new Commodity(2, "Product C", 30), new Client(2, "Client C", "Address C"), 300));
            try
            {
                orderService.ModifyOrder(modifiedOrder);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            // 查询订单
            List<Order> queriedOrders = orderService.QueryOrders(order => order.TotalAmount > 50);
            Console.WriteLine("Queried Orders:");
            foreach (var order in queriedOrders)
            {
                Console.WriteLine(order);
            }

            orderService.DisplayOrders();
        }
    }
    //订单类：订单号、订单细节、总金额
    public class Order
    {
        public int OrderNumber { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }

        public double TotalAmount => OrderDetails.Sum(detail => detail.Amount);

        public Order(int orderNumber)
        {
            OrderNumber = orderNumber;
            OrderDetails = new List<OrderDetails>();
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

        public override int GetHashCode()
        {
            return HashCode.Combine(OrderNumber);
        }
    }
    //订单细节类：客户、商品
    public class OrderDetails
    {
        public Commodity Commodity { get; set; }
        public Client Client { get; set; }
        public double Amount { get; set; }

        public OrderDetails(Commodity commodity, Client client, double amount)
        {
            Commodity = commodity;
            Client = client;
            Amount = amount;
        }
        //确保添加的每个订单的订单明细不重复
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            OrderDetails other = (OrderDetails)obj;
            return Commodity.Equals(other.Commodity) && Client.Equals(other.Client);
        }
        public override string ToString()
        {
            return $"Commodity: {Commodity}" + $"Client: {Client}" + $"Amount: {Amount:C}";
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Commodity, Client);
        }
    }
    public class Client
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string Address { get; set; }

        public Client(int clientId, string name, string address)
        {
            ClientId = clientId;
            ClientName = name;
            Address = address;
        }

        public override string ToString()
        {
            return $"Client ID: {ClientId}, Name: {ClientName}, Address: {Address}\n";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Client other = (Client)obj;
            return ClientId == other.ClientId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ClientId);
        }
    }

    public class Commodity
    {
        public int CommodityId { get; set; }
        public string CommodityName { get; set; }
        public double Price { get; set; }
        // 可以添加其他商品相关信息

        public Commodity(int commodityId, string name, double price)
        {
            CommodityId = commodityId;
            CommodityName = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"Commodity ID: {CommodityId}, Name: {CommodityName}, Price: {Price:C}\n";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Commodity other = (Commodity)obj;
            return CommodityId == other.CommodityId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CommodityId);
        }
    }

    public class OrderService
    {
        private List<Order> orders;

        public OrderService()
        {
            orders = new List<Order>();
        }
        //添加订单
        public void AddOrder(Order newOrder)
        {
            if (!orders.Contains(newOrder))
            {
                orders.Add(newOrder);
                Console.WriteLine($"Order {newOrder.OrderNumber} has been added.\n");
            }
            else
            {
                throw new ArgumentException($"Order {newOrder.OrderNumber} already exists.\n");
            }
        }
        //删除订单
        public void DeleteOrder(int orderNumber)
        {
            Order order = orders.FirstOrDefault(o => o.OrderNumber == orderNumber);
            if (order != null)
            {
                orders.Remove(order);
                Console.WriteLine($"Order {orderNumber} has been deleted.\n");
            }
            else
            {
                throw new ArgumentException($"Order {orderNumber} not found.\n");
            }
        }
        //修改订单
        public void ModifyOrder(Order modifiedOrder)
        {
            var index = orders.FindIndex(order => order.OrderNumber == modifiedOrder.OrderNumber);
            if (index == -1)
            {
                throw new ArgumentException($"Order {modifiedOrder.OrderNumber} does not exist.\n");
            }
            else
            {
                orders[index] = modifiedOrder;
                Console.WriteLine($"Order {modifiedOrder.OrderNumber} has been modified.\n");
            }
        }
        //按照订单号、商品名称、客户、订单金额等进行查询
        public List<Order> QueryOrders(Func<Order, bool> condition)
        {
            return orders.Where(condition).OrderBy(o => o.TotalAmount).ToList();
        }

        public void DisplayOrders()
        {
            Console.WriteLine("Order list:");
            if (orders.Count != 0)
            {
                foreach (var order in orders)
                {
                    Console.WriteLine(order);
                }
            }
            else
            {
                Console.WriteLine("There is no order in the list!\n");
            }
        }
    }
}
