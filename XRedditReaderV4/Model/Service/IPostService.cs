using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XRedditReaderV4;

namespace XRedditReaderV4
{
	public interface IPostService
	{
		Task<IList<Post>> GetPostsAsync();
	}
}
