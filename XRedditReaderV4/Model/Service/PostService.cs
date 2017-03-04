using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
		#region Properties
		HttpClient client;

		public ObservableCollection<Post> postsResult
		{
			get;
			set;
		}

		private string url;

		#endregion

		#region Constructor
		public PostService()
		{
			var authData = string.Format("{0}:{1}", Constants.Username, Constants.Password);
			var authHeader = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

			client = new HttpClient();
			client.MaxResponseContentBufferSize = 256000;
			client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authHeader);
		}
		#endregion

		#region Methods
		public async Task<ObservableCollection<Post>> GetPostsAsync(string postType)
		{
			switch (postType)
			{
				case "Hot":
					url = "https://www.reddit.com/hot/.json";
					break;

				case "New":
					url = "https://www.reddit.com/new/.json";
					break;

				case "Top":
					url = "https://www.reddit.com/top/.json";
					break;

				case "Controversial":
					url = "https://www.reddit.com/controversial/.json";
					break;

				case "Rising":
					url = "https://www.reddit.com/rising/.json";
					break;

				default:
					break;
			}

			var uri = new Uri(string.Format(url, string.Empty));

			try
			{
				var response = await client.GetAsync(uri);
				if (response.IsSuccessStatusCode)
				{
					var content = await response.Content.ReadAsStringAsync();

					JObject result = JObject.Parse(content);
					IList<JToken> postResults = result["data"]["children"].Children()["data"].ToList();
					postsResult = new ObservableCollection<Post>();

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
		#endregion
	}
}
