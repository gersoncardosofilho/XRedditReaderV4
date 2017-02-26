using System;
using System.Collections.Generic;
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

		public ObservableCollection<string> PostTypes
		{
			get;
		}

		private Post selectedPost;
		public Post SelectedPostType
		{
			get
			{
				return selectedPost;
			}
			set
			{
				if (selectedPost == value)
				{
					return;
				}
				selectedPost = value;
				OnPropertyChanged();
			}
		}

		int index;
		public int Index
		{
			get
			{
				return index;
			}
			set
			{
				if (index == value)
				{
					return;
				}
				index = value;
				OnPropertyChanged();
			}
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
			this.PostTypes = new ObservableCollection<string>() { "Hot Posts", "New Posts", "Top Posts", "Controversial Posts", "Rising Posts" };
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
