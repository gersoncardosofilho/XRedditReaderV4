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
		private RelayCommand _refreshCommand;
		//private RelayCommand<string> _refreshSelectedPosts;

		List<string> countries = new List<string>
	{
		"Afghanistan",
		"Albania",
		"Algeria",
		"Andorra",
		"Angola"
	};

		private string selectedCountry;
		public string SelectedCountry
		{
			get
			{
				return selectedCountry;
			}

			set
			{
				if (selectedCountry == value)
				{
					return;
				}
				selectedCountry = value;
				OnPropertyChanged();
			}
		}

		public List<string> Countries => countries;

		int countriesSelectedIndex;

		public int CountriesSelectedIndex
		{
			get
			{
				return countriesSelectedIndex;
			}
			set
			{
				if (countriesSelectedIndex != value)
				{
					countriesSelectedIndex = value;
					OnPropertyChanged();
					SelectedCountry = Countries[countriesSelectedIndex];
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

		public RelayCommand RefreshCommand
		{
			get
			{
				return _refreshCommand
					?? (_refreshCommand = new RelayCommand(
						async () =>
						{
							await Refresh();
						}));
			}
		}

		private async Task Refresh()
		{
			IsBusy = true;

			Posts.Clear();

			var posts = await _dataService.Refresh();

			foreach (var post in posts)
			{
				Posts.Add(post);
			}

			IsBusy = false;
		}

		//public RelayCommand<string> GetSelectedPostsCommand
		//{
		//	get
		//	{
		//		return _refreshSelectedPosts
		//			?? (_refreshSelectedPosts = new RelayCommand<string>(
		//				async s =>
		//				{

		//					await GetSelectedPosts(s);

		//				}));
		//	}
		//}

		//async Task GetSelectedPosts(SelectedPostType)
		//{
		//	Posts.Clear();

		//	var posts = await _dataService.GetPostsAsync(SelectedPostType);

		//	foreach (var post in posts)
		//	{
		//		Posts.Add(post);
		//	}
		//}


	}
}


