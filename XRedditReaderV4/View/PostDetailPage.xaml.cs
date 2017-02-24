using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XRedditReaderV4
{
	public partial class PostDetailPage : ContentPage
	{
		public PostDetailPage(Post selectedPost)
		{
			InitializeComponent();
			this.BindingContext = selectedPost;
		}
	}
}
