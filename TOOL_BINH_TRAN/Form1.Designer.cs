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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            panel3 = new Panel();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewCheckBoxColumn();
            stt = new DataGridViewTextBoxColumn();
            cookie = new DataGridViewTextBoxColumn();
            proxy = new DataGridViewTextBoxColumn();
            process = new DataGridViewTextBoxColumn();
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
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, stt, cookie, proxy, process });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Size = new Size(1264, 501);
            dataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            Column1.FillWeight = 20.0969639F;
            Column1.HeaderText = "";
            Column1.Name = "Column1";
            // 
            // stt
            // 
            stt.FillWeight = 16.2436523F;
            stt.HeaderText = "STT";
            stt.Name = "stt";
            // 
            // cookie
            // 
            cookie.FillWeight = 181.829666F;
            cookie.HeaderText = "Cookie";
            cookie.Name = "cookie";
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
        private DataGridViewCheckBoxColumn Column1;
        private DataGridViewTextBoxColumn stt;
        private DataGridViewTextBoxColumn cookie;
        private DataGridViewTextBoxColumn proxy;
        private DataGridViewTextBoxColumn process;
    }
}
