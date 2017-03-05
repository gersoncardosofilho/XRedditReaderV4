using System;
using System.ComponentModel;

namespace XRedditReaderV4
{
	public class Post : ViewModelBase
	{
		private string _thumbnail;
		private string _url;
		private string _title;
		private string _subreddit;
		private string _subreddit_name_prefixed;

		public string Thumbnail
		{
			get
			{
				return _thumbnail;
			}
			set
			{
				if (_thumbnail == value)
				{
					return;
				}
				_thumbnail = value;
				OnPropertyChanged();

			}
		}

		public string Url
		{
			get
			{
				return _url;
			}
			set
			{
				if (_url == value)
				{
					return;
				}
				_url = value;
				OnPropertyChanged();
			}
		}

		public string Title
		{
			get
			{
				return _title;
			}
			set
			{
				if (_title == value)
				{
					return;
				}
				_title = value;
				OnPropertyChanged();
			}
		}

		public string Subreddit
		{
			get
			{
				return _subreddit;
			}
			set 
			{
				if (_subreddit == value)
				{
					return;
				}
				_subreddit = value;
				OnPropertyChanged();
			}
		}

		public string Subreddit_name_prefixed
		{
			get
			{
				return _subreddit_name_prefixed;
			}
			set
			{
				if (_subreddit_name_prefixed == value)
				{
					return;
				}
				_subreddit_name_prefixed = value;
				OnPropertyChanged();
			}
		}

	}
}
