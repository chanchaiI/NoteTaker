using System;

namespace NoteTaker
{
	public class DataModel
	{
		public DataModel ()
		{
		}
	}


	public class Note
	{
		public string title {
			get;
			set;
		}
		public string description {
			get;
			set;
		}
		public DateTime dateCreated {
			get;
			set;
		}
	}
}

