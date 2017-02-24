using System;
using System.ComponentModel;

namespace XRedditReaderV4
{
	public class Post : ObservableBaseObject
	{
		private string _thumbnail;
		private string _url;
		private string _title;
		private string _subreddit;

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

	}
}
