/*
 * 为订单管理的程序添加一个WinForm的界面。通过这个界面，调用OrderService的各个方法
 * 实现创建订单、删除订单、修改订单、查询订单等功能
要求：
（1）WinForm的界面部分单独写一个项目，依赖于原来的项目。
（2）可以使用两个窗口。主窗口实现查询展示功能，以及放置各种功能按钮。新建/修改订单功能使用弹出窗口。
（3）注意窗口的布局，在窗口尺寸变化时，不出现错位挤压等情况。
（4）尽量通过数据绑定来实现功能。订单和订单明细各使用一个bindingsource，通过DataMember来实现主从对象绑定。
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderManageWinForm
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new OrderManagement());
        }
    }
    //订单类：订单号、订单细节、总金额
    public class Order
    {
        public int OrderNumber { get; set; }
        public string ClientName { get => (Client != null) ? Client.ClientName : ""; }
        public Client Client { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
        public DateTime CreateTime { get; set; }

        public double TotalAmount => OrderDetails.Sum(detail => detail.Amount);

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
    //订单细节类：客户、商品
    public class OrderDetails
    {
        public int Index { get; set; } //序号
        public Commodity Commodity { get; set; }
        public Client Client { get; set; }
        public int Quantity { get; set; }
        public OrderDetails(int index, Commodity commodity, Client client, int quantity)
        {
            Index = index;
            Commodity = commodity;
            Client = client;
            Quantity = quantity;
        }
        public double Amount
        {
            get => Commodity == null ? 0.0 : Commodity.Price * Quantity;
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
            return $"Commodity: {Commodity}" + $"Client: {Client}" + $"Quantity: {Quantity}" + $"Amount: {Amount}C";
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
    }

    public class OrderService
    {
        public List<Order> orders { get; set; }

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
        public void DeleteOrder(Order order)
        {
            if (order != null)
            {
                orders.Remove(order);
                Console.WriteLine($"Order {order.OrderNumber} has been deleted.\n");
            }
            else
            {
                throw new ArgumentException($"Order {order.OrderNumber} not found.\n");
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
