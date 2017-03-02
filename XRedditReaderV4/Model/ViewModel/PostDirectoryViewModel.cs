using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace XRedditReaderV4
{
	public class PostDirectoryViewModel : ObservableBaseObject
	{
		private IPostService _dataService;
		private Post _selectedPost;
		//private RelayCommand _refreshCommand;
		//private RelayCommand<string> _getSelectedPostsCommand;

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

		private bool _isBusy = false;
		public bool IsBusy
		{
			get
			{
				return _isBusy;
			}
			set
			{
				if (_isBusy == value)
				{
					return;
				}
				_isBusy = value;
				OnPropertyChanged();
			}
		}


		//construtor
		public PostDirectoryViewModel(IPostService dataService)
		{
			this._dataService = dataService;
			this.IsBusy = false;

			Posts = new ObservableCollection<Post>();



		}


		public PostDirectoryViewModel() : this((new PostService())) { }


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
	}


	//public RelayCommand RefreshCommand
	//{
	//	get
	//	{
	//		return _refreshCommand
	//			?? (_refreshCommand = new RelayCommand(
	//				async () =>
	//				{
	//					await Refresh();
	//				}));
	//	}
	//}

	//private async Task Refresh()
	//{
	//	IsBusy = true;

	//	Posts.Clear();

	//	var posts = await _dataService.Refresh();

	//	foreach (var post in posts)
	//	{
	//		Posts.Add(post);
	//	}

	//	IsBusy = false;
	//}

	//public RelayCommand<string> GetSelectedPostsCommand
	//{
	//	get
	//	{
	//		return _getSelectedPostsCommand
	//			?? (_getSelectedPostsCommand = new RelayCommand<string>(
	//				async s =>
	//				{

	//					await GetSelectedPosts(s);

	//				}));
	//	}
	//}

	//async Task GetSelectedPosts(Sele)
	//{
	//	Posts.Clear();

	//	var posts = await _dataService.GetPostsAsync(SelectedPostType);

	//	foreach (var post in posts)
	//	{
	//		Posts.Add(post);
	//	}
	//}

}



