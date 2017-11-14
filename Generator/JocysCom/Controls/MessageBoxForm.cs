﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JocysCom.ClassLibrary.Controls
{
	public partial class MessageBoxForm : Form
	{
		public MessageBoxForm()
		{
			InitializeComponent();
		}

		public bool PlaySounds { get; set; }
		int h;
		int w;

		/// <summary>Displays a message box with the specified text, caption, buttons, icon, and default button.</summary>
		/// <param name="text">The text to display in the message box.</param>
		/// <param name="caption">The text to display in the title bar of the message box.</param>
		/// <param name="buttons">One of the <see cref="T:System.Windows.Forms.MessageBoxButtons" /> values that specifies which buttons to display in the message box.</param>
		/// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box.</param>
		/// <param name="defaultButton">One of the <see cref="T:System.Windows.Forms.MessageBoxDefaultButton" /> values that specifies the default button for the message box.</param>
		/// <returns>One of the <see cref="T:System.Windows.Forms.DialogResult" /> values.</returns>
		public System.Windows.Forms.DialogResult ShowForm(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
		{
			return ShowForm(text, caption, buttons, icon, MessageBoxDefaultButton.Button1);
		}

		/// <summary>Displays a message box with the specified text, caption, buttons, icon, and default button.</summary>
		/// <param name="text">The text to display in the message box.</param>
		/// <param name="caption">The text to display in the title bar of the message box.</param>
		/// <param name="buttons">One of the <see cref="T:System.Windows.Forms.MessageBoxButtons" /> values that specifies which buttons to display in the message box.</param>
		/// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box.</param>
		/// <param name="defaultButton">One of the <see cref="T:System.Windows.Forms.MessageBoxDefaultButton" /> values that specifies the default button for the message box.</param>
		/// <returns>One of the <see cref="T:System.Windows.Forms.DialogResult" /> values.</returns>
		public System.Windows.Forms.DialogResult ShowForm(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
		{
			AddResizeEvents();
			TextLabel.Text = text;
			this.Text = caption;
			Button1.Visible = false;
			Button2.Visible = false;
			Button3.Visible = false;
			switch (buttons)
			{
				case MessageBoxButtons.AbortRetryIgnore:
					EnableButtons(DialogResult.Abort, DialogResult.Retry, DialogResult.Ignore);
					break;
				case MessageBoxButtons.OK:
					EnableButtons(DialogResult.OK);
					break;
				case MessageBoxButtons.OKCancel:
					EnableButtons(DialogResult.OK, DialogResult.Cancel);
					break;
				case MessageBoxButtons.RetryCancel:
					EnableButtons(DialogResult.Retry, DialogResult.Cancel);
					break;
				case MessageBoxButtons.YesNo:
					EnableButtons(DialogResult.Yes, DialogResult.No);
					break;
				case MessageBoxButtons.YesNoCancel:
					EnableButtons(DialogResult.Yes, DialogResult.No, DialogResult.Cancel);
					break;
			}
			Bitmap image = Helper.FindResource<Bitmap>("MessageBoxIcon_Information_32x32.png");
			switch (icon)
			{
				case MessageBoxIcon.None:
					if (PlaySounds) System.Media.SystemSounds.Beep.Play();
					break;
				case MessageBoxIcon.Error: // Same as 'Hand' and 'Stop'.
					image = Helper.FindResource<Bitmap>("MessageBoxIcon_Error_32x32.png");
					if (PlaySounds) System.Media.SystemSounds.Hand.Play();
					break;
				case MessageBoxIcon.Question:
					image = Helper.FindResource<Bitmap>("MessageBoxIcon_Question_32x32.png");
					if (PlaySounds) System.Media.SystemSounds.Question.Play();
					break;
				case MessageBoxIcon.Warning: // Same as 'Exclamation'.
					image = Helper.FindResource<Bitmap>("MessageBoxIcon_Warning_32x32.png");
					if (PlaySounds) System.Media.SystemSounds.Exclamation.Play();
					break;
				case MessageBoxIcon.Information: // Same as 'Asterisk'.
					if (PlaySounds) System.Media.SystemSounds.Asterisk.Play();
					break;
			}
			IconPictureBox.Image = image;
			switch (defaultButton)
			{
				case MessageBoxDefaultButton.Button1:
					ActiveControl = Button1;
					break;
				case MessageBoxDefaultButton.Button2:
					ActiveControl = Button2;
					break;
				case MessageBoxDefaultButton.Button3:
					ActiveControl = Button3;
					break;
			}
			return ShowDialog();
		}

		/// <summary>Displays a message box with the specified text, caption, buttons, icon, and default button.</summary>
		/// <param name="text">The text to display in the message box.</param>
		/// <param name="caption">The text to display in the title bar of the message box.</param>
		/// <param name="buttons">One of the <see cref="T:System.Windows.Forms.MessageBoxButtons" /> values that specifies which buttons to display in the message box.</param>
		/// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box.</param>
		/// <param name="defaultButton">One of the <see cref="T:System.Windows.Forms.MessageBoxDefaultButton" /> values that specifies the default button for the message box.</param>
		/// <returns>One of the <see cref="T:System.Windows.Forms.DialogResult" /> values.</returns>
		public static System.Windows.Forms.DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
		{
			MessageBoxForm form = new MessageBoxForm();
			form.StartPosition = FormStartPosition.CenterScreen;
			return form.ShowForm(text, caption, buttons, icon);
		}

		/// <summary>Displays a message box with the specified text, caption, buttons, icon, and default button.</summary>
		/// <param name="text">The text to display in the message box.</param>
		/// <param name="caption">The text to display in the title bar of the message box.</param>
		/// <param name="buttons">One of the <see cref="T:System.Windows.Forms.MessageBoxButtons" /> values that specifies which buttons to display in the message box.</param>
		/// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box.</param>
		/// <param name="defaultButton">One of the <see cref="T:System.Windows.Forms.MessageBoxDefaultButton" /> values that specifies the default button for the message box.</param>
		/// <returns>One of the <see cref="T:System.Windows.Forms.DialogResult" /> values.</returns>
		public static System.Windows.Forms.DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
		{
			MessageBoxForm form = new MessageBoxForm();
			form.StartPosition = FormStartPosition.CenterScreen;
			return form.ShowForm(text, caption, buttons, icon, defaultButton);
		}

		public void AddResizeEvents()
		{
			h = this.Height - TextLabel.Height;
			w = this.Width - TextLabel.Width;
			TextLabel.AutoSize = true;
			this.TextLabel.Resize += Message_Resize;
		}

		public void EnableButton(ref Button button, DialogResult r1)
		{
			button.Text = "&" + r1.ToString();
			button.DialogResult = r1;
			button.Visible = true;
			button.Click += Button_Click;
		}

		public void EnableButtons(DialogResult r1)
		{
			EnableButton(ref Button1, r1);
			AcceptButton = Button1;
			CancelButton = Button1;
			Button1.Location = Button3.Location;
		}

		public void EnableButtons(DialogResult r1, DialogResult r2)
		{
			EnableButton(ref Button1, r1);
			EnableButton(ref Button2, r2);
			AcceptButton = Button1;
			CancelButton = Button2;
			Button1.Location = Button2.Location;
			Button2.Location = Button3.Location;
		}

		public void EnableButtons(DialogResult r1, DialogResult r2, DialogResult r3)
		{
			EnableButton(ref Button1, r1);
			EnableButton(ref Button2, r2);
			EnableButton(ref Button3, r3);
			AcceptButton = Button1;
			CancelButton = Button3;
		}

		void Button_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			this.DialogResult = button.DialogResult;
		}

		void Form_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.Control & e.KeyCode == Keys.C)
			{
				Clipboard.SetDataObject(this.TextLabel.Text);
				e.Handled = true;
				return;
			}
			else if (e.KeyCode == Keys.Escape)
			{
				this.DialogResult = this.CancelButton.DialogResult;
			}
			else if (e.KeyCode == Keys.Enter)
			{
				this.DialogResult = this.AcceptButton.DialogResult;
			}
		}

		void Message_Resize(System.Object sender, System.EventArgs e)
		{
			this.Height = Math.Max(h + TextLabel.Height, this.MinimumSize.Height);
			this.Width = Math.Max(w + TextLabel.Width, this.MinimumSize.Width);
			if (TextLabel.Width + 1 >= TextLabel.MaximumSize.Width && TextLabel.Height + 1 >= TextLabel.MaximumSize.Height)
			{
				textBox1.Text = TextLabel.Text;
				textBox1.Size = TextLabel.Size;
				textBox1.Top = TextLabel.Top;
				textBox1.Left = TextLabel.Left;
			}
			else
			{
				textBox1.Text = "";
				textBox1.Visible = false;
			}
		}

		void MessageBoxForm_Load(System.Object sender, System.EventArgs e)
		{
			ActiveControl.Select();
		}

		void copyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(TextLabel.Text);
		}

		void MainLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			OpenUrl(MainLinkLabel.Text);
		}

		public static void OpenUrl(string url)
		{
			try
			{
				System.Diagnostics.Process.Start(url);
			}
			catch (System.ComponentModel.Win32Exception noBrowser)
			{
				if (noBrowser.ErrorCode == -2147467259)
					MessageBox.Show(noBrowser.Message);
			}
			catch (System.Exception other)
			{
				MessageBox.Show(other.Message);
			}
		}

	}
}
