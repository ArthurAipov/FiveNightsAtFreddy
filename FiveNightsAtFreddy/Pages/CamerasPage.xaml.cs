using FiveNightsAtFreddy.Models;
using FiveNightsAtFreddy.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace FiveNightsAtFreddy.Pages
{
    /// <summary>
    /// Interaction logic for CamerasPage.xaml
    /// </summary>
    public partial class CamerasPage : Page
    {
        public ObservableCollection<CameraCameraScreen> CameraList = new ObservableCollection<CameraCameraScreen>();
        public Random random = new Random();
        public CamerasPage()
        {
            InitializeComponent();
            var timerForFirstCamera = new DispatcherTimer();
            var timerForSecondCamera = new DispatcherTimer();
            var timerForThirdCamera = new DispatcherTimer();
            timerForFirstCamera.Tick += TimerForFirstCamera_Tick;
            timerForSecondCamera.Tick += TimerForSecondCamera_Tick;
            timerForThirdCamera.Tick += TimerForThirdCamera_Tick;
            timerForFirstCamera.Interval = new TimeSpan(0, 0, GlobalSettings.DB.Camera.ToList()[0].Frequency);
            timerForSecondCamera.Interval = new TimeSpan(0, 0, GlobalSettings.DB.Camera.ToList()[1].Frequency);
            timerForThirdCamera.Interval = new TimeSpan(0, 0, GlobalSettings.DB.Camera.ToList()[2].Frequency);
            timerForFirstCamera.Start();
            timerForThirdCamera.Start();
            timerForSecondCamera.Start();
            Refresh();

        }

        private void TimerForFirstCamera_Tick(object sender, EventArgs e)
        {
            var screenForFirstCamera = GlobalSettings.ScreensForFirst[random.Next(0, GlobalSettings.ScreensForFirst.Count - 1)];
            CameraList[0] = new CameraCameraScreen { Id = 2, ScreenCamera = screenForFirstCamera, CameraForListView = GlobalSettings.DB.Camera.ToList()[1] };
            Refresh();
        }

        private void TimerForSecondCamera_Tick(object sender, EventArgs e)
        {
            var screenForSecondCamera = GlobalSettings.ScreensForSecond[random.Next(0, GlobalSettings.ScreensForSecond.Count - 1)];
            CameraList[0] = new CameraCameraScreen { Id = 2, ScreenCamera = screenForSecondCamera, CameraForListView = GlobalSettings.DB.Camera.ToList()[1] };
            Refresh();
        }

        private void TimerForThirdCamera_Tick(object sender, EventArgs e)
        {
            var screenForThirdCamera = GlobalSettings.ScreensForThird[random.Next(0, GlobalSettings.ScreensForThird.Count - 1)];
            CameraList[0] = new CameraCameraScreen { Id = 3, ScreenCamera = screenForThirdCamera, CameraForListView = GlobalSettings.DB.Camera.ToList()[2] };
            Refresh();
        }

        public void Refresh()
        {
            if (CameraList.Count == 0)
            {
                var screenForFirstCamera = GlobalSettings.ScreensForFirst[random.Next(0, GlobalSettings.ScreensForFirst.Count - 1)];
                var screenForSecondCamera = GlobalSettings.ScreensForSecond[random.Next(0, GlobalSettings.ScreensForSecond.Count - 1)];
                var screenForThirdCamera = GlobalSettings.ScreensForThird[random.Next(0, GlobalSettings.ScreensForThird.Count - 1)];
                CameraList.Add(new CameraCameraScreen { Id = 1, ScreenCamera = screenForFirstCamera, CameraForListView = GlobalSettings.DB.Camera.ToList()[0] });
                CameraList.Add(new CameraCameraScreen { Id = 2, ScreenCamera = screenForSecondCamera, CameraForListView = GlobalSettings.DB.Camera.ToList()[1] });
                CameraList.Add(new CameraCameraScreen { Id = 3, ScreenCamera = screenForThirdCamera, CameraForListView = GlobalSettings.DB.Camera.ToList()[2] });

            }
            ListViewCameras.ItemsSource = CameraList;
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ListViewCameras_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedCamera = ListViewCameras.SelectedItem as CameraCameraScreen;
            if (selectedCamera == null)
            {
                MessageBox.Show("Select camera");
                return;
            }
            new NewReportWindow(selectedCamera).ShowDialog();
        }
    }
}
