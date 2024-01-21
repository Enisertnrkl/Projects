namespace Stockmanagement
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.button7 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.ürünToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ürünEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ürünDüzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ürünSilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ürünSatışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stokKontrolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.geçmişToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.silmeGeçmişiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.kategoriEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.kategoriEkleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.birimEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.kullanıcıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.kullanıcıBilgileriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.çıkışYapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToResizeColumns = false;
			this.dataGridView1.AllowUserToResizeRows = false;
			this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
			this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			resources.ApplyResources(this.dataGridView1, "dataGridView1");
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gray;
			this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dataGridView1.ShowEditingIcon = false;
			// 
			// comboBox1
			// 
			this.comboBox1.BackColor = System.Drawing.Color.White;
			this.comboBox1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			resources.ApplyResources(this.comboBox1, "comboBox1");
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// button7
			// 
			resources.ApplyResources(this.button7, "button7");
			this.button7.Name = "button7";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// textBox1
			// 
			resources.ApplyResources(this.textBox1, "textBox1");
			this.textBox1.Name = "textBox1";
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ürünToolStripMenuItem,
            this.geçmişToolStripMenuItem,
            this.panelToolStripMenuItem,
            this.kullanıcıToolStripMenuItem});
			resources.ApplyResources(this.menuStrip1, "menuStrip1");
			this.menuStrip1.Name = "menuStrip1";
			// 
			// ürünToolStripMenuItem
			// 
			this.ürünToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ürünEkleToolStripMenuItem,
            this.ürünDüzenleToolStripMenuItem,
            this.ürünSilToolStripMenuItem,
            this.ürünSatışToolStripMenuItem,
            this.stokKontrolToolStripMenuItem});
			this.ürünToolStripMenuItem.Name = "ürünToolStripMenuItem";
			resources.ApplyResources(this.ürünToolStripMenuItem, "ürünToolStripMenuItem");
			// 
			// ürünEkleToolStripMenuItem
			// 
			this.ürünEkleToolStripMenuItem.Name = "ürünEkleToolStripMenuItem";
			resources.ApplyResources(this.ürünEkleToolStripMenuItem, "ürünEkleToolStripMenuItem");
			this.ürünEkleToolStripMenuItem.Click += new System.EventHandler(this.ürünEkleToolStripMenuItem_Click);
			// 
			// ürünDüzenleToolStripMenuItem
			// 
			this.ürünDüzenleToolStripMenuItem.Name = "ürünDüzenleToolStripMenuItem";
			resources.ApplyResources(this.ürünDüzenleToolStripMenuItem, "ürünDüzenleToolStripMenuItem");
			this.ürünDüzenleToolStripMenuItem.Click += new System.EventHandler(this.ürünDüzenleToolStripMenuItem_Click);
			// 
			// ürünSilToolStripMenuItem
			// 
			this.ürünSilToolStripMenuItem.Name = "ürünSilToolStripMenuItem";
			resources.ApplyResources(this.ürünSilToolStripMenuItem, "ürünSilToolStripMenuItem");
			this.ürünSilToolStripMenuItem.Click += new System.EventHandler(this.ürünSilToolStripMenuItem_Click);
			// 
			// ürünSatışToolStripMenuItem
			// 
			this.ürünSatışToolStripMenuItem.Name = "ürünSatışToolStripMenuItem";
			resources.ApplyResources(this.ürünSatışToolStripMenuItem, "ürünSatışToolStripMenuItem");
			this.ürünSatışToolStripMenuItem.Click += new System.EventHandler(this.ürünSatışToolStripMenuItem_Click);
			// 
			// stokKontrolToolStripMenuItem
			// 
			this.stokKontrolToolStripMenuItem.Name = "stokKontrolToolStripMenuItem";
			resources.ApplyResources(this.stokKontrolToolStripMenuItem, "stokKontrolToolStripMenuItem");
			this.stokKontrolToolStripMenuItem.Click += new System.EventHandler(this.stokKontrolToolStripMenuItem_Click);
			// 
			// geçmişToolStripMenuItem
			// 
			this.geçmişToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.silmeGeçmişiToolStripMenuItem});
			this.geçmişToolStripMenuItem.Name = "geçmişToolStripMenuItem";
			resources.ApplyResources(this.geçmişToolStripMenuItem, "geçmişToolStripMenuItem");
			// 
			// silmeGeçmişiToolStripMenuItem
			// 
			this.silmeGeçmişiToolStripMenuItem.Name = "silmeGeçmişiToolStripMenuItem";
			resources.ApplyResources(this.silmeGeçmişiToolStripMenuItem, "silmeGeçmişiToolStripMenuItem");
			this.silmeGeçmişiToolStripMenuItem.Click += new System.EventHandler(this.silmeGeçmişiToolStripMenuItem_Click);
			// 
			// panelToolStripMenuItem
			// 
			this.panelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kategoriEkleToolStripMenuItem});
			this.panelToolStripMenuItem.Name = "panelToolStripMenuItem";
			resources.ApplyResources(this.panelToolStripMenuItem, "panelToolStripMenuItem");
			// 
			// kategoriEkleToolStripMenuItem
			// 
			this.kategoriEkleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kategoriEkleToolStripMenuItem1,
            this.birimEkleToolStripMenuItem});
			this.kategoriEkleToolStripMenuItem.Name = "kategoriEkleToolStripMenuItem";
			resources.ApplyResources(this.kategoriEkleToolStripMenuItem, "kategoriEkleToolStripMenuItem");
			// 
			// kategoriEkleToolStripMenuItem1
			// 
			this.kategoriEkleToolStripMenuItem1.Name = "kategoriEkleToolStripMenuItem1";
			resources.ApplyResources(this.kategoriEkleToolStripMenuItem1, "kategoriEkleToolStripMenuItem1");
			this.kategoriEkleToolStripMenuItem1.Click += new System.EventHandler(this.kategoriEkleToolStripMenuItem1_Click);
			// 
			// birimEkleToolStripMenuItem
			// 
			this.birimEkleToolStripMenuItem.Name = "birimEkleToolStripMenuItem";
			resources.ApplyResources(this.birimEkleToolStripMenuItem, "birimEkleToolStripMenuItem");
			this.birimEkleToolStripMenuItem.Click += new System.EventHandler(this.birimEkleToolStripMenuItem_Click);
			// 
			// kullanıcıToolStripMenuItem
			// 
			this.kullanıcıToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kullanıcıBilgileriToolStripMenuItem,
            this.çıkışYapToolStripMenuItem});
			this.kullanıcıToolStripMenuItem.Name = "kullanıcıToolStripMenuItem";
			resources.ApplyResources(this.kullanıcıToolStripMenuItem, "kullanıcıToolStripMenuItem");
			// 
			// kullanıcıBilgileriToolStripMenuItem
			// 
			this.kullanıcıBilgileriToolStripMenuItem.Name = "kullanıcıBilgileriToolStripMenuItem";
			resources.ApplyResources(this.kullanıcıBilgileriToolStripMenuItem, "kullanıcıBilgileriToolStripMenuItem");
			this.kullanıcıBilgileriToolStripMenuItem.Click += new System.EventHandler(this.kullanıcıBilgileriToolStripMenuItem_Click);
			// 
			// çıkışYapToolStripMenuItem
			// 
			this.çıkışYapToolStripMenuItem.Name = "çıkışYapToolStripMenuItem";
			resources.ApplyResources(this.çıkışYapToolStripMenuItem, "çıkışYapToolStripMenuItem");
			this.çıkışYapToolStripMenuItem.Click += new System.EventHandler(this.çıkışYapToolStripMenuItem_Click);
			// 
			// notifyIcon1
			// 
			resources.ApplyResources(this.notifyIcon1, "notifyIcon1");
			this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
			// 
			// Menu
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Menu";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Menu_FormClosing);
			this.Load += new System.EventHandler(this.Menu_Load);
			this.Move += new System.EventHandler(this.Menu_Move);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ürünToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem geçmişToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kullanıcıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ürünEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ürünDüzenleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ürünSilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem silmeGeçmişiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kullanıcıBilgileriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ürünSatışToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem çıkışYapToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem stokKontrolToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem panelToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem kategoriEkleToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem kategoriEkleToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem birimEkleToolStripMenuItem;
	}
}