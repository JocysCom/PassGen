namespace JocysCom.ClassLibrary.Controls
{
    partial class ScrollableUserControl
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
            if (disposing)
            {
                if (keyboardHook != null) keyboardHook.Dispose();
                if (mouseHook != null) mouseHook.Dispose();
                if (components != null) components.Dispose();
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
			this._BarPanel = new System.Windows.Forms.Panel();
			this._GripPanel = new System.Windows.Forms.Panel();
			this._ContainerPanel = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// _BarPanel
			// 
			this._BarPanel.BackColor = System.Drawing.SystemColors.ControlLight;
			this._BarPanel.Dock = System.Windows.Forms.DockStyle.Right;
			this._BarPanel.Location = new System.Drawing.Point(184, 0);
			this._BarPanel.Margin = new System.Windows.Forms.Padding(0);
			this._BarPanel.Name = "_BarPanel";
			this._BarPanel.Size = new System.Drawing.Size(16, 100);
			this._BarPanel.TabIndex = 0;
			// 
			// _GripPanel
			// 
			this._GripPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._GripPanel.BackColor = System.Drawing.SystemColors.ControlDark;
			this._GripPanel.Location = new System.Drawing.Point(184, 0);
			this._GripPanel.Margin = new System.Windows.Forms.Padding(0);
			this._GripPanel.Name = "_GripPanel";
			this._GripPanel.Size = new System.Drawing.Size(16, 28);
			this._GripPanel.TabIndex = 1;
			// 
			// _ContainerPanel
			// 
			this._ContainerPanel.AutoSize = true;
			this._ContainerPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._ContainerPanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this._ContainerPanel.Location = new System.Drawing.Point(0, 0);
			this._ContainerPanel.Margin = new System.Windows.Forms.Padding(0);
			this._ContainerPanel.MinimumSize = new System.Drawing.Size(50, 50);
			this._ContainerPanel.Name = "_ContainerPanel";
			this._ContainerPanel.Size = new System.Drawing.Size(50, 50);
			this._ContainerPanel.TabIndex = 2;
			this._ContainerPanel.SizeChanged += new System.EventHandler(this.ScrollableUserControl_SizeChanged);
			this._ContainerPanel.VisibleChanged += new System.EventHandler(this._ContainerPanel_VisibleChanged);
			this._ContainerPanel.Paint += new System.Windows.Forms.PaintEventHandler(this._ContainerPanel_Paint);
			this._ContainerPanel.Move += new System.EventHandler(this._ContainerPanel_Move);
			this._ContainerPanel.Resize += new System.EventHandler(this._ContainerPanel_Resize);
			// 
			// ScrollableUserControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._ContainerPanel);
			this.Controls.Add(this._GripPanel);
			this.Controls.Add(this._BarPanel);
			this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.Name = "ScrollableUserControl";
			this.Size = new System.Drawing.Size(200, 100);
			this.SizeChanged += new System.EventHandler(this.ScrollableUserControl_SizeChanged);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel _ContainerPanel;
        private System.Windows.Forms.Panel _BarPanel;
        private System.Windows.Forms.Panel _GripPanel;
    }
}
