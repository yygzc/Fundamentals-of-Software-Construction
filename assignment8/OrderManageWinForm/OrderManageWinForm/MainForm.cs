using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderManageWinForm
{
    public partial class OrderManagement : Form
    {
        OrderService orderService = new OrderService();
        public OrderManagement()
        {
            InitializeComponent();
            InitOrder();
        }
        private void InitOrder()
        {
            orderBindingSource.DataSource = orderService.orders;
            Client client1 = new Client(1, "zyy", "WHU");
            Client client2 = new Client(2, "lsy", "WHU");
        }
        private void buttonAddOrder_Click(object sender, EventArgs e)
        {
            EditOrder edit = new EditOrder(new Order(), true, orderService);
            if (edit.ShowDialog() == DialogResult.OK)
            {
                orderService.AddOrder(edit.CurrentOrder);
                orderBindingSource.DataSource = orderService.orders;
                orderBindingSource.ResetBindings(false);
            }
        }


        private void buttonModifyOrder_Click(object sender, EventArgs e)
        {
            Order order = orderBindingSource.Current as Order;
            EditOrder edit = new EditOrder(order, false, orderService);
            if (edit.ShowDialog() == DialogResult.OK)
            {
                orderService.ModifyOrder(edit.CurrentOrder);
                orderBindingSource.DataSource = orderService.orders;
                orderBindingSource.ResetBindings(false);
            }
        }

        private void buttonDisplayOrder_Click(object sender, EventArgs e)
        {
            orderBindingSource.DataSource = orderService.orders;
            orderBindingSource.ResetBindings(false);
        }

        private void buttonDeleteOrder_Click(object sender, EventArgs e)
        {
            orderService.DeleteOrder(orderBindingSource.Current as Order);
            orderBindingSource.ResetBindings(false);
        }

        private void buttonQueryOrder_Click(object sender, EventArgs e)
        {
            List<Order> newList;
            switch (comboBoxQueryOrder.SelectedIndex)
            {
                case 0:
                    newList = orderService.QueryOrders(o => o.OrderNumber==int.Parse(queryKey.Text));
                    orderBindingSource.DataSource = newList;
                    orderBindingSource.ResetBindings(false);
                    break;
                case 1:
                    newList = orderService.QueryOrders(o => o.ClientName == queryKey.Text);
                    orderBindingSource.DataSource = newList;
                    orderBindingSource.ResetBindings(false);
                    break;
                case 2:
                    newList = orderService.QueryOrders(o => o.OrderDetails.Any(
                        detail => detail.ItemName == queryKey.Text));
                    orderBindingSource.DataSource = newList;
                    orderBindingSource.ResetBindings(false);
                    break;
                case 3:
                    newList = orderService.QueryOrders(o => o.TotalAmount>=double.Parse(queryKey.Text));
                    orderBindingSource.DataSource = newList;
                    orderBindingSource.ResetBindings(false);
                    break;
                default:
                    break;
            }
        }
    }
}
