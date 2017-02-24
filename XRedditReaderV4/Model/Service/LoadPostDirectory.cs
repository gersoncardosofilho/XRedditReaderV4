using System;
using System.Collections.ObjectModel;

namespace XRedditReaderV4
{
	public class LoadPostDirectory
	{
		public static PostDirectory LoadPostsDirectory()
		{
			PostDirectory postDirectory = new PostDirectory();

			ObservableCollection<Post> posts;

			string[] titles = { "Titulo1", "Titulo2", "Titulo3", "Titulo4", "Titulo5", "Titulo6", "Titulo7", "Titulo8", "Titulo9", "Titulo10" };
			string[] subreddits = { "Subreddit1", "Subreddit2", "Subreddit3", "Subreddit4", "Subreddit5", "Subreddit6", "Subreddit7", "Subreddit8", "Subreddit9", "Subreddit10" };
			string[] urls = { "http://url1.com", "http://url2.com", "http://url3.com", "http://url4.com", "http://url5.com", "http://url6.com", "http://url7.com", "http://url8.com", "http://url9.com", "http://url10.com" };
			string thumbnail = "http://b.thumbs.redditmedia.com/n0tdhm7qulYQvq4Y8BUj7R6_sYW5MexAF2mrDT7GcwI.jpg";

			posts = new ObservableCollection<Post>();

			for (int i = 0; i < 10; i++)
			{
				Post post = new Post();
				post.Subreddit = subreddits[i];
				post.Thumbnail = thumbnail;
				post.Title = titles[i];
				post.Url = urls[i];

				posts.Add(post);
			}

			postDirectory.Posts = posts;
			return postDirectory;
		}
	}
}
