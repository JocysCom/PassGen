using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace JocysCom.Password.Generator.Controls
{
	public partial class ResorcesControl : UserControl
	{
		public ResorcesControl()
		{
			InitializeComponent();
		}

		Dictionary<string, int> Adjectives;
		Dictionary<string, int> Nouns;
		Dictionary<string, int> Verbs;
		Dictionary<string, int> Adverbs;
		Dictionary<string, int> Frequency;

		private void LoadDataButton_Click(object sender, EventArgs e)
		{
			// Load frequency;
			LoadFrequency(FrequencyTextBox.Text, ref Frequency, LoadFrequencyTextBox);
			LoadWords(NounsTextBox.Text, ref Nouns, LoadNounsTextBox);
			LoadWords(AdjectivesTextBox.Text, ref Adjectives, LoadAdjectiveTextBox, Nouns);
			LoadWords(VerbsTextBox.Text, ref Verbs, LoadVerbsTextBox, Nouns, Adjectives);
			LoadWords(AdverbsTextBox.Text, ref Adverbs, LoadAdverbsTextBox, Nouns, Adjectives, Verbs);
		}

		void LoadFrequency(string source, ref Dictionary<string, int> list, TextBox result)
		{
			list = new Dictionary<string, int>();
			var rx = new Regex("^(?<word>[a-z]+)\\s+(?<freq>[0-9]+)");
			var lines = File.ReadLines(source).ToArray();
			var count = 0;
			foreach (var line in lines)
			{
				var match = rx.Match(line);
				if (!match.Success)
					continue;
				var word = match.Groups["word"].Value;
				var freq = int.Parse(match.Groups["freq"].Value);
				// Do not add if word is too small.
				if (word.Length < WordSizeMinNumericUpDown.Value)
					continue;
				// Do not add if word is too large.
				if (word.Length > WordSizeMaxNumericUpDown.Value)
					continue;
				count++;
				list.Add(word, freq);
				if (count >= LimitToTopNumericUpDown.Value)
					break;
			}
			result.Text = string.Format("{0}", list.Count);
		}

		void LoadWords(string source, ref Dictionary<string, int> list, TextBox result, params Dictionary<string, int>[] excludes)
		{
			list = new Dictionary<string, int>();
			var rx = new Regex("^(?<word>[a-z]+)\\s+");
			var lines = File.ReadLines(source).ToArray();
			var count = 0;
			foreach (var line in lines)
			{
				var match = rx.Match(line);
				if (!match.Success)
					continue;
				var word = match.Groups["word"].Value;
				if (!Frequency.ContainsKey(word))
					continue;
				if (excludes.Any(x => x.ContainsKey(word)))
					continue;
				var freq = Frequency[word];
				count++;
				list.Add(word, freq);
			}
			result.Text = string.Format("{0}", list.Count);
		}

		private void SaveDataButton_Click(object sender, EventArgs e)
		{
			SaveResultTextBox.Text = "";
			SaveWords(Adjectives, PassGenHelper.AdjectiveResource);
			SaveWords(Nouns, PassGenHelper.NounsResource);
			SaveWords(Verbs, PassGenHelper.VerbsResource);
			SaveWords(Adverbs, PassGenHelper.AdverbsResource);
			SaveResultTextBox.Text = "Done";
		}

		void SaveWords(Dictionary<string, int> list, string fileName)
		{
			var lines = list.Select(x => string.Format("{0},{1}", x.Key, x.Value));
			var contents = string.Join("\r\n", lines);
			var bytes = System.Text.Encoding.UTF8.GetBytes(contents);
			var path = System.IO.Path.Combine(SaveFolderTextBox.Text, fileName);
			System.IO.File.WriteAllText(path, contents);
			var compressedBytes = JocysCom.ClassLibrary.Configuration.SettingsHelper.Compress(bytes);
			System.IO.File.WriteAllBytes(path + ".gz", compressedBytes);
		}

		private void GenerateButton_Click(object sender, EventArgs e)
		{
			var adjective = PassGenHelper.GetRandom(Adjectives);
			var noun = PassGenHelper.GetRandom(Nouns);
			var verb = PassGenHelper.GetRandom(Verbs);
			var adverb = PassGenHelper.GetRandom(Adverbs);
			PasswordTextBox.Text = string.Format("{0}{1}{2}{3}", adjective, noun, verb, adverb);
		}

	}
}
