namespace L.WebFormsUI
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            menuStrip1 = new MenuStrip();
            addToolStripMenuItem = new ToolStripMenuItem();
            addToolStripMenuItem1 = new ToolStripMenuItem();
            updateToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            label2 = new Label();
            label1 = new Label();
            btnAdd = new Button();
            tbPrice = new TextBox();
            tbName = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 63);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1202, 300);
            dataGridView1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { addToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1269, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // addToolStripMenuItem
            // 
            addToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addToolStripMenuItem1, updateToolStripMenuItem, deleteToolStripMenuItem });
            addToolStripMenuItem.Name = "addToolStripMenuItem";
            addToolStripMenuItem.Size = new Size(61, 20);
            addToolStripMenuItem.Text = "Product";
            // 
            // addToolStripMenuItem1
            // 
            addToolStripMenuItem1.Name = "addToolStripMenuItem1";
            addToolStripMenuItem1.Size = new Size(112, 22);
            addToolStripMenuItem1.Text = "Add";
            // 
            // updateToolStripMenuItem
            // 
            updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            updateToolStripMenuItem.Size = new Size(112, 22);
            updateToolStripMenuItem.Text = "Update";
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(112, 22);
            deleteToolStripMenuItem.Text = "Delete";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 505);
            label2.Name = "label2";
            label2.Size = new Size(78, 15);
            label2.TabIndex = 9;
            label2.Text = "Product price";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 416);
            label1.Name = "label1";
            label1.Size = new Size(82, 15);
            label1.TabIndex = 8;
            label1.Text = "Product name";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(151, 583);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(136, 23);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Add Product";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // tbPrice
            // 
            tbPrice.Location = new Point(114, 497);
            tbPrice.Name = "tbPrice";
            tbPrice.Size = new Size(212, 23);
            tbPrice.TabIndex = 6;
            // 
            // tbName
            // 
            tbName.Location = new Point(114, 413);
            tbName.Name = "tbName";
            tbName.Size = new Size(212, 23);
            tbName.TabIndex = 5;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1269, 743);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnAdd);
            Controls.Add(tbPrice);
            Controls.Add(tbName);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Menu";
            Text = "Menu";
            Load += Menu_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem addToolStripMenuItem;
        private ToolStripMenuItem addToolStripMenuItem1;
        private ToolStripMenuItem updateToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private Label label2;
        private Label label1;
        private Button btnAdd;
        private TextBox tbPrice;
        private TextBox tbName;
    }
}