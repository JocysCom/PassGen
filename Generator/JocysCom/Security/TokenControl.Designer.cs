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
			this.UnlockTokenLabel = new System.Windows.Forms.Label();
			this.UnlockTokenTextBox = new System.Windows.Forms.TextBox();
			this.UnitTypeComboBox = new System.Windows.Forms.ComboBox();
			this.UnlockDurationUpDown = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.UnlockKeyTextBox = new System.Windows.Forms.TextBox();
			this.SecurityTokenTextBox = new System.Windows.Forms.TextBox();
			this.RegenerateButton = new System.Windows.Forms.Button();
			this.UnlockTokenCheckTextBox = new System.Windows.Forms.TextBox();
			this.SecurityTokenCheckTextBox = new System.Windows.Forms.TextBox();
			this.TokenStartDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.DurationGroupBox = new System.Windows.Forms.GroupBox();
			this.NowLinkLabel = new System.Windows.Forms.LinkLabel();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.UnitValueHexTextBox = new System.Windows.Forms.TextBox();
			this.UnitValueTextBox = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.Param1ComboBox = new System.Windows.Forms.ComboBox();
			this.Param2Label = new System.Windows.Forms.Label();
			this.Param1Label = new System.Windows.Forms.Label();
			this.LogTextBox = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.HashKeyLabel = new System.Windows.Forms.Label();
			this.SecretComboBox = new System.Windows.Forms.ComboBox();
			this.ValueLabel = new System.Windows.Forms.Label();
			this.HashKeyTextBox = new System.Windows.Forms.TextBox();
			this.SecurtyTokenDataTextBox = new System.Windows.Forms.TextBox();
			this.CheckSecurityTokenButton = new System.Windows.Forms.Button();
			this.UnlockTokenGroupBox = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.Param2TextBox = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.UnlockDurationUpDown)).BeginInit();
			this.DurationGroupBox.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.UnlockTokenGroupBox.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// UnlockTokenLabel
			// 
			this.UnlockTokenLabel.AutoSize = true;
			this.UnlockTokenLabel.Location = new System.Drawing.Point(6, 48);
			this.UnlockTokenLabel.Name = "UnlockTokenLabel";
			this.UnlockTokenLabel.Size = new System.Drawing.Size(41, 13);
			this.UnlockTokenLabel.TabIndex = 5;
			this.UnlockTokenLabel.Text = "Token:";
			// 
			// UnlockTokenTextBox
			// 
			this.UnlockTokenTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.UnlockTokenTextBox.Location = new System.Drawing.Point(68, 45);
			this.UnlockTokenTextBox.Name = "UnlockTokenTextBox";
			this.UnlockTokenTextBox.Size = new System.Drawing.Size(287, 20);
			this.UnlockTokenTextBox.TabIndex = 4;
			this.UnlockTokenTextBox.TextChanged += new System.EventHandler(this.UnlockTokenTextBox_TextChanged);
			// 
			// UnitTypeComboBox
			// 
			this.UnitTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.UnitTypeComboBox.FormattingEnabled = true;
			this.UnitTypeComboBox.Location = new System.Drawing.Point(151, 49);
			this.UnitTypeComboBox.Name = "UnitTypeComboBox";
			this.UnitTypeComboBox.Size = new System.Drawing.Size(100, 21);
			this.UnitTypeComboBox.TabIndex = 3;
			this.UnitTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.Unit_ValueChanged);
			// 
			// UnlockDurationUpDown
			// 
			this.UnlockDurationUpDown.Location = new System.Drawing.Point(70, 50);
			this.UnlockDurationUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.UnlockDurationUpDown.Name = "UnlockDurationUpDown";
			this.UnlockDurationUpDown.Size = new System.Drawing.Size(75, 20);
			this.UnlockDurationUpDown.TabIndex = 2;
			this.UnlockDurationUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.UnlockDurationUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.UnlockDurationUpDown.ValueChanged += new System.EventHandler(this.Unit_ValueChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(28, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Key:";
			// 
			// UnlockKeyTextBox
			// 
			this.UnlockKeyTextBox.Location = new System.Drawing.Point(68, 19);
			this.UnlockKeyTextBox.Name = "UnlockKeyTextBox";
			this.UnlockKeyTextBox.Size = new System.Drawing.Size(75, 20);
			this.UnlockKeyTextBox.TabIndex = 0;
			this.UnlockKeyTextBox.TextChanged += new System.EventHandler(this.UnlockKeyTextBox_TextChanged);
			// 
			// SecurityTokenTextBox
			// 
			this.SecurityTokenTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SecurityTokenTextBox.Location = new System.Drawing.Point(53, 45);
			this.SecurityTokenTextBox.Name = "SecurityTokenTextBox";
			this.SecurityTokenTextBox.Size = new System.Drawing.Size(302, 20);
			this.SecurityTokenTextBox.TabIndex = 4;
			this.SecurityTokenTextBox.TextChanged += new System.EventHandler(this.SecurityTokenTextBox_TextChanged);
			// 
			// RegenerateButton
			// 
			this.RegenerateButton.Location = new System.Drawing.Point(289, 250);
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
			this.UnlockTokenCheckTextBox.Location = new System.Drawing.Point(280, 19);
			this.UnlockTokenCheckTextBox.Name = "UnlockTokenCheckTextBox";
			this.UnlockTokenCheckTextBox.ReadOnly = true;
			this.UnlockTokenCheckTextBox.Size = new System.Drawing.Size(75, 20);
			this.UnlockTokenCheckTextBox.TabIndex = 4;
			// 
			// SecurityTokenCheckTextBox
			// 
			this.SecurityTokenCheckTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.SecurityTokenCheckTextBox.Location = new System.Drawing.Point(280, 19);
			this.SecurityTokenCheckTextBox.Name = "SecurityTokenCheckTextBox";
			this.SecurityTokenCheckTextBox.ReadOnly = true;
			this.SecurityTokenCheckTextBox.Size = new System.Drawing.Size(75, 20);
			this.SecurityTokenCheckTextBox.TabIndex = 4;
			// 
			// TokenStartDateTimePicker
			// 
			this.TokenStartDateTimePicker.CustomFormat = " yyyy-MM-hh mm:HH:ss";
			this.TokenStartDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.TokenStartDateTimePicker.Location = new System.Drawing.Point(70, 23);
			this.TokenStartDateTimePicker.Name = "TokenStartDateTimePicker";
			this.TokenStartDateTimePicker.Size = new System.Drawing.Size(142, 20);
			this.TokenStartDateTimePicker.TabIndex = 7;
			this.TokenStartDateTimePicker.ValueChanged += new System.EventHandler(this.Unit_ValueChanged);
			// 
			// DurationGroupBox
			// 
			this.DurationGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.DurationGroupBox.Controls.Add(this.NowLinkLabel);
			this.DurationGroupBox.Controls.Add(this.label4);
			this.DurationGroupBox.Controls.Add(this.label3);
			this.DurationGroupBox.Controls.Add(this.UnitTypeComboBox);
			this.DurationGroupBox.Controls.Add(this.TokenStartDateTimePicker);
			this.DurationGroupBox.Controls.Add(this.UnlockDurationUpDown);
			this.DurationGroupBox.Controls.Add(this.UnitValueHexTextBox);
			this.DurationGroupBox.Controls.Add(this.UnitValueTextBox);
			this.DurationGroupBox.Location = new System.Drawing.Point(3, 3);
			this.DurationGroupBox.Name = "DurationGroupBox";
			this.DurationGroupBox.Size = new System.Drawing.Size(743, 79);
			this.DurationGroupBox.TabIndex = 8;
			this.DurationGroupBox.TabStop = false;
			this.DurationGroupBox.Text = "Token Duration";
			// 
			// NowLinkLabel
			// 
			this.NowLinkLabel.AutoSize = true;
			this.NowLinkLabel.Location = new System.Drawing.Point(218, 25);
			this.NowLinkLabel.Name = "NowLinkLabel";
			this.NowLinkLabel.Size = new System.Drawing.Size(41, 13);
			this.NowLinkLabel.TabIndex = 10;
			this.NowLinkLabel.TabStop = true;
			this.NowLinkLabel.Text = "<- Now";
			this.NowLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.NowLinkLabel_LinkClicked);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 52);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(51, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Valid For:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 25);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(58, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "Start Date:";
			// 
			// UnitValueHexTextBox
			// 
			this.UnitValueHexTextBox.Location = new System.Drawing.Point(367, 49);
			this.UnitValueHexTextBox.Name = "UnitValueHexTextBox";
			this.UnitValueHexTextBox.ReadOnly = true;
			this.UnitValueHexTextBox.Size = new System.Drawing.Size(104, 20);
			this.UnitValueHexTextBox.TabIndex = 4;
			// 
			// UnitValueTextBox
			// 
			this.UnitValueTextBox.Location = new System.Drawing.Point(257, 49);
			this.UnitValueTextBox.Name = "UnitValueTextBox";
			this.UnitValueTextBox.ReadOnly = true;
			this.UnitValueTextBox.Size = new System.Drawing.Size(104, 20);
			this.UnitValueTextBox.TabIndex = 4;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.Param1ComboBox);
			this.groupBox1.Controls.Add(this.Param2Label);
			this.groupBox1.Controls.Add(this.Param1Label);
			this.groupBox1.Controls.Add(this.Param2TextBox);
			this.groupBox1.Location = new System.Drawing.Point(3, 169);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(361, 75);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Token Data";
			// 
			// Param1ComboBox
			// 
			this.Param1ComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Param1ComboBox.FormattingEnabled = true;
			this.Param1ComboBox.Items.AddRange(new object[] {
            "Param 1",
            "154",
            "72769AB4-BAA3-450B-AC77-1379602263FC"});
			this.Param1ComboBox.Location = new System.Drawing.Point(68, 19);
			this.Param1ComboBox.Name = "Param1ComboBox";
			this.Param1ComboBox.Size = new System.Drawing.Size(287, 21);
			this.Param1ComboBox.TabIndex = 9;
			this.Param1ComboBox.Text = "Param 123 ABC";
			// 
			// Param2Label
			// 
			this.Param2Label.AutoSize = true;
			this.Param2Label.Location = new System.Drawing.Point(6, 49);
			this.Param2Label.Name = "Param2Label";
			this.Param2Label.Size = new System.Drawing.Size(49, 13);
			this.Param2Label.TabIndex = 1;
			this.Param2Label.Text = "Param 2:";
			// 
			// Param1Label
			// 
			this.Param1Label.AutoSize = true;
			this.Param1Label.Location = new System.Drawing.Point(6, 22);
			this.Param1Label.Name = "Param1Label";
			this.Param1Label.Size = new System.Drawing.Size(49, 13);
			this.Param1Label.TabIndex = 1;
			this.Param1Label.Text = "Param 1:";
			// 
			// LogTextBox
			// 
			this.LogTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.LogTextBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LogTextBox.Location = new System.Drawing.Point(0, 331);
			this.LogTextBox.Multiline = true;
			this.LogTextBox.Name = "LogTextBox";
			this.LogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.LogTextBox.Size = new System.Drawing.Size(746, 103);
			this.LogTextBox.TabIndex = 0;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.HashKeyLabel);
			this.groupBox2.Controls.Add(this.SecretComboBox);
			this.groupBox2.Controls.Add(this.ValueLabel);
			this.groupBox2.Controls.Add(this.HashKeyTextBox);
			this.groupBox2.Location = new System.Drawing.Point(3, 88);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(361, 75);
			this.groupBox2.TabIndex = 8;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Token Secret";
			// 
			// HashKeyLabel
			// 
			this.HashKeyLabel.AutoSize = true;
			this.HashKeyLabel.Location = new System.Drawing.Point(6, 22);
			this.HashKeyLabel.Name = "HashKeyLabel";
			this.HashKeyLabel.Size = new System.Drawing.Size(56, 13);
			this.HashKeyLabel.TabIndex = 1;
			this.HashKeyLabel.Text = "Hash Key:";
			// 
			// SecretComboBox
			// 
			this.SecretComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SecretComboBox.FormattingEnabled = true;
			this.SecretComboBox.Items.AddRange(new object[] {
            "password",
            "5635E2CE-9493-4834-B3C9-19C522B83A40"});
			this.SecretComboBox.Location = new System.Drawing.Point(68, 45);
			this.SecretComboBox.Name = "SecretComboBox";
			this.SecretComboBox.Size = new System.Drawing.Size(287, 21);
			this.SecretComboBox.TabIndex = 9;
			this.SecretComboBox.Text = "password";
			// 
			// ValueLabel
			// 
			this.ValueLabel.AutoSize = true;
			this.ValueLabel.Location = new System.Drawing.Point(6, 48);
			this.ValueLabel.Name = "ValueLabel";
			this.ValueLabel.Size = new System.Drawing.Size(37, 13);
			this.ValueLabel.TabIndex = 1;
			this.ValueLabel.Text = "Value:";
			// 
			// HashKeyTextBox
			// 
			this.HashKeyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.HashKeyTextBox.Location = new System.Drawing.Point(68, 19);
			this.HashKeyTextBox.Name = "HashKeyTextBox";
			this.HashKeyTextBox.ReadOnly = true;
			this.HashKeyTextBox.Size = new System.Drawing.Size(287, 20);
			this.HashKeyTextBox.TabIndex = 4;
			// 
			// SecurtyTokenDataTextBox
			// 
			this.SecurtyTokenDataTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SecurtyTokenDataTextBox.Location = new System.Drawing.Point(6, 71);
			this.SecurtyTokenDataTextBox.Multiline = true;
			this.SecurtyTokenDataTextBox.Name = "SecurtyTokenDataTextBox";
			this.SecurtyTokenDataTextBox.ReadOnly = true;
			this.SecurtyTokenDataTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.SecurtyTokenDataTextBox.Size = new System.Drawing.Size(349, 78);
			this.SecurtyTokenDataTextBox.TabIndex = 0;
			// 
			// CheckSecurityTokenButton
			// 
			this.CheckSecurityTokenButton.Location = new System.Drawing.Point(289, 279);
			this.CheckSecurityTokenButton.Name = "CheckSecurityTokenButton";
			this.CheckSecurityTokenButton.Size = new System.Drawing.Size(75, 23);
			this.CheckSecurityTokenButton.TabIndex = 6;
			this.CheckSecurityTokenButton.Text = "Check";
			this.CheckSecurityTokenButton.UseVisualStyleBackColor = true;
			this.CheckSecurityTokenButton.Click += new System.EventHandler(this.CheckSecurityTokenButton_Click);
			// 
			// UnlockTokenGroupBox
			// 
			this.UnlockTokenGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.UnlockTokenGroupBox.Controls.Add(this.UnlockKeyTextBox);
			this.UnlockTokenGroupBox.Controls.Add(this.label1);
			this.UnlockTokenGroupBox.Controls.Add(this.UnlockTokenLabel);
			this.UnlockTokenGroupBox.Controls.Add(this.UnlockTokenTextBox);
			this.UnlockTokenGroupBox.Controls.Add(this.UnlockTokenCheckTextBox);
			this.UnlockTokenGroupBox.Location = new System.Drawing.Point(370, 250);
			this.UnlockTokenGroupBox.Name = "UnlockTokenGroupBox";
			this.UnlockTokenGroupBox.Size = new System.Drawing.Size(361, 75);
			this.UnlockTokenGroupBox.TabIndex = 8;
			this.UnlockTokenGroupBox.TabStop = false;
			this.UnlockTokenGroupBox.Text = "Results - Unlock Token";
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.SecurtyTokenDataTextBox);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.SecurityTokenCheckTextBox);
			this.groupBox3.Controls.Add(this.SecurityTokenTextBox);
			this.groupBox3.Location = new System.Drawing.Point(370, 89);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(361, 155);
			this.groupBox3.TabIndex = 8;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Results - Security Token";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(28, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Key:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 48);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(41, 13);
			this.label5.TabIndex = 5;
			this.label5.Text = "Token:";
			// 
			// Param2TextBox
			// 
			this.Param2TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Param2TextBox.Location = new System.Drawing.Point(68, 46);
			this.Param2TextBox.Name = "Param2TextBox";
			this.Param2TextBox.ReadOnly = true;
			this.Param2TextBox.Size = new System.Drawing.Size(287, 20);
			this.Param2TextBox.TabIndex = 4;
			// 
			// TokenControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.UnlockTokenGroupBox);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.DurationGroupBox);
			this.Controls.Add(this.CheckSecurityTokenButton);
			this.Controls.Add(this.RegenerateButton);
			this.Controls.Add(this.LogTextBox);
			this.Name = "TokenControl";
			this.Size = new System.Drawing.Size(749, 437);
			this.Load += new System.EventHandler(this.TokenControl_Load);
			((System.ComponentModel.ISupportInitialize)(this.UnlockDurationUpDown)).EndInit();
			this.DurationGroupBox.ResumeLayout(false);
			this.DurationGroupBox.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.UnlockTokenGroupBox.ResumeLayout(false);
			this.UnlockTokenGroupBox.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox UnlockKeyTextBox;
		private System.Windows.Forms.ComboBox UnitTypeComboBox;
		private System.Windows.Forms.NumericUpDown UnlockDurationUpDown;
		private System.Windows.Forms.Label UnlockTokenLabel;
		private System.Windows.Forms.TextBox UnlockTokenTextBox;
		private System.Windows.Forms.TextBox SecurityTokenTextBox;
		private System.Windows.Forms.Button RegenerateButton;
		private System.Windows.Forms.TextBox UnlockTokenCheckTextBox;
		private System.Windows.Forms.TextBox SecurityTokenCheckTextBox;
		private System.Windows.Forms.DateTimePicker TokenStartDateTimePicker;
		private System.Windows.Forms.GroupBox DurationGroupBox;
		private System.Windows.Forms.LinkLabel NowLinkLabel;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label Param2Label;
		private System.Windows.Forms.Label Param1Label;
		private System.Windows.Forms.TextBox LogTextBox;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label ValueLabel;
		private System.Windows.Forms.TextBox UnitValueTextBox;
		private System.Windows.Forms.ComboBox Param1ComboBox;
		private System.Windows.Forms.ComboBox SecretComboBox;
		private System.Windows.Forms.Label HashKeyLabel;
		private System.Windows.Forms.TextBox HashKeyTextBox;
		private System.Windows.Forms.TextBox UnitValueHexTextBox;
		private System.Windows.Forms.TextBox SecurtyTokenDataTextBox;
		private System.Windows.Forms.Button CheckSecurityTokenButton;
		private System.Windows.Forms.GroupBox UnlockTokenGroupBox;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox Param2TextBox;
	}
}
