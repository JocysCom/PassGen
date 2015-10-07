namespace JocysCom.Password.Generator.Controls
{
	partial class AboutControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		System.ComponentModel.IContainer components = null;

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
		void InitializeComponent()
		{
			this.ChangeLogTextBox = new System.Windows.Forms.TextBox();
			this.AboutDescriptionLabel = new System.Windows.Forms.Label();
			this.AboutJocysLinkLabel = new System.Windows.Forms.LinkLabel();
			this.AboutJocysLabel = new System.Windows.Forms.Label();
			this.AboutProductLabel = new System.Windows.Forms.Label();
			this.GoogleProjectLabel = new System.Windows.Forms.Label();
			this.GoogleProjectLinkLabel = new System.Windows.Forms.LinkLabel();
			this.AboutTabControl = new System.Windows.Forms.TabControl();
			this.ChangesTabPage = new System.Windows.Forms.TabPage();
			this.LicenseTabPage = new System.Windows.Forms.TabPage();
			this.LicenseTextBox = new System.Windows.Forms.TextBox();
			this.ProductPictureBox = new System.Windows.Forms.PictureBox();
			this.AboutTabControl.SuspendLayout();
			this.ChangesTabPage.SuspendLayout();
			this.LicenseTabPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ProductPictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// ChangeLogTextBox
			// 
			this.ChangeLogTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ChangeLogTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ChangeLogTextBox.Location = new System.Drawing.Point(0, 0);
			this.ChangeLogTextBox.Multiline = true;
			this.ChangeLogTextBox.Name = "ChangeLogTextBox";
			this.ChangeLogTextBox.ReadOnly = true;
			this.ChangeLogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.ChangeLogTextBox.Size = new System.Drawing.Size(605, 330);
			this.ChangeLogTextBox.TabIndex = 0;
			// 
			// AboutDescriptionLabel
			// 
			this.AboutDescriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.AboutDescriptionLabel.Location = new System.Drawing.Point(148, 37);
			this.AboutDescriptionLabel.Name = "AboutDescriptionLabel";
			this.AboutDescriptionLabel.Size = new System.Drawing.Size(464, 57);
			this.AboutDescriptionLabel.TabIndex = 0;
			this.AboutDescriptionLabel.Text = "Program Description";
			// 
			// AboutJocysLinkLabel
			// 
			this.AboutJocysLinkLabel.AutoSize = true;
			this.AboutJocysLinkLabel.Location = new System.Drawing.Point(233, 94);
			this.AboutJocysLinkLabel.Name = "AboutJocysLinkLabel";
			this.AboutJocysLinkLabel.Size = new System.Drawing.Size(112, 13);
			this.AboutJocysLinkLabel.TabIndex = 0;
			this.AboutJocysLinkLabel.TabStop = true;
			this.AboutJocysLinkLabel.Text = "http://www.jocys.com";
			this.AboutJocysLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_LinkClicked);
			// 
			// AboutJocysLabel
			// 
			this.AboutJocysLabel.AutoSize = true;
			this.AboutJocysLabel.Location = new System.Drawing.Point(148, 94);
			this.AboutJocysLabel.Name = "AboutJocysLabel";
			this.AboutJocysLabel.Size = new System.Drawing.Size(60, 13);
			this.AboutJocysLabel.TabIndex = 0;
			this.AboutJocysLabel.Text = "Jocys.com:";
			// 
			// AboutProductLabel
			// 
			this.AboutProductLabel.AutoSize = true;
			this.AboutProductLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AboutProductLabel.Location = new System.Drawing.Point(148, 16);
			this.AboutProductLabel.Name = "AboutProductLabel";
			this.AboutProductLabel.Size = new System.Drawing.Size(165, 13);
			this.AboutProductLabel.TabIndex = 0;
			this.AboutProductLabel.Text = "Company Program Name {0}";
			// 
			// GoogleProjectLabel
			// 
			this.GoogleProjectLabel.AutoSize = true;
			this.GoogleProjectLabel.Location = new System.Drawing.Point(148, 111);
			this.GoogleProjectLabel.Name = "GoogleProjectLabel";
			this.GoogleProjectLabel.Size = new System.Drawing.Size(79, 13);
			this.GoogleProjectLabel.TabIndex = 0;
			this.GoogleProjectLabel.Text = "GitHub Project:";
			// 
			// GoogleProjectLinkLabel
			// 
			this.GoogleProjectLinkLabel.AutoSize = true;
			this.GoogleProjectLinkLabel.Location = new System.Drawing.Point(233, 111);
			this.GoogleProjectLinkLabel.Name = "GoogleProjectLinkLabel";
			this.GoogleProjectLinkLabel.Size = new System.Drawing.Size(196, 13);
			this.GoogleProjectLinkLabel.TabIndex = 0;
			this.GoogleProjectLinkLabel.TabStop = true;
			this.GoogleProjectLinkLabel.Text = "https://github.com/JocysCom/PassGen";
			this.GoogleProjectLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_LinkClicked);
			// 
			// AboutTabControl
			// 
			this.AboutTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.AboutTabControl.Controls.Add(this.ChangesTabPage);
			this.AboutTabControl.Controls.Add(this.LicenseTabPage);
			this.AboutTabControl.Location = new System.Drawing.Point(3, 137);
			this.AboutTabControl.Name = "AboutTabControl";
			this.AboutTabControl.SelectedIndex = 0;
			this.AboutTabControl.Size = new System.Drawing.Size(613, 356);
			this.AboutTabControl.TabIndex = 1;
			// 
			// ChangesTabPage
			// 
			this.ChangesTabPage.Controls.Add(this.ChangeLogTextBox);
			this.ChangesTabPage.Location = new System.Drawing.Point(4, 22);
			this.ChangesTabPage.Name = "ChangesTabPage";
			this.ChangesTabPage.Size = new System.Drawing.Size(605, 330);
			this.ChangesTabPage.TabIndex = 0;
			this.ChangesTabPage.Text = "Changes";
			this.ChangesTabPage.UseVisualStyleBackColor = true;
			// 
			// LicenseTabPage
			// 
			this.LicenseTabPage.Controls.Add(this.LicenseTextBox);
			this.LicenseTabPage.Location = new System.Drawing.Point(4, 22);
			this.LicenseTabPage.Name = "LicenseTabPage";
			this.LicenseTabPage.Size = new System.Drawing.Size(605, 330);
			this.LicenseTabPage.TabIndex = 1;
			this.LicenseTabPage.Text = "License";
			this.LicenseTabPage.UseVisualStyleBackColor = true;
			// 
			// LicenseTextBox
			// 
			this.LicenseTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.LicenseTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LicenseTextBox.Location = new System.Drawing.Point(0, 0);
			this.LicenseTextBox.Multiline = true;
			this.LicenseTextBox.Name = "LicenseTextBox";
			this.LicenseTextBox.ReadOnly = true;
			this.LicenseTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.LicenseTextBox.Size = new System.Drawing.Size(605, 330);
			this.LicenseTextBox.TabIndex = 1;
			// 
			// ProductPictureBox
			// 
			this.ProductPictureBox.Image = global::JocysCom.Password.Generator.Properties.Resources.generator_128x128;
			this.ProductPictureBox.Location = new System.Drawing.Point(3, 3);
			this.ProductPictureBox.Name = "ProductPictureBox";
			this.ProductPictureBox.Size = new System.Drawing.Size(128, 128);
			this.ProductPictureBox.TabIndex = 0;
			this.ProductPictureBox.TabStop = false;
			// 
			// AboutControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.AboutTabControl);
			this.Controls.Add(this.AboutDescriptionLabel);
			this.Controls.Add(this.GoogleProjectLinkLabel);
			this.Controls.Add(this.AboutJocysLinkLabel);
			this.Controls.Add(this.GoogleProjectLabel);
			this.Controls.Add(this.AboutJocysLabel);
			this.Controls.Add(this.AboutProductLabel);
			this.Controls.Add(this.ProductPictureBox);
			this.Name = "AboutControl";
			this.Size = new System.Drawing.Size(619, 496);
			this.AboutTabControl.ResumeLayout(false);
			this.ChangesTabPage.ResumeLayout(false);
			this.ChangesTabPage.PerformLayout();
			this.LicenseTabPage.ResumeLayout(false);
			this.LicenseTabPage.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ProductPictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		System.Windows.Forms.TextBox ChangeLogTextBox;
		System.Windows.Forms.Label AboutDescriptionLabel;
		System.Windows.Forms.LinkLabel AboutJocysLinkLabel;
		System.Windows.Forms.Label AboutJocysLabel;
		System.Windows.Forms.Label AboutProductLabel;
		System.Windows.Forms.PictureBox ProductPictureBox;
		System.Windows.Forms.Label GoogleProjectLabel;
		System.Windows.Forms.LinkLabel GoogleProjectLinkLabel;
		private System.Windows.Forms.TabControl AboutTabControl;
		private System.Windows.Forms.TabPage ChangesTabPage;
		private System.Windows.Forms.TabPage LicenseTabPage;
		private System.Windows.Forms.TextBox LicenseTextBox;
	}
}
