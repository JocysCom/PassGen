using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JocysCom.ClassLibrary.Security.Password;
using JocysCom.ClassLibrary.Security.Password.Templates;
using System.Text.RegularExpressions;

namespace JocysCom.PassMan.PassGen
{

	public partial class MainForm
	{

		List<ToolStripMenuItem> presetItems;


		private void ConfigureMenuItems()
		{
			presetItems = new List<ToolStripMenuItem>();
			presetItems.Add(Preset1ToolStripMenuItem);
			presetItems.Add(Preset2ToolStripMenuItem);
			presetItems.Add(Preset3ToolStripMenuItem);
			for (int i = 0; i < presetItems.Count(); i++)
			{
				addNumberItems(presetItems[i], true);
				presetItems[i].Click += new EventHandler(presetItems_Click);
			}

		}

		void presetItems_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem s = (ToolStripMenuItem)sender;
			for (int i = 0; i < presetItems.Count(); i++)
			{
				presetItems[i].Checked = presetItems[i] == s;
			}
		}

		private void addNumberItems(ToolStripMenuItem s, bool addSubchildren)
		{
			ToolStripMenuItem item;
			((ToolStripDropDownMenu)s.DropDown).ShowImageMargin = false;
			if (s.DropDownItems.Count == 0)
			{
				Regex rx = new Regex("^[0-9]+$");
				int start = rx.IsMatch(s.Text) ? 0 : 1;
				for (int i = start; i < 10; i++)
				{
					item = new ToolStripMenuItem(string.Format("{0}{1}", rx.IsMatch(s.Text) ? s.Text : "", i));
					item.DisplayStyle = ToolStripItemDisplayStyle.Text;
					item.Padding = new Padding(0);
					item.Margin = new Padding(0);
					item.DropDownOpening += new EventHandler(ToolStripMenuItem_DropDownOpening);
					item.Click += new EventHandler(ToolStripMenuItem_Click);
					s.DropDownItems.Add(item);
				}
			}
			// Check sub-children.
			if (addSubchildren)
			{
				for (int i = 0; i < s.DropDownItems.Count; i++)
				{
					addNumberItems((ToolStripMenuItem)s.DropDownItems[i], false);
				}
			}
		}

		void ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem item = (ToolStripMenuItem)sender;
			int count = 0;
			bool isNumber = int.TryParse(item.Text, out count);
			if (isNumber && count > 0)
			{
				Generator passGen = new Generator();
				ToolStripItem owner = item.OwnerItem;
				while (!owner.Name.StartsWith("Preset")) owner = owner.OwnerItem;
				switch (owner.Text)
				{
					case "Easy": passGen.Preset = new Preset(PresetName.DefaultEasyToRemember); break;
					case "Hard": passGen.Preset = new Preset(PresetName.DefaultGood); break;
					case "Guid": passGen.Preset = new Preset(PresetName.GuidDefault); break;
					default: passGen.Preset = new Preset(PresetName.DefaultEasyToRemember); break;
				}
				string separator = Regex.Unescape(GeneratorPanel.ListSeparatorComboBox.Text);
				string list = passGen.NewPasswordList(count, separator);
				if (list.Length > 0) Clipboard.SetText(list);
				NotifyIconContextMenuStrip.Close();
			}

		}

		private void ToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
		{
			ToolStripMenuItem s = (ToolStripMenuItem)sender;
			addNumberItems(s, true);
		}

	}
}
