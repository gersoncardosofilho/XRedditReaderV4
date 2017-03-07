using System;
using System.ComponentModel;

namespace XRedditReaderV4
{
	public class Media_Embed:ViewModelBase
	{
		private string _content;
		private int _width;
		private bool _scrolling;
		private int _height;

		public string Content
		{
			get
			{
				return _content;
			}
			set
			{
				if (_content == value)
				{
					return;
				}
				_content = value;
				OnIsBusyChanged();
			}
		}

		public int Width
		{
			get
			{
				return _width;
			}
			set
			{
				if (_width == value)
				{
					return;
				}
				_width = value;
				OnIsBusyChanged();
			}
		}

		public bool Scrooling
		{
			get
			{
				return _scrolling;
			}
			set
			{
				if (_scrolling == value)
				{
					return;
				}
				_scrolling = value;
				OnIsBusyChanged();
			}
		}

		public int Height
		{
			get
			{
				return _height;
			}
			set
			{
				if (_height == value)
				{
					return;
				}
				_height = value;
				OnIsBusyChanged();
			}
		}
	}

	public class Post : ViewModelBase
	{
		private string _thumbnail;
		private string _url;
		private string _title;
		private string _subreddit;
		private string _subreddit_name_prefixed;
		private Media_Embed _media_embed;

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

		public Media_Embed Media_embed
		{
			get
			{
				return _media_embed;
			}
			set
			{
				if (_media_embed == value)
				{
					return;
				}
				_media_embed = value;
				OnPropertyChanged();
			}
		}

	}
}
