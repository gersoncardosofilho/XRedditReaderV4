﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XRedditReaderV4
{
	public partial class MainPage : ContentPage
	{

		public MainPage()
		{
			InitializeComponent();
			this.BindingContext = new PostDirectoryViewModel();
			lvPosts.ItemSelected += LvPosts_ItemSelected;
		}


		void LvPosts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			Post selectedPost = (Post)e.SelectedItem;
			if (selectedPost == null)
			{
				return;
			}
			if (selectedPost.Media_embed.Content != null)
			{
				Navigation.PushAsync(new PostDetailWebview(selectedPost));
				lvPosts.SelectedItem = null;
			}
			else
			{ 
				Navigation.PushAsync(new PostDetailPage(selectedPost));
				lvPosts.SelectedItem = null;
			}

		}






	}
}
