using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace XRedditReaderV4
{
	public class PostDirectoryViewModel : ViewModelBase
	{

		#region Properties

		private IPostService dataService;
		private Post _selectedPost;

		List<string> postTypes = new List<string>
		{
			"New",
			"Hot",
			"Controversial",
			"Top",
			"Rising"
		};

		private string selectedPostType;
		public string SelectedPostType
		{
			get
			{
				return selectedPostType;
			}

			set
			{
				if (selectedPostType == value)
				{
					return;
				}
				selectedPostType = value;
				OnPropertyChanged();
			}
		}

		public List<string> PostTypes => postTypes;

		int postTypeSelectedIndex;

		public int PostTypeSelectedIndex
		{
			get
			{
				return postTypeSelectedIndex;
			}
			set
			{
				if (postTypeSelectedIndex != value)
				{
					postTypeSelectedIndex = value;
					OnPropertyChanged();
					SelectedPostType = PostTypes[postTypeSelectedIndex];
				}
			}
		}

		public ObservableCollection<Post> Posts
		{
			get;
			private set;
		}

		//Post selected to navigate to details page
		public Post SelectedPost
		{
			get
			{
				return _selectedPost;
			}
			set
			{
				if (_selectedPost == value)
				{
					return;
				}
				_selectedPost = value;
				OnPropertyChanged();
			}
		}

		#endregion


		#region Constructor
		public PostDirectoryViewModel()
		{
			dataService = new PostService();
			this.IsBusy = false;
			Posts = new ObservableCollection<Post>();


			//Initialize Commands
			GetPostsAsyncCommand = new Command<string>(GetPostsAsync);

			Task.Run(async () => await InitializeListView());

		}





		#endregion


		#region Commands

		public ICommand GetPostsAsyncCommand
		{
			get;
			private set;
		}

		public async void GetPostsAsync(string selectedPostType)
		{
			IsBusy = true;
			Posts.Clear();
			var posts = await dataService.GetPostsAsync(selectedPostType);

			foreach (var post in posts)
			{
				Posts.Add(post);
			}

			IsBusy = false;
		}

		//Initialize List View
		public async Task InitializeListView()
		{
			IsBusy = true;
			Posts.Clear();
			var posts = await dataService.GetPostsAsync("New");

			foreach (var post in posts)
			{
				Posts.Add(post);
				OnPropertyChanged();
			}

			IsBusy = false;
		}

		#endregion
	}
}



