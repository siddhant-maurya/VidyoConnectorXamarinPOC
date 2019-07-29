using System.Diagnostics;
using Xamarin.Forms;

namespace VidyoConnector
{
    public partial class App : Application
    {
        IVidyoController _vidyoController = null;

        // Need this in order to see preview in App.xaml interface builder
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }

        public App(IVidyoController vidyoController)
        {
            InitializeComponent();
            MainPage mp = new MainPage();
            mp.Initialize(vidyoController);
            MainPage = mp;
            _vidyoController = vidyoController;
        }
        public App(IVidyoController vidyoController,IncomingCallScreen incomingCallScreen)
        {
            InitializeComponent();
            _vidyoController = vidyoController;
            MainPage = incomingCallScreen;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            Debug.WriteLine("OnStart");
            ViewModel.GetInstance().ClientVersion = "v " + _vidyoController.OnAppStart();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            Debug.WriteLine("OnSleep");
            _vidyoController.OnAppSleep();
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
            Debug.WriteLine("OnResume");
            _vidyoController.OnAppResume();
        }
    }
}
