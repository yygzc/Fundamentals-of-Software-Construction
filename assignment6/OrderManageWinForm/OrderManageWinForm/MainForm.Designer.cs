namespace OrderManageWinForm
{
    partial class OrderManagement
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入订单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出订单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonDisplayOrder = new System.Windows.Forms.Button();
            this.buttonAddOrder = new System.Windows.Forms.Button();
            this.buttonDeleteOrder = new System.Windows.Forms.Button();
            this.buttonModifyOrder = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.comboBoxQueryOrder = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.queryText = new System.Windows.Forms.TextBox();
            this.buttonQueryOrder = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.orderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.detailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.orderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1347, 32);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gToolStripMenuItem
            // 
            this.gToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导入订单ToolStripMenuItem,
            this.导出订单ToolStripMenuItem});
            this.gToolStripMenuItem.Name = "gToolStripMenuItem";
            this.gToolStripMenuItem.Size = new System.Drawing.Size(62, 32);
            this.gToolStripMenuItem.Text = "工具";
            // 
            // 导入订单ToolStripMenuItem
            // 
            this.导入订单ToolStripMenuItem.Name = "导入订单ToolStripMenuItem";
            this.导入订单ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.导入订单ToolStripMenuItem.Text = "导入订单";
            // 
            // 导出订单ToolStripMenuItem
            // 
            this.导出订单ToolStripMenuItem.Name = "导出订单ToolStripMenuItem";
            this.导出订单ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.导出订单ToolStripMenuItem.Text = "导出订单";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(62, 32);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.flowLayoutPanel1.Controls.Add(this.buttonDisplayOrder);
            this.flowLayoutPanel1.Controls.Add(this.buttonAddOrder);
            this.flowLayoutPanel1.Controls.Add(this.buttonDeleteOrder);
            this.flowLayoutPanel1.Controls.Add(this.buttonModifyOrder);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 35);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(12, 12, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1347, 66);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // buttonDisplayOrder
            // 
            this.buttonDisplayOrder.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonDisplayOrder.Location = new System.Drawing.Point(15, 15);
            this.buttonDisplayOrder.Margin = new System.Windows.Forms.Padding(3, 3, 12, 3);
            this.buttonDisplayOrder.Name = "buttonDisplayOrder";
            this.buttonDisplayOrder.Size = new System.Drawing.Size(107, 35);
            this.buttonDisplayOrder.TabIndex = 2;
            this.buttonDisplayOrder.Text = "展示订单";
            this.buttonDisplayOrder.UseVisualStyleBackColor = true;
            this.buttonDisplayOrder.Click += new System.EventHandler(this.buttonDisplayOrder_Click);
            // 
            // buttonAddOrder
            // 
            this.buttonAddOrder.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonAddOrder.Location = new System.Drawing.Point(137, 15);
            this.buttonAddOrder.Margin = new System.Windows.Forms.Padding(3, 3, 12, 3);
            this.buttonAddOrder.Name = "buttonAddOrder";
            this.buttonAddOrder.Size = new System.Drawing.Size(107, 35);
            this.buttonAddOrder.TabIndex = 3;
            this.buttonAddOrder.Text = "添加订单";
            this.buttonAddOrder.UseVisualStyleBackColor = true;
            this.buttonAddOrder.Click += new System.EventHandler(this.buttonAddOrder_Click);
            // 
            // buttonDeleteOrder
            // 
            this.buttonDeleteOrder.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonDeleteOrder.Location = new System.Drawing.Point(259, 15);
            this.buttonDeleteOrder.Margin = new System.Windows.Forms.Padding(3, 3, 12, 3);
            this.buttonDeleteOrder.Name = "buttonDeleteOrder";
            this.buttonDeleteOrder.Size = new System.Drawing.Size(107, 35);
            this.buttonDeleteOrder.TabIndex = 4;
            this.buttonDeleteOrder.Text = "删除订单";
            this.buttonDeleteOrder.UseVisualStyleBackColor = true;
            this.buttonDeleteOrder.Click += new System.EventHandler(this.buttonDeleteOrder_Click);
            // 
            // buttonModifyOrder
            // 
            this.buttonModifyOrder.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonModifyOrder.Location = new System.Drawing.Point(381, 15);
            this.buttonModifyOrder.Name = "buttonModifyOrder";
            this.buttonModifyOrder.Size = new System.Drawing.Size(107, 35);
            this.buttonModifyOrder.TabIndex = 5;
            this.buttonModifyOrder.Text = "修改订单";
            this.buttonModifyOrder.UseVisualStyleBackColor = true;
            this.buttonModifyOrder.Click += new System.EventHandler(this.buttonModifyOrder_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.flowLayoutPanel2.Controls.Add(this.comboBoxQueryOrder);
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Controls.Add(this.queryText);
            this.flowLayoutPanel2.Controls.Add(this.buttonQueryOrder);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 101);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(12, 14, 0, 0);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1347, 61);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // comboBoxQueryOrder
            // 
            this.comboBoxQueryOrder.FormattingEnabled = true;
            this.comboBoxQueryOrder.Items.AddRange(new object[] {
            "根据订单号查询",
            "根据客户名查询",
            "根据商品名查询",
            "根据订单金额查询"});
            this.comboBoxQueryOrder.Location = new System.Drawing.Point(15, 17);
            this.comboBoxQueryOrder.Name = "comboBoxQueryOrder";
            this.comboBoxQueryOrder.Size = new System.Drawing.Size(188, 26);
            this.comboBoxQueryOrder.TabIndex = 0;
            this.comboBoxQueryOrder.Text = "订单查询依据";
            this.comboBoxQueryOrder.SelectedIndexChanged += new System.EventHandler(this.comboBoxQueryOrder_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(214, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "查询关键字:";
            // 
            // queryText
            // 
            this.queryText.Location = new System.Drawing.Point(332, 17);
            this.queryText.Margin = new System.Windows.Forms.Padding(3, 3, 12, 3);
            this.queryText.Name = "queryText";
            this.queryText.Size = new System.Drawing.Size(175, 28);
            this.queryText.TabIndex = 2;
            // 
            // buttonQueryOrder
            // 
            this.buttonQueryOrder.Location = new System.Drawing.Point(522, 14);
            this.buttonQueryOrder.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.buttonQueryOrder.Name = "buttonQueryOrder";
            this.buttonQueryOrder.Size = new System.Drawing.Size(111, 37);
            this.buttonQueryOrder.TabIndex = 3;
            this.buttonQueryOrder.Text = "确认查询";
            this.buttonQueryOrder.UseVisualStyleBackColor = true;
            this.buttonQueryOrder.Click += new System.EventHandler(this.buttonQueryOrder_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(0, 169);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(682, 650);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "订单";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderID,
            this.clientName,
            this.createTime});
            this.dataGridView1.DataSource = this.orderBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(3, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(673, 620);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView2);
            this.groupBox2.Location = new System.Drawing.Point(688, 169);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(659, 650);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "订单明细";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.DataSource = this.detailBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(6, 24);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 62;
            this.dataGridView2.RowTemplate.Height = 30;
            this.dataGridView2.Size = new System.Drawing.Size(647, 620);
            this.dataGridView2.TabIndex = 0;
            // 
            // orderID
            // 
            this.orderID.HeaderText = "订单号";
            this.orderID.MinimumWidth = 8;
            this.orderID.Name = "orderID";
            this.orderID.Width = 150;
            // 
            // clientName
            // 
            this.clientName.HeaderText = "客户名";
            this.clientName.MinimumWidth = 8;
            this.clientName.Name = "clientName";
            this.clientName.Width = 150;
            // 
            // createTime
            // 
            this.createTime.HeaderText = "下单时间";
            this.createTime.MinimumWidth = 8;
            this.createTime.Name = "createTime";
            this.createTime.Width = 150;
            // 
            // OrderManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1347, 818);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "OrderManagement";
            this.Text = "订单管理系统";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonDisplayOrder;
        private System.Windows.Forms.Button buttonAddOrder;
        private System.Windows.Forms.Button buttonDeleteOrder;
        private System.Windows.Forms.Button buttonModifyOrder;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.ComboBox comboBoxQueryOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox queryText;
        private System.Windows.Forms.Button buttonQueryOrder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ToolStripMenuItem 导入订单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出订单ToolStripMenuItem;
        private System.Windows.Forms.BindingSource orderBindingSource;
        private System.Windows.Forms.BindingSource detailBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn createTime;
    }
}

