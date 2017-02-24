using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XRedditReaderV4
{
	public class ObservableBaseObject : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged = delegate {};

		public void OnPropertyChanged([CallerMemberName] string name = "")
		{
			if (PropertyChanged == null)
			{
				return;
			}
			PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
		}
	}
}
