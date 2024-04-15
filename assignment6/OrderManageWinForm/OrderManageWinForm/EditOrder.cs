using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace OrderManageWinForm
{
    public partial class EditOrder : Form
    {
        private OrderService orderService;
        public Order CurrentOrder { get; set; }
        public bool Variable { get; set; }
        public EditOrder(Order order, bool variable, OrderService orderService)
        {
            InitializeComponent();
            CurrentOrder = order;
            Variable = variable;
            this.orderService = orderService;
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (textOrderNumber.Text == "")
            {
                MessageBox.Show("订单号不能为空！");
                return;
            }
            CurrentOrder.Client = clientBindingSource.Current as Client;
            CurrentOrder.OrderNumber = int.Parse(textOrderNumber.Text);
            OrderDetails detail = detailBindingSource.Current as OrderDetails;
            CurrentOrder.AddOrderDetails(detail);
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void EditOrder_Load(object sender, EventArgs e)
        {
            textOrderNumber.Text = CurrentOrder.OrderNumber.ToString();
            textOrderNumber.Enabled = Variable;
            createTime.Text = DateTime.Now.ToString("G");
            Client client1 = new Client(1, "zyy", "WHU");
            Client client2 = new Client(2, "lsy", "WHU");
            clientBindingSource.Add(client1);
            clientBindingSource.Add(client2);
            detailBindingSource.DataSource = CurrentOrder.OrderDetails;
        }
    }
}
