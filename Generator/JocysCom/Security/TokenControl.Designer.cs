namespace JocysCom.ClassLibrary.Security
{
	partial class TokenControl
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
			this.UserIdTextBox = new System.Windows.Forms.TextBox();
			this.UserIdLabel = new System.Windows.Forms.Label();
			this.UnlockTokenLabel = new System.Windows.Forms.Label();
			this.UnlockTokenTextBox = new System.Windows.Forms.TextBox();
			this.UnlockUnitTypeComboBox = new System.Windows.Forms.ComboBox();
			this.UnlockDurationUpDown = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.UnlockKeyTextBox = new System.Windows.Forms.TextBox();
			this.PasswordTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.SecurityTokenTextBox = new System.Windows.Forms.TextBox();
			this.SecurityTokenLabel = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.RegenerateButton = new System.Windows.Forms.Button();
			this.UnlockTokenCheckTextBox = new System.Windows.Forms.TextBox();
			this.SecurityTokenCheckTextBox = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.UnlockDurationUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// UserIdTextBox
			// 
			this.UserIdTextBox.Location = new System.Drawing.Point(6, 55);
			this.UserIdTextBox.Name = "UserIdTextBox";
			this.UserIdTextBox.Size = new System.Drawing.Size(75, 20);
			this.UserIdTextBox.TabIndex = 0;
			this.UserIdTextBox.TextChanged += new System.EventHandler(this.UserIdTextBox_TextChanged);
			// 
			// UserIdLabel
			// 
			this.UserIdLabel.AutoSize = true;
			this.UserIdLabel.Location = new System.Drawing.Point(6, 39);
			this.UserIdLabel.Name = "UserIdLabel";
			this.UserIdLabel.Size = new System.Drawing.Size(46, 13);
			this.UserIdLabel.TabIndex = 1;
			this.UserIdLabel.Text = "User ID:";
			// 
			// UnlockTokenLabel
			// 
			this.UnlockTokenLabel.AutoSize = true;
			this.UnlockTokenLabel.Location = new System.Drawing.Point(190, 81);
			this.UnlockTokenLabel.Name = "UnlockTokenLabel";
			this.UnlockTokenLabel.Size = new System.Drawing.Size(78, 13);
			this.UnlockTokenLabel.TabIndex = 5;
			this.UnlockTokenLabel.Text = "Unlock Token:";
			// 
			// UnlockTokenTextBox
			// 
			this.UnlockTokenTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.UnlockTokenTextBox.Location = new System.Drawing.Point(193, 97);
			this.UnlockTokenTextBox.Name = "UnlockTokenTextBox";
			this.UnlockTokenTextBox.Size = new System.Drawing.Size(153, 20);
			this.UnlockTokenTextBox.TabIndex = 4;
			this.UnlockTokenTextBox.TextChanged += new System.EventHandler(this.UnlockTokenTextBox_TextChanged);
			// 
			// UnlockUnitTypeComboBox
			// 
			this.UnlockUnitTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.UnlockUnitTypeComboBox.FormattingEnabled = true;
			this.UnlockUnitTypeComboBox.Location = new System.Drawing.Point(87, 15);
			this.UnlockUnitTypeComboBox.Name = "UnlockUnitTypeComboBox";
			this.UnlockUnitTypeComboBox.Size = new System.Drawing.Size(100, 21);
			this.UnlockUnitTypeComboBox.TabIndex = 3;
			this.UnlockUnitTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.UnlockUnitTypeComboBox_SelectedIndexChanged);
			// 
			// UnlockDurationUpDown
			// 
			this.UnlockDurationUpDown.Location = new System.Drawing.Point(6, 16);
			this.UnlockDurationUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.UnlockDurationUpDown.Name = "UnlockDurationUpDown";
			this.UnlockDurationUpDown.Size = new System.Drawing.Size(75, 20);
			this.UnlockDurationUpDown.TabIndex = 2;
			this.UnlockDurationUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.UnlockDurationUpDown.ValueChanged += new System.EventHandler(this.UnlockDurationUpDown_ValueChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 81);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(28, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Key:";
			// 
			// UnlockKeyTextBox
			// 
			this.UnlockKeyTextBox.Location = new System.Drawing.Point(6, 97);
			this.UnlockKeyTextBox.Name = "UnlockKeyTextBox";
			this.UnlockKeyTextBox.Size = new System.Drawing.Size(75, 20);
			this.UnlockKeyTextBox.TabIndex = 0;
			this.UnlockKeyTextBox.TextChanged += new System.EventHandler(this.UnlockKeyTextBox_TextChanged);
			// 
			// PasswordTextBox
			// 
			this.PasswordTextBox.Location = new System.Drawing.Point(87, 55);
			this.PasswordTextBox.Name = "PasswordTextBox";
			this.PasswordTextBox.Size = new System.Drawing.Size(100, 20);
			this.PasswordTextBox.TabIndex = 0;
			this.PasswordTextBox.UseSystemPasswordChar = true;
			this.PasswordTextBox.TextChanged += new System.EventHandler(this.UserIdTextBox_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(84, 39);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Password:";
			// 
			// SecurityTokenTextBox
			// 
			this.SecurityTokenTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SecurityTokenTextBox.Location = new System.Drawing.Point(193, 55);
			this.SecurityTokenTextBox.Name = "SecurityTokenTextBox";
			this.SecurityTokenTextBox.Size = new System.Drawing.Size(153, 20);
			this.SecurityTokenTextBox.TabIndex = 4;
			this.SecurityTokenTextBox.TextChanged += new System.EventHandler(this.SecurityTokenTextBox_TextChanged);
			// 
			// SecurityTokenLabel
			// 
			this.SecurityTokenLabel.AutoSize = true;
			this.SecurityTokenLabel.Location = new System.Drawing.Point(190, 39);
			this.SecurityTokenLabel.Name = "SecurityTokenLabel";
			this.SecurityTokenLabel.Size = new System.Drawing.Size(82, 13);
			this.SecurityTokenLabel.TabIndex = 5;
			this.SecurityTokenLabel.Text = "Security Token:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(3, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(50, 13);
			this.label6.TabIndex = 1;
			this.label6.Text = "Duration:";
			// 
			// RegenerateButton
			// 
			this.RegenerateButton.Location = new System.Drawing.Point(352, 13);
			this.RegenerateButton.Name = "RegenerateButton";
			this.RegenerateButton.Size = new System.Drawing.Size(75, 23);
			this.RegenerateButton.TabIndex = 6;
			this.RegenerateButton.Text = "Regenerate";
			this.RegenerateButton.UseVisualStyleBackColor = true;
			this.RegenerateButton.Click += new System.EventHandler(this.RegenerateButton_Click);
			// 
			// UnlockTokenCheckTextBox
			// 
			this.UnlockTokenCheckTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.UnlockTokenCheckTextBox.Location = new System.Drawing.Point(352, 97);
			this.UnlockTokenCheckTextBox.Name = "UnlockTokenCheckTextBox";
			this.UnlockTokenCheckTextBox.ReadOnly = true;
			this.UnlockTokenCheckTextBox.Size = new System.Drawing.Size(75, 20);
			this.UnlockTokenCheckTextBox.TabIndex = 4;
			// 
			// SecurityTokenCheckTextBox
			// 
			this.SecurityTokenCheckTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.SecurityTokenCheckTextBox.Location = new System.Drawing.Point(352, 55);
			this.SecurityTokenCheckTextBox.Name = "SecurityTokenCheckTextBox";
			this.SecurityTokenCheckTextBox.ReadOnly = true;
			this.SecurityTokenCheckTextBox.Size = new System.Drawing.Size(75, 20);
			this.SecurityTokenCheckTextBox.TabIndex = 4;
			// 
			// TokenControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.RegenerateButton);
			this.Controls.Add(this.UnlockTokenLabel);
			this.Controls.Add(this.UnlockTokenCheckTextBox);
			this.Controls.Add(this.UnlockTokenTextBox);
			this.Controls.Add(this.SecurityTokenLabel);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.SecurityTokenCheckTextBox);
			this.Controls.Add(this.UnlockKeyTextBox);
			this.Controls.Add(this.SecurityTokenTextBox);
			this.Controls.Add(this.UnlockDurationUpDown);
			this.Controls.Add(this.UnlockUnitTypeComboBox);
			this.Controls.Add(this.UserIdLabel);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.PasswordTextBox);
			this.Controls.Add(this.UserIdTextBox);
			this.Name = "TokenControl";
			this.Size = new System.Drawing.Size(430, 126);
			this.Load += new System.EventHandler(this.TokenControl_Load);
			((System.ComponentModel.ISupportInitialize)(this.UnlockDurationUpDown)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox UserIdTextBox;
		private System.Windows.Forms.Label UserIdLabel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox UnlockKeyTextBox;
		private System.Windows.Forms.ComboBox UnlockUnitTypeComboBox;
		private System.Windows.Forms.NumericUpDown UnlockDurationUpDown;
		private System.Windows.Forms.Label UnlockTokenLabel;
		private System.Windows.Forms.TextBox UnlockTokenTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label SecurityTokenLabel;
		private System.Windows.Forms.TextBox SecurityTokenTextBox;
		private System.Windows.Forms.TextBox PasswordTextBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button RegenerateButton;
		private System.Windows.Forms.TextBox UnlockTokenCheckTextBox;
		private System.Windows.Forms.TextBox SecurityTokenCheckTextBox;
	}
}
