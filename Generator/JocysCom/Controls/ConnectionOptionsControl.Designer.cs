namespace JocysCom.ClassLibrary.Controls
{
	partial class ConnectionOptionsControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionOptionsControl));
			this.DatabaseConnectionsGroupBox = new System.Windows.Forms.GroupBox();
			this.ConnectionsDataGridView = new System.Windows.Forms.DataGridView();
			this.TypeColumn = new System.Windows.Forms.DataGridViewImageColumn();
			this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ConnectionStringColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.PropertiesColumn = new System.Windows.Forms.DataGridViewLinkColumn();
			this.PresetComboBox = new System.Windows.Forms.ComboBox();
			this.PresetLabel = new System.Windows.Forms.Label();
			this.LogsTextBox = new System.Windows.Forms.TextBox();
			this.ConnectionTypeImageList = new System.Windows.Forms.ImageList(this.components);
			this.DatabaseConnectionsGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ConnectionsDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// DatabaseConnectionsGroupBox
			// 
			this.DatabaseConnectionsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.DatabaseConnectionsGroupBox.Controls.Add(this.ConnectionsDataGridView);
			this.DatabaseConnectionsGroupBox.Controls.Add(this.PresetComboBox);
			this.DatabaseConnectionsGroupBox.Controls.Add(this.PresetLabel);
			this.DatabaseConnectionsGroupBox.Location = new System.Drawing.Point(3, 3);
			this.DatabaseConnectionsGroupBox.Name = "DatabaseConnectionsGroupBox";
			this.DatabaseConnectionsGroupBox.Size = new System.Drawing.Size(627, 257);
			this.DatabaseConnectionsGroupBox.TabIndex = 94;
			this.DatabaseConnectionsGroupBox.TabStop = false;
			this.DatabaseConnectionsGroupBox.Text = "Database Connection Strings";
			// 
			// ConnectionsDataGridView
			// 
			this.ConnectionsDataGridView.AllowUserToAddRows = false;
			this.ConnectionsDataGridView.AllowUserToDeleteRows = false;
			this.ConnectionsDataGridView.AllowUserToResizeRows = false;
			this.ConnectionsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ConnectionsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
			this.ConnectionsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ConnectionsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TypeColumn,
            this.NameColumn,
            this.ConnectionStringColumn,
            this.PropertiesColumn});
			this.ConnectionsDataGridView.Location = new System.Drawing.Point(6, 46);
			this.ConnectionsDataGridView.Name = "ConnectionsDataGridView";
			this.ConnectionsDataGridView.RowHeadersVisible = false;
			this.ConnectionsDataGridView.Size = new System.Drawing.Size(615, 205);
			this.ConnectionsDataGridView.TabIndex = 2;
			this.ConnectionsDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ConnectionsDataGridView_CellClick);
			this.ConnectionsDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ConnectionsDataGridView_CellDoubleClick);
			this.ConnectionsDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.ConnectionsDataGridView_CellFormatting);
			// 
			// TypeColumn
			// 
			this.TypeColumn.HeaderText = "";
			this.TypeColumn.Image = ((System.Drawing.Image)(resources.GetObject("TypeColumn.Image")));
			this.TypeColumn.MinimumWidth = 16;
			this.TypeColumn.Name = "TypeColumn";
			this.TypeColumn.ReadOnly = true;
			this.TypeColumn.Width = 20;
			// 
			// NameColumn
			// 
			this.NameColumn.HeaderText = "Name";
			this.NameColumn.Name = "NameColumn";
			this.NameColumn.ReadOnly = true;
			// 
			// ConnectionStringColumn
			// 
			this.ConnectionStringColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.ConnectionStringColumn.HeaderText = "Connection String";
			this.ConnectionStringColumn.Name = "ConnectionStringColumn";
			this.ConnectionStringColumn.ReadOnly = true;
			// 
			// PropertiesColumn
			// 
			this.PropertiesColumn.ActiveLinkColor = System.Drawing.Color.Blue;
			this.PropertiesColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.PropertiesColumn.HeaderText = "Properties";
			this.PropertiesColumn.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.PropertiesColumn.LinkColor = System.Drawing.Color.Blue;
			this.PropertiesColumn.Name = "PropertiesColumn";
			this.PropertiesColumn.ReadOnly = true;
			this.PropertiesColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.PropertiesColumn.VisitedLinkColor = System.Drawing.Color.Blue;
			this.PropertiesColumn.Width = 60;
			// 
			// PresetComboBox
			// 
			this.PresetComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.PresetComboBox.FormattingEnabled = true;
			this.PresetComboBox.Location = new System.Drawing.Point(52, 19);
			this.PresetComboBox.Name = "PresetComboBox";
			this.PresetComboBox.Size = new System.Drawing.Size(239, 21);
			this.PresetComboBox.TabIndex = 1;
			this.PresetComboBox.SelectedIndexChanged += new System.EventHandler(this.PresetComboBox_SelectedIndexChanged);
			// 
			// PresetLabel
			// 
			this.PresetLabel.AutoSize = true;
			this.PresetLabel.Location = new System.Drawing.Point(6, 22);
			this.PresetLabel.Name = "PresetLabel";
			this.PresetLabel.Size = new System.Drawing.Size(40, 13);
			this.PresetLabel.TabIndex = 95;
			this.PresetLabel.Text = "Preset:";
			// 
			// LogsTextBox
			// 
			this.LogsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.LogsTextBox.BackColor = System.Drawing.SystemColors.Control;
			this.LogsTextBox.Location = new System.Drawing.Point(3, 266);
			this.LogsTextBox.Multiline = true;
			this.LogsTextBox.Name = "LogsTextBox";
			this.LogsTextBox.Size = new System.Drawing.Size(627, 167);
			this.LogsTextBox.TabIndex = 3;
			// 
			// ConnectionTypeImageList
			// 
			this.ConnectionTypeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ConnectionTypeImageList.ImageStream")));
			this.ConnectionTypeImageList.TransparentColor = System.Drawing.Color.Transparent;
			this.ConnectionTypeImageList.Images.SetKeyName(0, "Data_Entity");
			this.ConnectionTypeImageList.Images.SetKeyName(1, "Data");
			// 
			// ConnectionOptionsControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.DatabaseConnectionsGroupBox);
			this.Controls.Add(this.LogsTextBox);
			this.Name = "ConnectionOptionsControl";
			this.Size = new System.Drawing.Size(633, 436);
			this.Load += new System.EventHandler(this.ConnectionOptionsControl_Load);
			this.DatabaseConnectionsGroupBox.ResumeLayout(false);
			this.DatabaseConnectionsGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ConnectionsDataGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.GroupBox DatabaseConnectionsGroupBox;
        private System.Windows.Forms.TextBox LogsTextBox;
		private System.Windows.Forms.ComboBox PresetComboBox;
        private System.Windows.Forms.Label PresetLabel;
		private System.Windows.Forms.DataGridView ConnectionsDataGridView;
		private System.Windows.Forms.ImageList ConnectionTypeImageList;
		private System.Windows.Forms.DataGridViewImageColumn TypeColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn ConnectionStringColumn;
		private System.Windows.Forms.DataGridViewLinkColumn PropertiesColumn;
	}
}
