using Xamarin.Forms;

namespace XRedditReaderV4
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new MainPage())
			{
				BarBackgroundColor = Color.FromHex("#d38f29"),
				BarTextColor = Color.White,
				Title = "Reddit"
			};
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
