namespace TOOL_BINH_TRAN
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            panel3 = new Panel();
            dataGridView1 = new DataGridView();
            cbxAccount = new DataGridViewCheckBoxColumn();
            stt = new DataGridViewTextBoxColumn();
            uid = new DataGridViewTextBoxColumn();
            cookie = new DataGridViewTextBoxColumn();
            token = new DataGridViewTextBoxColumn();
            proxy = new DataGridViewTextBoxColumn();
            process = new DataGridViewTextBoxColumn();
            contextMenuStrip1 = new ContextMenuStrip(components);
            btnPasteData = new ToolStripMenuItem();
            btnSelectAll = new ToolStripMenuItem();
            btnClearAll = new ToolStripMenuItem();
            btnSelectBlack = new ToolStripMenuItem();
            btnUnselectAll = new ToolStripMenuItem();
            btnUnselectedBlack = new ToolStripMenuItem();
            btnDeleteDataBlack = new ToolStripMenuItem();
            panel2 = new Panel();
            numericUpDown2 = new NumericUpDown();
            label2 = new Label();
            numericUpDown1 = new NumericUpDown();
            label1 = new Label();
            button2 = new Button();
            button1 = new Button();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            contextMenuStrip1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1264, 613);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(dataGridView1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 112);
            panel3.Name = "panel3";
            panel3.Size = new Size(1264, 501);
            panel3.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { cbxAccount, stt, uid, cookie, token, proxy, process });
            dataGridView1.ContextMenuStrip = contextMenuStrip1;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Size = new Size(1264, 501);
            dataGridView1.TabIndex = 0;
            // 
            // cbxAccount
            // 
            cbxAccount.FillWeight = 20.0969639F;
            cbxAccount.HeaderText = "";
            cbxAccount.Name = "cbxAccount";
            // 
            // stt
            // 
            stt.FillWeight = 16.2436523F;
            stt.HeaderText = "STT";
            stt.Name = "stt";
            // 
            // uid
            // 
            uid.HeaderText = "UID";
            uid.Name = "uid";
            // 
            // cookie
            // 
            cookie.FillWeight = 181.829666F;
            cookie.HeaderText = "Cookie";
            cookie.Name = "cookie";
            // 
            // token
            // 
            token.HeaderText = "Token";
            token.Name = "token";
            // 
            // proxy
            // 
            proxy.HeaderText = "Proxy";
            proxy.Name = "proxy";
            // 
            // process
            // 
            process.FillWeight = 181.829666F;
            process.HeaderText = "Trạng Thái";
            process.Name = "process";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { btnPasteData, btnSelectAll, btnClearAll, btnSelectBlack, btnUnselectAll, btnUnselectedBlack, btnDeleteDataBlack });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(231, 158);
            // 
            // btnPasteData
            // 
            btnPasteData.Name = "btnPasteData";
            btnPasteData.Size = new Size(230, 22);
            btnPasteData.Text = "Dán data (coppy)";
            btnPasteData.Click += btnPasteData_Click;
            // 
            // btnSelectAll
            // 
            btnSelectAll.Name = "btnSelectAll";
            btnSelectAll.Size = new Size(230, 22);
            btnSelectAll.Text = "Chọn tất cả";
            btnSelectAll.Click += btnSelectAll_Click;
            // 
            // btnClearAll
            // 
            btnClearAll.Name = "btnClearAll";
            btnClearAll.Size = new Size(230, 22);
            btnClearAll.Text = "Xoá tất cả";
            btnClearAll.Click += btnClearAll_Click;
            // 
            // btnSelectBlack
            // 
            btnSelectBlack.Name = "btnSelectBlack";
            btnSelectBlack.Size = new Size(230, 22);
            btnSelectBlack.Text = "Chọn dữ liệu được bôi đen";
            btnSelectBlack.Click += btnSelectBlack_Click;
            // 
            // btnUnselectAll
            // 
            btnUnselectAll.Name = "btnUnselectAll";
            btnUnselectAll.Size = new Size(230, 22);
            btnUnselectAll.Text = "Bỏ chọn tất cả";
            btnUnselectAll.Click += btnUnselectAll_Click;
            // 
            // btnUnselectedBlack
            // 
            btnUnselectedBlack.Name = "btnUnselectedBlack";
            btnUnselectedBlack.Size = new Size(230, 22);
            btnUnselectedBlack.Text = "Bỏ chọn dữ liệu được bôi đen";
            btnUnselectedBlack.Click += btnUnselectedBlack_Click;
            // 
            // btnDeleteDataBlack
            // 
            btnDeleteDataBlack.Name = "btnDeleteDataBlack";
            btnDeleteDataBlack.Size = new Size(230, 22);
            btnDeleteDataBlack.Text = "Xoá dữ liệu được bôi đen";
            btnDeleteDataBlack.Click += btnDeleteDataBlack_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(numericUpDown2);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(numericUpDown1);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1264, 112);
            panel2.TabIndex = 0;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(195, 12);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(57, 23);
            numericUpDown2.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(153, 14);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 4;
            label2.Text = "Delay";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(72, 12);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(57, 23);
            numericUpDown1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 14);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 2;
            label1.Text = "Số luồng";
            // 
            // button2
            // 
            button2.ForeColor = Color.Red;
            button2.Location = new Point(105, 56);
            button2.Name = "button2";
            button2.Size = new Size(87, 43);
            button2.TabIndex = 1;
            button2.Text = "Dừng lại";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(12, 56);
            button1.Name = "button1";
            button1.Size = new Size(87, 43);
            button1.TabIndex = 0;
            button1.Text = "Bắt đầu";
            button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 613);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "TOOL BÌNH TRẦN";
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private DataGridView dataGridView1;
        private Button button2;
        private Button button1;
        private NumericUpDown numericUpDown2;
        private Label label2;
        private NumericUpDown numericUpDown1;
        private Label label1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem btnPasteData;
        private ToolStripMenuItem btnSelectAll;
        private ToolStripMenuItem btnClearAll;
        private ToolStripMenuItem btnSelectBlack;
        private ToolStripMenuItem btnUnselectAll;
        private ToolStripMenuItem btnUnselectedBlack;
        private ToolStripMenuItem btnDeleteDataBlack;
        private DataGridViewCheckBoxColumn cbxAccount;
        private DataGridViewTextBoxColumn stt;
        private DataGridViewTextBoxColumn uid;
        private DataGridViewTextBoxColumn cookie;
        private DataGridViewTextBoxColumn token;
        private DataGridViewTextBoxColumn proxy;
        private DataGridViewTextBoxColumn process;
    }
}
