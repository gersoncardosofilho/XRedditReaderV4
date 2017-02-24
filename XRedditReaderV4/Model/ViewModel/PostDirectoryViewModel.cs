using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XRedditReaderV4
{
	public class PostDirectoryViewModel : ObservableBaseObject
	{
		public ObservableCollection<Post> Posts
		{
			get;
			set;
		}

		bool isBusy = false;
		public bool IsBusy
		{
			get
			{
				return isBusy;
			}
			set
			{
				if (isBusy == value)
				{
					return;
				}
				isBusy = value;
				OnPropertyChanged();
			}
		}

		public Command LoadDirectoryCommand
		{
			get;
			set;
		}

		public PostDirectoryViewModel()
		{
			Posts = new ObservableCollection<Post>();
			IsBusy = false;
			LoadDirectoryCommand = new Command((obj) => LoadDirectory());
		}

		async void LoadDirectory()
		{
			if (!IsBusy)
			{
				IsBusy = true;

				await Task.Delay(3000);
				var loadedPosts = LoadPostDirectory.LoadPostsDirectory();
				foreach (var post in loadedPosts.Posts)
				{
					Posts.Add(post);
				}

				IsBusy = false;
			}
		}
}
}
