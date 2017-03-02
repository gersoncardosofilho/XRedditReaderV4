using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace XRedditReaderV4
{
	public class PostService : IPostService
	{
		HttpClient client;

		public IList<Post> postsResult
		{
			get;
			set;
		}


		public PostService()
		{
			var authData = string.Format("{0}:{1}", Constants.Username, Constants.Password);
			var authHeader = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

			client = new HttpClient();
			client.MaxResponseContentBufferSize = 256000;
			client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authHeader);
		}

		public async Task<IList<Post>> GetPostsAsync()
		{

			var uri = new Uri(string.Format(Constants.BaseUrl, string.Empty));

			try
			{
				var response = await client.GetAsync(uri);
				if (response.IsSuccessStatusCode)
				{
					var content = await response.Content.ReadAsStringAsync();

					JObject result = JObject.Parse(content);
					IList<JToken> postResults = result["data"]["children"].Children()["data"].ToList();
					postsResult = new List<Post>();

					foreach (JToken post in postResults)
					{
						Post newPost = JsonConvert.DeserializeObject<Post>(post.ToString());
						postsResult.Add(newPost);
					}


				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"             ERROR{0}", ex.Message);
			}

			return postsResult;
		}


	}
}
