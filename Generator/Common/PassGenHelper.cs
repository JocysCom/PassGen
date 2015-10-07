using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using JocysCom.ClassLibrary.Runtime;
using System.Windows.Forms;

namespace JocysCom.PassMan.PassGen
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

	}
}
