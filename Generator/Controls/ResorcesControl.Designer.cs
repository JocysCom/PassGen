namespace JocysCom.Password.Generator.Controls
{
	partial class ResorcesControl
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
			this.AdjectivesTextBox = new System.Windows.Forms.TextBox();
			this.AdjectivesLabel = new System.Windows.Forms.Label();
			this.DataSourceGroupBox = new System.Windows.Forms.GroupBox();
			this.FrequencyTextBox = new System.Windows.Forms.TextBox();
			this.FrequencyLabel = new System.Windows.Forms.Label();
			this.AdverbsTextBox = new System.Windows.Forms.TextBox();
			this.AdverbsLabel = new System.Windows.Forms.Label();
			this.VerbsTextBox = new System.Windows.Forms.TextBox();
			this.VerbsLabel = new System.Windows.Forms.Label();
			this.NounsTextBox = new System.Windows.Forms.TextBox();
			this.NounsLabel = new System.Windows.Forms.Label();
			this.LoadDataButton = new System.Windows.Forms.Button();
			this.LoadDataGroupBox = new System.Windows.Forms.GroupBox();
			this.LimitToTopNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.LoadFrequencyTextBox = new System.Windows.Forms.TextBox();
			this.SaveFolderTextBox = new System.Windows.Forms.TextBox();
			this.LoadFrequencyLabel = new System.Windows.Forms.Label();
			this.SaveDataButton = new System.Windows.Forms.Button();
			this.LoadAdverbsLabel = new System.Windows.Forms.Label();
			this.LoadAdjectiveTextBox = new System.Windows.Forms.TextBox();
			this.SaveResultTextBox = new System.Windows.Forms.TextBox();
			this.LoadAdverbsTextBox = new System.Windows.Forms.TextBox();
			this.LoadVerbsLabel = new System.Windows.Forms.Label();
			this.LoadNounsTextBox = new System.Windows.Forms.TextBox();
			this.LoadVerbsTextBox = new System.Windows.Forms.TextBox();
			this.LoadNounsLabel = new System.Windows.Forms.Label();
			this.SaveDataFolderLabel = new System.Windows.Forms.Label();
			this.LimitToTopLabel = new System.Windows.Forms.Label();
			this.LoadAdjectivesLabel = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.PasswordTextBox = new System.Windows.Forms.TextBox();
			this.GenerateButton = new System.Windows.Forms.Button();
			this.DataSourceGroupBox.SuspendLayout();
			this.LoadDataGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.LimitToTopNumericUpDown)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// AdjectivesTextBox
			// 
			this.AdjectivesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.AdjectivesTextBox.Location = new System.Drawing.Point(71, 45);
			this.AdjectivesTextBox.Name = "AdjectivesTextBox";
			this.AdjectivesTextBox.Size = new System.Drawing.Size(518, 20);
			this.AdjectivesTextBox.TabIndex = 0;
			this.AdjectivesTextBox.Text = "..\\..\\Resources\\WordNet\\Data\\index.adj";
			// 
			// AdjectivesLabel
			// 
			this.AdjectivesLabel.AutoSize = true;
			this.AdjectivesLabel.Location = new System.Drawing.Point(6, 48);
			this.AdjectivesLabel.Name = "AdjectivesLabel";
			this.AdjectivesLabel.Size = new System.Drawing.Size(59, 13);
			this.AdjectivesLabel.TabIndex = 1;
			this.AdjectivesLabel.Text = "Adjectives:";
			// 
			// DataSourceGroupBox
			// 
			this.DataSourceGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.DataSourceGroupBox.Controls.Add(this.FrequencyTextBox);
			this.DataSourceGroupBox.Controls.Add(this.FrequencyLabel);
			this.DataSourceGroupBox.Controls.Add(this.AdverbsTextBox);
			this.DataSourceGroupBox.Controls.Add(this.AdverbsLabel);
			this.DataSourceGroupBox.Controls.Add(this.VerbsTextBox);
			this.DataSourceGroupBox.Controls.Add(this.VerbsLabel);
			this.DataSourceGroupBox.Controls.Add(this.NounsTextBox);
			this.DataSourceGroupBox.Controls.Add(this.NounsLabel);
			this.DataSourceGroupBox.Controls.Add(this.AdjectivesTextBox);
			this.DataSourceGroupBox.Controls.Add(this.AdjectivesLabel);
			this.DataSourceGroupBox.Location = new System.Drawing.Point(3, 3);
			this.DataSourceGroupBox.Name = "DataSourceGroupBox";
			this.DataSourceGroupBox.Size = new System.Drawing.Size(595, 153);
			this.DataSourceGroupBox.TabIndex = 2;
			this.DataSourceGroupBox.TabStop = false;
			this.DataSourceGroupBox.Text = "Step 1: Set Data Source";
			// 
			// FrequencyTextBox
			// 
			this.FrequencyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.FrequencyTextBox.Location = new System.Drawing.Point(71, 19);
			this.FrequencyTextBox.Name = "FrequencyTextBox";
			this.FrequencyTextBox.Size = new System.Drawing.Size(518, 20);
			this.FrequencyTextBox.TabIndex = 0;
			this.FrequencyTextBox.Text = "..\\..\\Resources\\FrequencyWords\\en_full.txt";
			// 
			// FrequencyLabel
			// 
			this.FrequencyLabel.AutoSize = true;
			this.FrequencyLabel.Location = new System.Drawing.Point(6, 22);
			this.FrequencyLabel.Name = "FrequencyLabel";
			this.FrequencyLabel.Size = new System.Drawing.Size(60, 13);
			this.FrequencyLabel.TabIndex = 1;
			this.FrequencyLabel.Text = "Frequency:";
			// 
			// AdverbsTextBox
			// 
			this.AdverbsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.AdverbsTextBox.Location = new System.Drawing.Point(71, 123);
			this.AdverbsTextBox.Name = "AdverbsTextBox";
			this.AdverbsTextBox.Size = new System.Drawing.Size(518, 20);
			this.AdverbsTextBox.TabIndex = 0;
			this.AdverbsTextBox.Text = "..\\..\\Resources\\WordNet\\Data\\index.adv";
			// 
			// AdverbsLabel
			// 
			this.AdverbsLabel.AutoSize = true;
			this.AdverbsLabel.Location = new System.Drawing.Point(6, 126);
			this.AdverbsLabel.Name = "AdverbsLabel";
			this.AdverbsLabel.Size = new System.Drawing.Size(49, 13);
			this.AdverbsLabel.TabIndex = 1;
			this.AdverbsLabel.Text = "Adverbs:";
			// 
			// VerbsTextBox
			// 
			this.VerbsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.VerbsTextBox.Location = new System.Drawing.Point(71, 97);
			this.VerbsTextBox.Name = "VerbsTextBox";
			this.VerbsTextBox.Size = new System.Drawing.Size(518, 20);
			this.VerbsTextBox.TabIndex = 0;
			this.VerbsTextBox.Text = "..\\..\\Resources\\WordNet\\Data\\index.verb";
			// 
			// VerbsLabel
			// 
			this.VerbsLabel.AutoSize = true;
			this.VerbsLabel.Location = new System.Drawing.Point(6, 100);
			this.VerbsLabel.Name = "VerbsLabel";
			this.VerbsLabel.Size = new System.Drawing.Size(37, 13);
			this.VerbsLabel.TabIndex = 1;
			this.VerbsLabel.Text = "Verbs:";
			// 
			// NounsTextBox
			// 
			this.NounsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.NounsTextBox.Location = new System.Drawing.Point(71, 71);
			this.NounsTextBox.Name = "NounsTextBox";
			this.NounsTextBox.Size = new System.Drawing.Size(518, 20);
			this.NounsTextBox.TabIndex = 0;
			this.NounsTextBox.Text = "..\\..\\Resources\\WordNet\\Data\\index.noun";
			// 
			// NounsLabel
			// 
			this.NounsLabel.AutoSize = true;
			this.NounsLabel.Location = new System.Drawing.Point(6, 74);
			this.NounsLabel.Name = "NounsLabel";
			this.NounsLabel.Size = new System.Drawing.Size(41, 13);
			this.NounsLabel.TabIndex = 1;
			this.NounsLabel.Text = "Nouns:";
			// 
			// LoadDataButton
			// 
			this.LoadDataButton.Location = new System.Drawing.Point(100, 37);
			this.LoadDataButton.Name = "LoadDataButton";
			this.LoadDataButton.Size = new System.Drawing.Size(75, 23);
			this.LoadDataButton.TabIndex = 3;
			this.LoadDataButton.Text = "Load Data";
			this.LoadDataButton.UseVisualStyleBackColor = true;
			this.LoadDataButton.Click += new System.EventHandler(this.LoadDataButton_Click);
			// 
			// LoadDataGroupBox
			// 
			this.LoadDataGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.LoadDataGroupBox.Controls.Add(this.LimitToTopNumericUpDown);
			this.LoadDataGroupBox.Controls.Add(this.LoadFrequencyTextBox);
			this.LoadDataGroupBox.Controls.Add(this.SaveFolderTextBox);
			this.LoadDataGroupBox.Controls.Add(this.LoadFrequencyLabel);
			this.LoadDataGroupBox.Controls.Add(this.SaveDataButton);
			this.LoadDataGroupBox.Controls.Add(this.LoadDataButton);
			this.LoadDataGroupBox.Controls.Add(this.LoadAdverbsLabel);
			this.LoadDataGroupBox.Controls.Add(this.LoadAdjectiveTextBox);
			this.LoadDataGroupBox.Controls.Add(this.SaveResultTextBox);
			this.LoadDataGroupBox.Controls.Add(this.LoadAdverbsTextBox);
			this.LoadDataGroupBox.Controls.Add(this.LoadVerbsLabel);
			this.LoadDataGroupBox.Controls.Add(this.LoadNounsTextBox);
			this.LoadDataGroupBox.Controls.Add(this.LoadVerbsTextBox);
			this.LoadDataGroupBox.Controls.Add(this.LoadNounsLabel);
			this.LoadDataGroupBox.Controls.Add(this.SaveDataFolderLabel);
			this.LoadDataGroupBox.Controls.Add(this.LimitToTopLabel);
			this.LoadDataGroupBox.Controls.Add(this.LoadAdjectivesLabel);
			this.LoadDataGroupBox.Location = new System.Drawing.Point(3, 162);
			this.LoadDataGroupBox.Name = "LoadDataGroupBox";
			this.LoadDataGroupBox.Size = new System.Drawing.Size(595, 154);
			this.LoadDataGroupBox.TabIndex = 4;
			this.LoadDataGroupBox.TabStop = false;
			this.LoadDataGroupBox.Text = "Step 2: Load Data";
			// 
			// LimitToTopNumericUpDown
			// 
			this.LimitToTopNumericUpDown.Location = new System.Drawing.Point(6, 38);
			this.LimitToTopNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.LimitToTopNumericUpDown.Name = "LimitToTopNumericUpDown";
			this.LimitToTopNumericUpDown.Size = new System.Drawing.Size(88, 20);
			this.LimitToTopNumericUpDown.TabIndex = 4;
			this.LimitToTopNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.LimitToTopNumericUpDown.Value = new decimal(new int[] {
            30000,
            0,
            0,
            0});
			// 
			// LoadFrequencyTextBox
			// 
			this.LoadFrequencyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.LoadFrequencyTextBox.Location = new System.Drawing.Point(489, 19);
			this.LoadFrequencyTextBox.Name = "LoadFrequencyTextBox";
			this.LoadFrequencyTextBox.ReadOnly = true;
			this.LoadFrequencyTextBox.Size = new System.Drawing.Size(100, 20);
			this.LoadFrequencyTextBox.TabIndex = 0;
			this.LoadFrequencyTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// SaveFolderTextBox
			// 
			this.SaveFolderTextBox.Location = new System.Drawing.Point(6, 77);
			this.SaveFolderTextBox.Name = "SaveFolderTextBox";
			this.SaveFolderTextBox.Size = new System.Drawing.Size(169, 20);
			this.SaveFolderTextBox.TabIndex = 0;
			this.SaveFolderTextBox.Text = "..\\..\\Resources";
			// 
			// LoadFrequencyLabel
			// 
			this.LoadFrequencyLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.LoadFrequencyLabel.AutoSize = true;
			this.LoadFrequencyLabel.Location = new System.Drawing.Point(424, 22);
			this.LoadFrequencyLabel.Name = "LoadFrequencyLabel";
			this.LoadFrequencyLabel.Size = new System.Drawing.Size(60, 13);
			this.LoadFrequencyLabel.TabIndex = 1;
			this.LoadFrequencyLabel.Text = "Frequency:";
			// 
			// SaveDataButton
			// 
			this.SaveDataButton.Location = new System.Drawing.Point(181, 75);
			this.SaveDataButton.Name = "SaveDataButton";
			this.SaveDataButton.Size = new System.Drawing.Size(75, 23);
			this.SaveDataButton.TabIndex = 3;
			this.SaveDataButton.Text = "Save Data";
			this.SaveDataButton.UseVisualStyleBackColor = true;
			this.SaveDataButton.Click += new System.EventHandler(this.SaveDataButton_Click);
			// 
			// LoadAdverbsLabel
			// 
			this.LoadAdverbsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.LoadAdverbsLabel.AutoSize = true;
			this.LoadAdverbsLabel.Location = new System.Drawing.Point(424, 126);
			this.LoadAdverbsLabel.Name = "LoadAdverbsLabel";
			this.LoadAdverbsLabel.Size = new System.Drawing.Size(49, 13);
			this.LoadAdverbsLabel.TabIndex = 1;
			this.LoadAdverbsLabel.Text = "Adverbs:";
			// 
			// LoadAdjectiveTextBox
			// 
			this.LoadAdjectiveTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.LoadAdjectiveTextBox.Location = new System.Drawing.Point(489, 45);
			this.LoadAdjectiveTextBox.Name = "LoadAdjectiveTextBox";
			this.LoadAdjectiveTextBox.ReadOnly = true;
			this.LoadAdjectiveTextBox.Size = new System.Drawing.Size(100, 20);
			this.LoadAdjectiveTextBox.TabIndex = 0;
			this.LoadAdjectiveTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// SaveResultTextBox
			// 
			this.SaveResultTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.SaveResultTextBox.Location = new System.Drawing.Point(6, 103);
			this.SaveResultTextBox.Name = "SaveResultTextBox";
			this.SaveResultTextBox.ReadOnly = true;
			this.SaveResultTextBox.Size = new System.Drawing.Size(169, 20);
			this.SaveResultTextBox.TabIndex = 0;
			this.SaveResultTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// LoadAdverbsTextBox
			// 
			this.LoadAdverbsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.LoadAdverbsTextBox.Location = new System.Drawing.Point(489, 123);
			this.LoadAdverbsTextBox.Name = "LoadAdverbsTextBox";
			this.LoadAdverbsTextBox.ReadOnly = true;
			this.LoadAdverbsTextBox.Size = new System.Drawing.Size(100, 20);
			this.LoadAdverbsTextBox.TabIndex = 0;
			this.LoadAdverbsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// LoadVerbsLabel
			// 
			this.LoadVerbsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.LoadVerbsLabel.AutoSize = true;
			this.LoadVerbsLabel.Location = new System.Drawing.Point(424, 100);
			this.LoadVerbsLabel.Name = "LoadVerbsLabel";
			this.LoadVerbsLabel.Size = new System.Drawing.Size(37, 13);
			this.LoadVerbsLabel.TabIndex = 1;
			this.LoadVerbsLabel.Text = "Verbs:";
			// 
			// LoadNounsTextBox
			// 
			this.LoadNounsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.LoadNounsTextBox.Location = new System.Drawing.Point(489, 71);
			this.LoadNounsTextBox.Name = "LoadNounsTextBox";
			this.LoadNounsTextBox.ReadOnly = true;
			this.LoadNounsTextBox.Size = new System.Drawing.Size(100, 20);
			this.LoadNounsTextBox.TabIndex = 0;
			this.LoadNounsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// LoadVerbsTextBox
			// 
			this.LoadVerbsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.LoadVerbsTextBox.Location = new System.Drawing.Point(489, 97);
			this.LoadVerbsTextBox.Name = "LoadVerbsTextBox";
			this.LoadVerbsTextBox.ReadOnly = true;
			this.LoadVerbsTextBox.Size = new System.Drawing.Size(100, 20);
			this.LoadVerbsTextBox.TabIndex = 0;
			this.LoadVerbsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// LoadNounsLabel
			// 
			this.LoadNounsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.LoadNounsLabel.AutoSize = true;
			this.LoadNounsLabel.Location = new System.Drawing.Point(424, 74);
			this.LoadNounsLabel.Name = "LoadNounsLabel";
			this.LoadNounsLabel.Size = new System.Drawing.Size(41, 13);
			this.LoadNounsLabel.TabIndex = 1;
			this.LoadNounsLabel.Text = "Nouns:";
			// 
			// SaveDataFolderLabel
			// 
			this.SaveDataFolderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.SaveDataFolderLabel.AutoSize = true;
			this.SaveDataFolderLabel.Location = new System.Drawing.Point(6, 61);
			this.SaveDataFolderLabel.Name = "SaveDataFolderLabel";
			this.SaveDataFolderLabel.Size = new System.Drawing.Size(69, 13);
			this.SaveDataFolderLabel.TabIndex = 1;
			this.SaveDataFolderLabel.Text = "Limit To Top:";
			// 
			// LimitToTopLabel
			// 
			this.LimitToTopLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.LimitToTopLabel.AutoSize = true;
			this.LimitToTopLabel.Location = new System.Drawing.Point(6, 22);
			this.LimitToTopLabel.Name = "LimitToTopLabel";
			this.LimitToTopLabel.Size = new System.Drawing.Size(69, 13);
			this.LimitToTopLabel.TabIndex = 1;
			this.LimitToTopLabel.Text = "Limit To Top:";
			// 
			// LoadAdjectivesLabel
			// 
			this.LoadAdjectivesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.LoadAdjectivesLabel.AutoSize = true;
			this.LoadAdjectivesLabel.Location = new System.Drawing.Point(424, 48);
			this.LoadAdjectivesLabel.Name = "LoadAdjectivesLabel";
			this.LoadAdjectivesLabel.Size = new System.Drawing.Size(59, 13);
			this.LoadAdjectivesLabel.TabIndex = 1;
			this.LoadAdjectivesLabel.Text = "Adjectives:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.PasswordTextBox);
			this.groupBox1.Controls.Add(this.GenerateButton);
			this.groupBox1.Location = new System.Drawing.Point(3, 322);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(595, 100);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Generate";
			// 
			// PasswordTextBox
			// 
			this.PasswordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.PasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PasswordTextBox.Location = new System.Drawing.Point(87, 21);
			this.PasswordTextBox.Name = "PasswordTextBox";
			this.PasswordTextBox.ReadOnly = true;
			this.PasswordTextBox.Size = new System.Drawing.Size(502, 29);
			this.PasswordTextBox.TabIndex = 0;
			this.PasswordTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// GenerateButton
			// 
			this.GenerateButton.Location = new System.Drawing.Point(6, 19);
			this.GenerateButton.Name = "GenerateButton";
			this.GenerateButton.Size = new System.Drawing.Size(75, 23);
			this.GenerateButton.TabIndex = 3;
			this.GenerateButton.Text = "Generate";
			this.GenerateButton.UseVisualStyleBackColor = true;
			this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
			// 
			// ResorcesControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.LoadDataGroupBox);
			this.Controls.Add(this.DataSourceGroupBox);
			this.Name = "ResorcesControl";
			this.Size = new System.Drawing.Size(601, 453);
			this.DataSourceGroupBox.ResumeLayout(false);
			this.DataSourceGroupBox.PerformLayout();
			this.LoadDataGroupBox.ResumeLayout(false);
			this.LoadDataGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.LimitToTopNumericUpDown)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox AdjectivesTextBox;
		private System.Windows.Forms.Label AdjectivesLabel;
		private System.Windows.Forms.GroupBox DataSourceGroupBox;
		private System.Windows.Forms.TextBox FrequencyTextBox;
		private System.Windows.Forms.Label FrequencyLabel;
		private System.Windows.Forms.TextBox AdverbsTextBox;
		private System.Windows.Forms.Label AdverbsLabel;
		private System.Windows.Forms.TextBox VerbsTextBox;
		private System.Windows.Forms.Label VerbsLabel;
		private System.Windows.Forms.TextBox NounsTextBox;
		private System.Windows.Forms.Label NounsLabel;
		private System.Windows.Forms.Button LoadDataButton;
		private System.Windows.Forms.GroupBox LoadDataGroupBox;
		private System.Windows.Forms.TextBox LoadFrequencyTextBox;
		private System.Windows.Forms.TextBox LoadAdjectiveTextBox;
		private System.Windows.Forms.TextBox LoadAdverbsTextBox;
		private System.Windows.Forms.TextBox LoadNounsTextBox;
		private System.Windows.Forms.TextBox LoadVerbsTextBox;
		private System.Windows.Forms.Label LoadFrequencyLabel;
		private System.Windows.Forms.Label LoadAdverbsLabel;
		private System.Windows.Forms.Label LoadVerbsLabel;
		private System.Windows.Forms.Label LoadNounsLabel;
		private System.Windows.Forms.Label LoadAdjectivesLabel;
		private System.Windows.Forms.NumericUpDown LimitToTopNumericUpDown;
		private System.Windows.Forms.Label LimitToTopLabel;
		private System.Windows.Forms.TextBox SaveFolderTextBox;
		private System.Windows.Forms.Button SaveDataButton;
		private System.Windows.Forms.Label SaveDataFolderLabel;
		private System.Windows.Forms.TextBox SaveResultTextBox;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox PasswordTextBox;
		private System.Windows.Forms.Button GenerateButton;
	}
}
