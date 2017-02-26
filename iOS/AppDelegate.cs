using System;
using System.Collections.Generic;
using System.Linq;
using FreshEssentials.iOS;

using Foundation;
using UIKit;

namespace XRedditReaderV4.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();

			LoadApplication(new App());

			//Inicializa o Bindable Picker
			new FreshEssentials.iOS.AdvancedFrameRendereriOS();

			return base.FinishedLaunching(app, options);
		}
	}
}
