using JocysCom.ClassLibrary.Security.Password;
using JocysCom.ClassLibrary.Security.Password.Templates;
using JocysCom.Password.Generator.Properties;
using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using JocysCom.ClassLibrary.Controls.DynamicCompile;

namespace JocysCom.Password.Generator.Controls
{
	public partial class GeneratorControl : UserControl
	{
		public GeneratorControl()
		{
			Settings.Default.SettingsLoaded += Default_SettingsLoaded;
			InitializeComponent();
			CallNamesDataGridView.AutoGenerateColumns = false;
		}

		private void Default_SettingsLoaded(object sender, System.Configuration.SettingsLoadedEventArgs e)
		{
		}

		BindingList<Call> Calls;
		object presetsLock = new object();

		private BindingList<Preset> _Presets;
		/// <summary>
		/// Make sure that function inside is not using any other user control or
		/// method execution will brake and will jump to another parts of code.
		/// This will lead to Preset empty list returned in other parts of code.
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public BindingList<Preset> Presets
		{
			get
			{
				lock (presetsLock)
				{
					if (_Presets == null)
					{
						// Load Presets
						_Presets = new BindingList<Preset>();
						PresetName[] presetEnums = (PresetName[])Enum.GetValues(typeof(PresetName));
						foreach (var presetEnum in presetEnums)
						{
							if (presetEnum == PresetName.Default) continue;
							Preset preset = new Preset(presetEnum);
							// Get name of preset.
							FileInfo fi = new FileInfo(GetPresetFileName(preset));
							// if preset exist then load it.
							if (fi.Exists) preset.Load(fi.FullName);

							if (preset.LoadException == null)
							{
								_Presets.Add(preset);
							}
							else
							{
								string message = string.Format(
									"Preset '{0}' failed to load. {1}",
									presetEnum, preset.LoadException.Message);
								//HelpTextBox.Text = message + HelpTextBox.Text;
								MessageBox.Show(this, message, Application.ProductName + " Warning!");
							}
						}
					}
					return _Presets;
				}
			}
			set
			{
				lock (presetsLock)
				{
					_Presets = value;
				}
			}
		}

		object defaultPresetLock = new object();
		Preset _DefaultPreset;
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		Preset DefaultPreset
		{
			get
			{
				lock (defaultPresetLock)
				{
					if (_DefaultPreset == null)
					{
						_DefaultPreset = new Preset(PresetName.Default);
						_DefaultPreset.SetDefaultChars();
					}
					return _DefaultPreset;
				}
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public Preset SelectedPreset
		{
			get
			{
				Preset p = null;
				lock (presetsLock)
				{
					if (Presets != null)
					{
						p = Presets.FirstOrDefault(x => x.PresetName == PresetNameComboBox.Text);
					}
				}
				return p;
			}
		}

		public void Initialize()
		{
			// Load Calls
			Calls = new BindingList<Call>();
			CallName[] callNames = (CallName[])Enum.GetValues(typeof(CallName));
			foreach (var callName in callNames)
			{
				Call call = new Call(CallName.EN_Unicode);
				call.Load(callName, true);
				Calls.Add(call);
			}
			CallNamesDataGridView.DataSource = Calls;
			// Load presets.
			//string[] names = mainForm.GeneratorPanel.Presets.Select(x => x.PresetName).ToArray();
			//PresetNameComboBox.Items.AddRange(names);
			// Load help.
			var count = HelpContent.Count();
			//JocysCom.ClassLibrary.Security.Password.Templates.Call c = new JocysCom.ClassLibrary.Security.Password.Templates.Call("Call Name");
			//c.SaveAs("demofile.js");
			//c.Load("demofile.js", true);
			this.ActiveControl = CallsTextBox;
			//ShowPanelTopCheckBox_CheckedChanged(null, null);
			//ShowPanelRightCheckBox_CheckedChanged(null, null);
			//ShowPanelLeftCheckBox_CheckedChanged(null, null);
		}


		Dictionary<Control, string> _HelpContent;
		object _HelpContentLock = new object();

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public Dictionary<Control, string> HelpContent
		{
			set
			{
				_HelpContent = null;
			}
			get
			{
				if (_HelpContent == null)
				{
					_HelpContent = new Dictionary<Control, string>();
					_HelpContent.Add(this, "Welcome to super flexible Password Generator!");
					_HelpContent.Add(PresetNameComboBox, "Select pre-configured password preset.");
					_HelpContent.Add(CallNamesDataGridView, "Select calls type. NATO calls are most popular calls to use if you want to pass your message through phone or radio.");
					_HelpContent.Add(RatioNumbersNumericUpDown, "Numeric relationship in quantity between other type of characters.");
					_HelpContent.Add(RatioUppercaseNumericUpDown, "Upper case relationship in quantity between other type of characters.");
					_HelpContent.Add(RatioLowercaseNumericUpDown, "Lower case relationship in quantity between other type of characters.");
					_HelpContent.Add(RatioSymbolsNumericUpDown, "Extended relationship in quantity between other type of characters.");
					_HelpContent.Add(RatioExtraNumericUpDown, "Extra relationship in quantity between other type of characters.");
					// Favourites.
					_HelpContent.Add(FavPreset1Button, "Your favourite preset: " + Settings.Default.FavPreset1ComboBox + ". You can configure it from options.");
					_HelpContent.Add(FavPreset2Button, "Your favourite preset: " + Settings.Default.FavPreset2ComboBox + ". You can configure it from options.");
					_HelpContent.Add(FavPreset3Button, "Your favourite preset: " + Settings.Default.FavPreset3ComboBox + ". You can configure it from options.");
					Preset preset = GetPresetFromForm();
					_HelpContent[UseUppercaseCheckBox] = "Use upper case letters inside password. Chars: " + preset.CharsUppercase;
					_HelpContent[UseLowercaseCheckBox] = "Use lower case letters inside password. Chars: " + preset.CharsLowercase;
					_HelpContent[UseNumbersCheckBox] = "Use numbers inside password. Chars: " + preset.CharsNumbers;
					_HelpContent[UseSymbolsCheckBox] = "Use extended characters inside password. Chars: " + preset.CharsSymbols;
					_HelpContent[UseExtraCheckBox] = "Use extra symbols inside password. Chars: " + preset.CharsExtra;
					_HelpContent.Add(CharsExtraTextBox, "Specify extra symbols to include inside password.");
					_HelpContent.Add(FilterRememberCheckBox, PassGen.Filters[FilterName.Remember].FilterName + ": " + PassGen.Filters[FilterName.Remember].FilterDescription);
					_HelpContent.Add(FilterKeyboardCheckBox, PassGen.Filters[FilterName.Keyboard].FilterName + ": " + PassGen.Filters[FilterName.Keyboard].FilterDescription);
					_HelpContent.Add(FilterPhoneCheckBox, PassGen.Filters[FilterName.Phone].FilterName + ": " + PassGen.Filters[FilterName.Phone].FilterDescription);
					_HelpContent.Add(FilterEnforceCheckBox, PassGen.Filters[FilterName.Enforce].FilterName + ": " + PassGen.Filters[FilterName.Enforce].FilterDescription);
					_HelpContent.Add(FilterAsciiCheckBox, PassGen.Filters[FilterName.Ascii].FilterName + ": " + PassGen.Filters[FilterName.Ascii].FilterDescription);
					_HelpContent.Add(FilterCharsCheckBox, PassGen.Filters[FilterName.Chars].FilterName + ": " + PassGen.Filters[FilterName.Chars].FilterDescription);
					_HelpContent.Add(FilterCharsStringTextBox, "Specify custom characters to remove from password.");
					_HelpContent.Add(RegexEnabledCheckBox, "Apply Regular Expression patterns on password.");
					_HelpContent.Add(RegexPatternFindTextBox, "Find pattern of Regular Expression.");
					_HelpContent.Add(RegexPatternReplaceTextBox, "Replace pattern of Regular Expression.");
					_HelpContent.Add(ScriptEnabledCheckBox, "Apply JavaScript code on password.");
					_HelpContent.Add(ListSizeNumericUpDown, "Specify how many passwords will be generated into List.");
					_HelpContent.Add(ListSeparatorComboBox, "Separate each List password with this separator. You can use backward slash for special characters: \\t - tab, \\r - return, \\n - new line...");
					//_HelpContent.Add(CopyOnLoadCheckBox, "Copy password to clipboard as soon as Password Generator window loads.");
					//_HelpContent.Add(CopyOnGenerateCheckBox, "Copy password to clipboard after [Generate] button was pressed.");
					//_HelpContent.Add(GenerateOnCopyCheckBox, "Regenerate passwords after one of the [Copy] buttons was clicked.");
					//list.Add(EnableDebug, "Show Trace Log window.");
					//list.Add(OK, "Update password field on parent window and close this window.");
					//list.Add(Apply, "Update password field on parent window.");
					//list.Add(Cancel, "Close this window.");
					_HelpContent.Add(Copy1Button, "Copy password 1 to clipboard.");
					_HelpContent.Add(Copy2Button, "Copy password 2 to clipboard.");
					_HelpContent.Add(Copy3Button, "Copy password 3 to clipboard.");
					_HelpContent.Add(Copy4Button, "Copy password 4 to clipboard.");
					_HelpContent.Add(GenerateButton, "Press to regenerate passwords.");
					_HelpContent.Add(ListButton, "Generate list of passwords and copy to clipboard.");
					_HelpContent.Add(CallsTextBox, "Convert any text or password into calls so you can easily pass them through radio or phone conversation. Clean the text field and press [Enter] in order to see full list of names.");
					_HelpContent.Add(PasswordStrengthTextBox, "Strength of the password. It represents N where 10^N is a number of all possible password variations required to check by brute-force algorithm in order to crack you password successfully.");
					_HelpContent.Add(CallTextLengthTextBox, "Password, string length.");
					_HelpContent.Add(OptionsPanel, null);
					foreach (var key in _HelpContent.Keys)
					{
						key.Enter += new EventHandler(c_Enter);
						key.MouseEnter += new EventHandler(c_Enter);
						key.Leave += new EventHandler(c_Leave);
						key.MouseLeave += new EventHandler(c_Leave);
					}
				}
				return _HelpContent;
			}
		}

		private Control HelpCurrentControl;

		private void HelpTimer_Tick(object sender, EventArgs e)
		{
			mainForm.ControlHelpBodyLabel.Text = HelpContent[HelpCurrentControl ?? this] ?? HelpContent[this];
		}

		void c_Leave(object sender, EventArgs e)
		{
			//HelpTextBox.Text = "Leave " + ((Control)sender).Name + "\r\n" + HelpTextBox.Text;
			//HelpCurrentControl = null;
			//HelpTimer.Stop();
			//HelpTimer.Start();
		}

		void c_Enter(object sender, EventArgs e)
		{
			//HelpTextBox.Text = "Enter " + ((Control)sender).Name + "\r\n" + HelpTextBox.Text;
			HelpCurrentControl = (Control)sender;
			HelpTimer.Stop();
			HelpTimer.Start();
		}

		private void CallsTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				ShowCalls(true);
				e.Handled = true;
			}
			else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
			{
				// Move selection on calls grip up or down.
				var selectedRows = CallsDataGridView.SelectedRows.Cast<DataGridViewRow>().OrderBy(x => x.Index).ToArray();
				if (selectedRows.Count() == 0)
					return;
				var step = e.KeyCode == Keys.Up ? -1 : 1;
				var selectedRow = e.KeyCode == Keys.Up ? selectedRows.First() : selectedRows.Last();
				var nextRow = GetNextPrev(CallsDataGridView.Rows.Cast<DataGridViewRow>().ToList(), selectedRow, step);
				if (nextRow != null)
				{
					if (!e.Control && !e.Shift)
					{
						for (int i = 0; i < selectedRows.Count(); i++)
						{
							selectedRows[i].Selected = false;
						}
					}
					nextRow.Selected = true;
				}
				e.Handled = true;
			}
		}


		T GetNextPrev<T>(List<T> list, T item, int positions) where T : class
		{
			if (list.Count == 0) return null;
			var index = list.IndexOf(item);
			index = (index + positions) % list.Count;
			if (index < 0) index = list.Count - 1;
			return list[index];
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public JocysCom.ClassLibrary.Security.Password.Generator PassGen = new JocysCom.ClassLibrary.Security.Password.Generator();

		public bool _displayAllCalls;

		private void ShowCalls(bool displayAllCalls)
		{
			_displayAllCalls = displayAllCalls;
			char[] chars = CallsTextBox.Text.ToCharArray();
			if (chars.Length == 0 && displayAllCalls) chars = new Charsets().Chars["ASCII"];
			var codes = chars.Select(x => (uint)x).ToArray();
			var callItems = new List<CallItem>();
			var call = GetCurrentCall();
			if (call != null)
			{
				Settings.Default.CallNameComboBox = call.CallName;
				//HelpTextBox.Text = call.CallName + ": " + call.CallDescription;
				for (uint i = 0; i < codes.Length; i++)
				{
					CallItem c = call.Keys.ContainsKey(codes[i])
						? call.Keys[codes[i]].Clone()
						: new CallItem() { Code = codes[i], Name = ((char)codes[i]).ToString() };
					c.Index = i + 1;
					callItems.Add(c);
				}
			}
			CallsDataGridView.DataSource = callItems;
		}

		JocysCom.ClassLibrary.Text.Filters filters = new JocysCom.ClassLibrary.Text.Filters();

		Call GetCurrentCall()
		{
			var row = CallNamesDataGridView.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();
			return row == null ? null : row.DataBoundItem as Call;
		}

		private void CallsDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			// Character code.
			if (e.ColumnIndex == 1)
			{
				uint code = (uint)e.Value;
				e.Value = (code).ToString("X4");
			}
			// 
			if (e.ColumnIndex == 3)
			{
				Call call = GetCurrentCall();
				if (!string.IsNullOrEmpty(call.FontName))
				{
					e.CellStyle.Font = new Font("Courier New", 9);// System.Drawing.SystemFonts.GetFontByName("Courier New");
				}

				uint charCode = (uint)CallsDataGridView.Rows[e.RowIndex].Cells[1].Value;
				char c = (char)charCode;
				Color color;
				if (char.IsLetter(c) && char.IsUpper(c)) color = System.Drawing.Color.Black;
				else if (char.IsLetter(c) && char.IsLower(c)) color = System.Drawing.Color.Black;
				else if (char.IsNumber(c)) color = System.Drawing.Color.DarkBlue;
				else color = System.Drawing.Color.Purple;
				e.CellStyle.ForeColor = color;
			}
		}

		private void CallsTimer_Tick(object sender, EventArgs e)
		{
			CallsTimer.Stop();
			CallsTextBox.SelectAll();
		}

		private void CallsTextBox_TextChanged(object sender, EventArgs e)
		{
			CallTextLengthTextBox.Text = CallsTextBox.Text.Length.ToString();
			int strength = PassGen.GetPasswordStrength(CallsTextBox.Text.ToCharArray());
			PasswordStrengthTextBox.ForeColor = System.Drawing.Color.DarkGray;
			if (strength > 8) PasswordStrengthTextBox.ForeColor = System.Drawing.Color.Black; ;
			if (strength > 12) PasswordStrengthTextBox.ForeColor = System.Drawing.Color.Green;
			PasswordStrengthTextBox.Text = strength.ToString();
			ShowCalls(false);
			CallsTimer.Stop();
			CallsTimer.Start();
		}

		public void RegeneratePassword(string presetName)
		{
			if (PresetNameComboBox.Items.Contains(presetName))
			{
				if (PresetNameComboBox.Text != presetName)
				{
					PresetNameComboBox.Text = presetName;
				}
				else
				{
					GeneratePasswords(true);
				}
			}
		}

		private void PresetNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			Preset preset = Presets.Single(x => x.PresetName == PresetNameComboBox.Text);
			HelpTextBox.Text = preset.PresetName + ": " + preset.PresetDescription;
			LoadPreset(preset);
			HelpContent = null;
		}

		public void LoadPreset(Preset preset)
		{
			// PresetName;
			// PresetDescription;
			// PresetRemarks;
			PasswordLengthNumericUpDown.Value = (decimal)preset.PasswordLength;
			UseNumbersCheckBox.Checked = preset.UseNumbers;
			UseUppercaseCheckBox.Checked = preset.UseUppercase;
			UseLowercaseCheckBox.Checked = preset.UseLowercase;
			UseSymbolsCheckBox.Checked = preset.UseSymbols;
			UseExtraCheckBox.Checked = preset.UseExtra;
			RatioNumbersNumericUpDown.Value = (decimal)preset.RatioNumbers;
			RatioUppercaseNumericUpDown.Value = (decimal)preset.RatioUppercase;
			RatioLowercaseNumericUpDown.Value = (decimal)preset.RatioLowercase;
			RatioSymbolsNumericUpDown.Value = (decimal)preset.RatioSymbols;
			RatioExtraNumericUpDown.Value = (decimal)preset.RatioExtra;
			//public string CharsNumbers;
			//public string CharsUppercase;
			//public string CharsLowercase;
			//public string CharsSymbols;
			CharsExtraTextBox.Text = preset.CharsExtra;
			FilterRememberCheckBox.Checked = preset.FilterRemember;
			FilterKeyboardCheckBox.Checked = preset.FilterKeyboard;
			FilterEnforceCheckBox.Checked = preset.FilterEnforce;
			FilterPhoneCheckBox.Checked = preset.FilterPhone;
			FilterAsciiCheckBox.Checked = preset.FilterAscii;
			FilterCharsCheckBox.Checked = preset.FilterChars;
			FilterCharsStringTextBox.Text = preset.FilterCharsString;
			ScriptEnabledCheckBox.Checked = preset.ScriptEnabled;
			JocysCom.ClassLibrary.Controls.DynamicCompile.LanguageType language = JocysCom.ClassLibrary.Controls.DynamicCompile.LanguageType.JScript;
			language = (JocysCom.ClassLibrary.Controls.DynamicCompile.LanguageType)Enum.Parse(language.GetType(), preset.ScriptLanguage);
			mainForm.ScriptPanel.LoadScript(language, preset.ScriptCode);
			if (preset.ScriptEnabled)
			{
				mainForm.ScriptPanel.Check();
			}
			else
			{
				mainForm.ScriptPanel.Clear();
			}
			RegexEnabledCheckBox.Checked = preset.RegexEnabled;
			RegexPatternFindTextBox.Text = preset.RegexPatternFind;
			RegexPatternReplaceTextBox.Text = preset.RegexPatternReplace;
			//public bool RegexIgnoreCase;

		}

		public Preset GetPresetFromForm()
		{
			Preset preset = SelectedPreset == null ? new Preset() : SelectedPreset.Copy();
			// PresetName;
			// PresetDescription;
			// PresetRemarks;
			preset.PasswordLength = (int)PasswordLengthNumericUpDown.Value;
			preset.UseNumbers = UseNumbersCheckBox.Checked;
			preset.UseUppercase = UseUppercaseCheckBox.Checked;
			preset.UseLowercase = UseLowercaseCheckBox.Checked;
			preset.UseSymbols = UseSymbolsCheckBox.Checked;
			preset.UseExtra = UseExtraCheckBox.Checked;
			preset.RatioNumbers = (int)RatioNumbersNumericUpDown.Value;
			preset.RatioUppercase = (int)RatioUppercaseNumericUpDown.Value;
			preset.RatioLowercase = (int)RatioLowercaseNumericUpDown.Value;
			preset.RatioSymbols = (int)RatioSymbolsNumericUpDown.Value;
			preset.RatioExtra = (int)RatioExtraNumericUpDown.Value;
			//public string CharsNumbers;
			//public string CharsUppercase;
			//public string CharsLowercase;
			//public string CharsSymbols;
			preset.CharsExtra = CharsExtraTextBox.Text;
			preset.FilterRemember = FilterRememberCheckBox.Checked;
			preset.FilterKeyboard = FilterKeyboardCheckBox.Checked;
			preset.FilterEnforce = FilterEnforceCheckBox.Checked;
			preset.FilterPhone = FilterPhoneCheckBox.Checked;
			preset.FilterAscii = FilterAsciiCheckBox.Checked;
			preset.FilterChars = FilterCharsCheckBox.Checked;
			preset.FilterCharsString = FilterCharsStringTextBox.Text;
			preset.ScriptEnabled = ScriptEnabledCheckBox.Checked;
			preset.ScriptCode = mainForm.ScriptPanel.CodeTextBox.Text;
			preset.ScriptEntry = mainForm.ScriptPanel.EntryToolStripComboBox.Text;
			preset.ScriptLanguage = mainForm.ScriptPanel.LanguageToolStripComboBox.Text;
			preset.RegexEnabled = RegexEnabledCheckBox.Checked;
			preset.RegexPatternFind = RegexPatternFindTextBox.Text;
			preset.RegexPatternReplace = RegexPatternReplaceTextBox.Text;
			//public bool RegexIgnoreCase;
			return preset;
		}


		private void FormPresetValue_Changed(object sender, EventArgs e)
		{
			if (sender == ScriptEnabledCheckBox)
			{
				if (ScriptEnabledCheckBox.Checked) mainForm.ShowScriptsTabPage();
				else mainForm.HideScriptsTabPage();
			}
			if (sender == UseNumbersCheckBox && UseNumbersCheckBox.Checked)
			{
				FilterRememberCheckBox.Checked = false;
			}
			if (sender == UseSymbolsCheckBox && UseSymbolsCheckBox.Checked)
			{
				FilterRememberCheckBox.Checked = false;
				FilterPhoneCheckBox.Checked = false;
			}
			if (sender == UseExtraCheckBox && UseExtraCheckBox.Checked)
			{
				FilterRememberCheckBox.Checked = false;
				FilterPhoneCheckBox.Checked = false;
			}
			if (sender == FilterRememberCheckBox && FilterRememberCheckBox.Checked)
			{
				UseNumbersCheckBox.Checked = false;
				UseSymbolsCheckBox.Checked = false;
				UseExtraCheckBox.Checked = false;
			}
			if (sender == FilterPhoneCheckBox && FilterPhoneCheckBox.Checked)
			{
				UseSymbolsCheckBox.Checked = false;
				UseExtraCheckBox.Checked = false;
			}
			// Do it with timer because after preset select this will fire a lot.
			FormOptionsTimer.Stop();
			FormOptionsTimer.Start();
		}

		bool firstLoad = true;

		private void FormOptionsTimer_Tick(object sender, EventArgs e)
		{
			FormOptionsTimer.Stop();
			RegexPatternFindTextBox.BackColor = RegexEnabledCheckBox.Checked
				? System.Drawing.SystemColors.Window
				: System.Drawing.SystemColors.Control;
			RegexPatternReplaceTextBox.BackColor = RegexEnabledCheckBox.Checked
				? System.Drawing.SystemColors.Window
				: System.Drawing.SystemColors.Control;
			PassGen.Preset = GetPresetFromForm();
			HelpContent = null;
			if (!firstLoad || Settings.Default.GeneratePasswordOnStart)
			{
				bool copyOnGenerate = Settings.Default.CopyOnGenerate;
				if (firstLoad && !Settings.Default.CopyPasswordWhenStart)
				{
					copyOnGenerate = false;
				}
				firstLoad = false;
				GeneratePasswords(copyOnGenerate);
			}
			string[] differenes = SelectedPreset.Compare(PassGen.Preset);
			if (differenes.Length > 0)
			{
			}
			bool isSame = differenes.Length == 0;
			//PresetSaveButton.Image = isSame
			//	? GetImage("disk_gray_16x16")
			//	: GetImage("disk_blue_16x16");
			PresetSaveButton.Enabled = !isSame;
		}


		object imageLock = new object();
		private System.Drawing.Image GetImage(string iconType)
		{
			lock (imageLock)
			{
				return JocysCom.ClassLibrary.Helper
					.GetResource<System.Drawing.Image>(Assembly.GetExecutingAssembly(), @"Sources\Images\" + iconType + ".png");
			}
		}

		private void GeneratePasswords(bool checkCopyOption)
		{
			List<Word> words = new List<Word>();
			Word password;
			TextBox textBox;
			for (var i = 1; i <= PassItemsCount; i++)
			{
				password = PassGen.NewPassword();
				words.Add(password);
				textBox = (TextBox)Controls.Find(string.Format("Password{0}TextBox", i), true)[0];
				textBox.Text = password.Text;
				// Reset colour of list items to black.
				textBox.ForeColor = System.Drawing.SystemColors.ControlText;
			}
			// if "Copy on [Generate]" checked...
			if (checkCopyOption) CopyInput(1, false);
			if (words.Where(x => x.Log.Length > 0).Count() > 0)
			{
				Word w = words.FirstOrDefault(x => x.Log.Length > 0 && x.Log.ToString().Contains("Error:"));
				HelpTextBox.Text = w == null ? string.Empty : w.Log.ToString();
			}
		}

		private void CopyButton_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			string ids = button.Name.Replace("Copy", "").Replace("Button", "");
			CopyInput(int.Parse(ids), mainForm.OptionsPanel.GenerateOnCopyCheckBox.Checked);
		}

		int PassItemsCount = 4;

		private void CopyInput(int id, bool regenerate)
		{
			Color markedColor = System.Drawing.Color.DarkGreen;
			string tid = string.Format("Password{0}TextBox", id);
			TextBox passTextBox = (TextBox)Controls.Find(tid, true)[0];
			if (!string.IsNullOrEmpty(passTextBox.Text))
			{
				Kolibri.Clippy.PushStringToClipboard(passTextBox.Text);
			}
			TextBox textBox;
			// Reset all to black.
			for (var i = 1; i <= PassItemsCount; i++)
			{
				textBox = (TextBox)Controls.Find(string.Format("Password{0}TextBox", i), true)[0];
				textBox.ForeColor = System.Drawing.SystemColors.ControlText;
			}
			// Mark password as copied.
			passTextBox.ForeColor = markedColor;
			CallsTextBox.Text = passTextBox.Text;
			if (regenerate)
			{
				if (mainForm.OptionsPanel.GenerateOnCopyCheckBox.Checked)
				{
					// Regenerate black inputs
					for (var i = 1; i <= PassItemsCount; i++)
					{
						textBox = (TextBox)Controls.Find(string.Format("Password{0}TextBox", i), true)[0];
						if (textBox.ForeColor != markedColor) textBox.Text = PassGen.NewPassword().Text;
					}
				}
			}
			mainForm.LeftToolStripStatusLabel.Text = string.Format("Copy: Password copied to clipboard.");
		}

		private void GenerateButton_Click(object sender, EventArgs e)
		{
			GeneratePasswords(true);
		}

		private void FavPreset1Button_Click(object sender, EventArgs e)
		{
			RegeneratePassword(Settings.Default.FavPreset1ComboBox);
		}

		private void FavPreset2Button_Click(object sender, EventArgs e)
		{
			RegeneratePassword(Settings.Default.FavPreset2ComboBox);
		}

		private void FavPreset3Button_Click(object sender, EventArgs e)
		{
			RegeneratePassword(Settings.Default.FavPreset3ComboBox);
		}

		private void easyToolStripMenuItem_MouseLeave(object sender, EventArgs e)
		{
			ToolStripMenuItem s = (ToolStripMenuItem)sender;
		}

		private void easyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem s = (ToolStripMenuItem)sender;
		}

		private void GetListButton_Click(object sender, EventArgs e)
		{
			mainForm.LeftToolStripStatusLabel.Text = string.Format("Get List: In progress...");
			int count = (int)ListSizeNumericUpDown.Value;
			string separator = FromLiteral(ListSeparatorComboBox.Text);
			string list = PassGen.NewPasswordList(count, separator);
			if (list.Length > 0) Clipboard.SetText(list);
			mainForm.LeftToolStripStatusLabel.Text = string.Format("Get List: {0} passwords generated. List copied to clipboard.", count);
			if (Settings.Default.OpenPasswordListFileAfterSave)
			{
				string tempPath = System.IO.Path.Combine(PassGenHelper.AppDataPath, "Temp");
				DirectoryInfo di = new DirectoryInfo(tempPath);
				if (!di.Exists) di.Create();
				tempPath = System.IO.Path.Combine(tempPath, "list.txt");
				System.IO.File.WriteAllText(tempPath, list);
				System.Diagnostics.Process.Start(tempPath);
			}
		}

		/// <summary>
		/// Converts: \tHello\r\n\tWorld! -> "\\tHello\\r\\n\tWorld!"
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		static string ToLiteral(string input)
		{
			var writer = new StringWriter();
			CSharpCodeProvider provider = new CSharpCodeProvider();
			provider.GenerateCodeFromExpression(new CodePrimitiveExpression(input), writer, null);
			return writer.GetStringBuilder().ToString();
		}

		static string FromLiteral(string input)
		{
			return Regex.Unescape(input);
		}

		protected MainForm mainForm
		{
			get { return Program.mainForm; }
		}

		//private void ScriptEditLinkLabel_Click(object sender, EventArgs e)
		//{
		//	var ln = (LanguageType)Enum.Parse(typeof(LanguageType), PassGen.Preset.ScriptLanguage);
		//	mainForm.ScriptPanel.LoadScript(ln, PassGen.Preset.ScriptCode);
		//	//.Cast<TreeNode>().FirstOrDefault(x => x.Text == "Script Editor");
		//}

		private void CallNameComboBox_MouseMove(object sender, MouseEventArgs e)
		{
			//    Point ptCursor = Cursor.Position;
			//ptCursor = PointToClient(ptCursor);
			////CallNameComboBox.Items.Cast<Label>().Where(c => c.Bounds.Contains(ptCursor)).FirstOrDefault();
			//var item = CallNameComboBox.GetChildAtPoint(ptCursor);
			//HelpTextBox.Text = item == null ? e.X.ToString()+":"+e.Y.ToString() : item.ToString();
		}

		private void CallNameComboBox_MouseEnter(object sender, EventArgs e)
		{
			//HelpTextBox.Text = string.Format("{0}\r\n", CallNameComboBox.SelectionStart) + HelpTextBox.Text;
		}

		private void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
		{
			ComboBox cbx = (ComboBox)sender;

			//HelpTextBox.Text = string.Format("{0} - {1}\r\n", e.Index, e.State) + HelpTextBox.Text;
			e.DrawBackground();
			e.DrawFocusRectangle();
			string value = e.Index > -1 ? cbx.Items[e.Index].ToString() : null;
			if (!string.IsNullOrEmpty(value))
			{
				System.Drawing.Brush brush = System.Drawing.SystemBrushes.FromSystemColor(e.ForeColor);
				//e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
				//e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
				//e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.Default;
				//e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
				//e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Default;
				e.Graphics.DrawString(value, cbx.Font, brush, e.Bounds.Left, e.Bounds.Top + 1);
				if (cbx.DroppedDown)
				{
					HelpTimer.Stop();
					string text = string.Empty;
					if (cbx.Name.Contains("Call"))
					{
						Call call = Calls.Single(x => x.CallName == value);
						text = call.CallName + ": " + call.CallDescription;
					}
					if (cbx.Name.Contains("Preset"))
					{
						Preset preset = Presets.Single(x => x.PresetName == value);
						text = preset.PresetName + ": " + preset.PresetDescription;
					}
					mainForm.ControlHelpBodyLabel.Text = text;
				}
			}
		}

		public string GetPresetFileName(Preset preset)
		{
			var path = Path.Combine(PassGenHelper.AppDataPath, "Presets");
			DirectoryInfo di = new DirectoryInfo(path);
			return Path.Combine(path, preset.GetFileName());
		}

		private void PresetSaveButton_Click(object sender, EventArgs e)
		{
			Preset preset = GetPresetFromForm();
			string fileName = GetPresetFileName(preset);
			FileInfo fi = new FileInfo(fileName);
			if (!fi.Directory.Exists) fi.Directory.Create();
			preset.SaveAs(fi.FullName);
			// Replace preset with same name.
			for (int i = 0; i < Presets.Count(); i++)
			{
				if (Presets[i].PresetName == preset.PresetName)
				{
					Presets[i] = preset;
				}
			}
			//PresetSaveButton.Image = GetImage("disk_gray_16x16");
			PresetSaveButton.Enabled = false;
		}

		private void CallNamesDataGridView_SelectionChanged(object sender, EventArgs e)
		{
			// If binding complete then...
			if (CallNamesDataBindingComplete)
			{
				//// If call names are available but none selected then...
				//if (CallNamesDataGridView.SelectedRows.Count == 0 && CallNamesDataGridView.RowCount > 0)
				//{
				//	SelectCall(Settings.Default.CallNameComboBox);
				//	return;
				//}
				ShowCalls(_displayAllCalls);
			}
		}

		void SelectCall(string callName)
		{
			var rows = CallNamesDataGridView.Rows.Cast<DataGridViewRow>().ToArray();
			foreach (var row in rows)
			{
				var item = (Call)row.DataBoundItem;
				var selected = (item.CallName == callName);
				if (row.Selected = selected)
				{
					row.Selected = selected;
				}
			}
		}

		private void CallNamesDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			Color color = System.Drawing.Color.Black;
			e.CellStyle.ForeColor = color;
		}

		private void CallNamesDataGridView_DoubleClick(object sender, EventArgs e)
		{
			ShowCalls(true);
		}

		bool CallNamesDataBindingComplete = false;

		private void CallNamesDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			SelectCall(Settings.Default.CallNameComboBox);
			CallNamesDataBindingComplete = true;
		}
	}
}
