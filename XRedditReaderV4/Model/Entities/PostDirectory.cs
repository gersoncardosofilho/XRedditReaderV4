using System;
using System.Collections.ObjectModel;

namespace XRedditReaderV4
{
	public class PostDirectory
	{
		private ObservableCollection<Post> posts = new ObservableCollection<Post>();

		public ObservableCollection<Post> Posts
		{
			get
			{
				return posts;
			}
			set
			{
				if (posts == value)
				{
					return;
				}
				posts = value;
			}
		}
	}
}
