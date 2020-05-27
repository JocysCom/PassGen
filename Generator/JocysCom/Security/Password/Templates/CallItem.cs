using System;

namespace JocysCom.ClassLibrary.Security.Password.Templates
{
	[Serializable]
	public class CallItem
	{
		public uint Index { get; set; }
		public uint Code { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		public CallItem Clone()
		{
			return new CallItem()
			{
				Index = Index,
				Code = Code,
				Name = Name,
				Description = Description,
			};
		}

	}

}
