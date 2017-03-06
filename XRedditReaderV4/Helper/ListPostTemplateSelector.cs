using System;
using Xamarin.Forms;

namespace XRedditReaderV4
{
	public class ListPostTemplateSelector : DataTemplateSelector
	{
		public DataTemplate VideoTemplate
		{
			get;
			set;
		}

		public DataTemplate ImageTemplate
		{
			get;
			set;
		}

		protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
		{
			return ((Post)item).Media_embed == null ? ImageTemplate : VideoTemplate;
		}
	}
}
