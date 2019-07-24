using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JocysCom.ClassLibrary.Security.Password;
using JocysCom.ClassLibrary.Security.Password.Templates;
using System.Text.RegularExpressions;

namespace JocysCom.Password.Generator
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
				ToolStripItem owner = item.OwnerItem;
				while (!owner.Name.StartsWith("Preset"))
					owner = owner.OwnerItem;
				string favPresetName = null;
				if (owner.Text == Properties.Settings.Default.FavPreset1TextBox)
				{
					favPresetName = Properties.Settings.Default.FavPreset1ComboBox;
				}
				else if (owner.Text == Properties.Settings.Default.FavPreset2TextBox)
				{
					favPresetName = Properties.Settings.Default.FavPreset2ComboBox;
				}
				else if (owner.Text == Properties.Settings.Default.FavPreset3TextBox)
				{
					favPresetName = Properties.Settings.Default.FavPreset3ComboBox;
				}
				var preset = GeneratorPanel.Presets.FirstOrDefault(x => x.PresetName == favPresetName);
				var passGen = new JocysCom.ClassLibrary.Security.Password.Generator();
				passGen.Preset = (preset == null)
					? new Preset(PresetName.DefaultEasyToRemember)
					: new Preset(preset.PresetTemplate);
				string separator = Regex.Unescape(GeneratorPanel.ListSeparatorComboBox.Text);
				string list = passGen.NewPasswordList(count, separator);
				if (list.Length > 0)
				{
					ClipboardHelper.SetClipboardText(list);
				}
				TrayNotifyIconContextMenuStrip.Close();
			}

		}

		private void ToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
		{
			var s = (ToolStripMenuItem)sender;
			addNumberItems(s, true);
		}

	}
}
