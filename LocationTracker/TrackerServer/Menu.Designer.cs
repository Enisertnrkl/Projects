namespace TaxiServer
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
			components = new System.ComponentModel.Container();
			gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
			dataGridView1 = new DataGridView();
			timer1 = new System.Windows.Forms.Timer(components);
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			SuspendLayout();
			// 
			// gMapControl1
			// 
			gMapControl1.Bearing = 0F;
			gMapControl1.CanDragMap = true;
			gMapControl1.EmptyTileColor = Color.Navy;
			gMapControl1.GrayScaleMode = false;
			gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
			gMapControl1.LevelsKeepInMemory = 5;
			gMapControl1.Location = new Point(924, 1);
			gMapControl1.MarkersEnabled = true;
			gMapControl1.MaxZoom = 2;
			gMapControl1.MinZoom = 2;
			gMapControl1.MouseWheelZoomEnabled = true;
			gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
			gMapControl1.Name = "gMapControl1";
			gMapControl1.NegativeMode = false;
			gMapControl1.PolygonsEnabled = true;
			gMapControl1.RetryLoadTile = 0;
			gMapControl1.RoutesEnabled = true;
			gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
			gMapControl1.SelectedAreaFillColor = Color.FromArgb(33, 65, 105, 225);
			gMapControl1.ShowTileGridLines = false;
			gMapControl1.Size = new Size(463, 817);
			gMapControl1.TabIndex = 0;
			gMapControl1.Zoom = 0D;
			// 
			// dataGridView1
			// 
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.AllowUserToDeleteRows = false;
			dataGridView1.AllowUserToResizeColumns = false;
			dataGridView1.AllowUserToResizeRows = false;
			dataGridView1.BackgroundColor = SystemColors.AppWorkspace;
			dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Location = new Point(23, 12);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.ReadOnly = true;
			dataGridView1.RowHeadersVisible = false;
			dataGridView1.Size = new Size(895, 796);
			dataGridView1.TabIndex = 1;
			// 
			// timer1
			// 
			timer1.Tick += timer1_Tick;
			// 
			// Menu
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1399, 820);
			Controls.Add(dataGridView1);
			Controls.Add(gMapControl1);
			Name = "Menu";
			Text = "Form2";
			Load += Form2_Load;
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private GMap.NET.WindowsForms.GMapControl gMapControl1;
		private DataGridView dataGridView1;
		private System.Windows.Forms.Timer timer1;
	}
}