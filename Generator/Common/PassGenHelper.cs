using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using JocysCom.ClassLibrary.Runtime;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace JocysCom.Password.Generator
{
	public class PassGenHelper
	{

		// IsMultiValue (values are stored in objects list.
		// Updated = non light blue background (if column was changed)
		// SameValue
		// on Apply update all Updated with Same Value.
		// Reset to multi-value/default (and Updated=false) with CTRL+0

		public static Dictionary<string, bool> GetDefaults(Type type)
		{
			Dictionary<string, bool> results = new Dictionary<string, bool>();
			BindingFlags bf = JocysCom.ClassLibrary.Runtime.Helper.DefaultBindingFlags;
			// Add property names.
			PropertyInfo[] properties = type.GetProperties(bf);
			string[] propertyNames = type.GetProperties(bf).Select(x => x.Name).ToArray();
			foreach (var name in propertyNames) results.Add(name, false);
			// Add field names.
			FieldInfo[] fields = type.GetFields(bf);
			string[] fieldNames = type.GetFields(bf).Select(x => x.Name).ToArray();
			foreach (var name in propertyNames) results.Add(name, false);
			return results;
		}

		/// <summary>
		/// Get all possible values used by items in the list by specified property.
		/// </summary>
		/// <typeparam name="T">List item type</typeparam>
		/// <typeparam name="TValue">Property value type</typeparam>
		/// <param name="list"></param>
		/// <param name="propertyName"></param>
		/// <returns></returns>
		public static ChangeState GetValues<T>(List<T> list, string propertyName)
		{
			List<object> multiValues = new List<object>();
			ChangeState changeState = new ChangeState();
			Type type = typeof(T);
			Dictionary<string, bool> defaults = GetDefaults(type);
			string[] names = defaults.Select(x => x.Key).ToArray();
			object value;
			MemberInfo mi = null;
			for (int i = 0; i < list.Count; i++)
			{
				var item = list[i];
				if (i == 0)
				{
					mi = type.GetMember(propertyName).FirstOrDefault();
					changeState.ValueType = mi.DeclaringType;
				}
				if (mi.MemberType == MemberTypes.Field)
				{
					value = type.GetField(propertyName).GetValue(item);
					if (!multiValues.Contains(value)) multiValues.Add(value);
				}
				if (mi.MemberType == MemberTypes.Property)
				{
					value = type.GetProperty(propertyName).GetValue(item, null);
					if (!multiValues.Contains(value)) multiValues.Add(value);
				}
			}
			changeState.MultiValues = list.Select(x => (object)x).ToArray();
			return changeState;
		}

		public static void LoadPresets(ComboBox control, string[] presets, string selectedItem)
		{
			control.Items.Clear();
			control.Items.AddRange(presets);
			if (control.Items.Contains(selectedItem))
			{
				control.SelectedItem = selectedItem;
			}
			else
			{
				control.SelectedIndex = -1;
			}
		}

		#region Resources

		public const string AdjectiveResource = "Adjectives.csv";
		public const string NounsResource = "Nouns.csv";
		public const string VerbsResource = "Verbs.csv";
		public const string AdverbsResource = "Adverbs.csv";

		public static Dictionary<string, int> Adjectives
		{
			get
			{
				if (_Adjectives == null)
					_Adjectives = GetList(AdjectiveResource + ".gz");
				return _Adjectives;
			}
		}
		static Dictionary<string, int> _Adjectives;

		public static Dictionary<string, int> Nouns
		{
			get
			{
				if (_Nouns == null)
					_Nouns = GetList(NounsResource + ".gz");
				return _Nouns;
			}
		}
		static Dictionary<string, int> _Nouns;

		public static Dictionary<string, int> Verbs
		{
			get
			{
				if (_Verbs == null)
					_Verbs = GetList(VerbsResource + ".gz");
				return _Verbs;
			}
		}
		static Dictionary<string, int> _Verbs;

		public static Dictionary<string, int> Adverbs
		{
			get
			{
				if (_Adverbs == null)
					_Adverbs = GetList(AdverbsResource + ".gz");
				return _Adverbs;
			}
		}
		static Dictionary<string, int> _Adverbs;

		static Random rnd = new Random();
		static public TextInfo Culture = new CultureInfo("en-US", false).TextInfo;

		static Dictionary<string, int> GetList(string name)
		{

			var list = new Dictionary<string, int>();
			var compressedBytes = JocysCom.ClassLibrary.Helper.FindResource<byte[]>(name);
			var bytes = JocysCom.ClassLibrary.Configuration.SettingsHelper.Decompress(compressedBytes);
			var content = System.Text.Encoding.UTF8.GetString(bytes);
			var rx = new Regex("^(?<word>[a-z]+),(?<freq>[0-9]+)");
			using (var sr = new StringReader(content))
			{
				string line;
				while ((line = sr.ReadLine()) != null)
				{
					var match = rx.Match(line);
					if (!match.Success)
						continue;
					var word = match.Groups["word"].Value;
					var freq = int.Parse(match.Groups["freq"].Value);
					list.Add(word, freq);
				}
			}
			return list;
		}

		public static string GetRandom(Dictionary<string, int> list)
		{
			// Get random char.
			var index = rnd.Next(list.Count);
			var key = list.ElementAt(index).Key;
			key = Culture.ToTitleCase(key);
			//key = key.Replace("O", "0");
			//key = key.Replace("o", "0");
			//key = key.Replace("S", "5");
			//key = key.Replace("s", "5");
			//key = key.Replace("E", "3");
			//key = key.Replace("e", "3");
			return key;
		}

		#endregion


	}
}
