using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace XRedditReaderV4
{
	public interface IPostService
	{
 		Task<ObservableCollection<Post>> GetPostsAsync(string postType);
	}
}
