using System;
using System.Collections.Generic;
using System.Net;
using Xamarin.Forms;

namespace XRedditReaderV4
{
	public partial class PostDetailWebview : ContentPage
	{


		public PostDetailWebview(Post selectedPost)
		{
			InitializeComponent();

			Label header = new Label
			{
				Text = "WebView",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
				HorizontalOptions = LayoutOptions.Center
			};

			string html = WebUtility.HtmlDecode(selectedPost.Media_embed.Content);

			var webSource = new HtmlWebViewSource();
			webSource.Html = html;

			WebView webView = new WebView
			{
				Source = webSource,
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			// Accomodate iPhone status bar.
			this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

			// Build the page.
			this.Content = new StackLayout
			{
				Children =
				{
					header,
					webView
				}
			};

		}
	}
}
