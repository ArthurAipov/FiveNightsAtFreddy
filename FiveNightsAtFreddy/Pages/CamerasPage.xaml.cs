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
            var camera = GlobalSettings.DB.Camera.ToList()[0];
                var screens = GlobalSettings.DB.CameraScreen.Where(u => u.CameraId == camera.Id).ToList();
            CameraList[0] = new CameraCameraScreen { Id = 1, ScreenCamera = screens[new Random().Next(0, screens.Count - 1)], CameraForListView = camera };
            Refresh();
        }

        private void TimerForSecondCamera_Tick(object sender, EventArgs e)
        {
            var camera = GlobalSettings.DB.Camera.ToList()[1];
            var screens = GlobalSettings.DB.CameraScreen.Where(u => u.CameraId == camera.Id).ToList();
            CameraList[1] = new CameraCameraScreen { Id = 2, ScreenCamera = screens[new Random().Next(0, screens.Count - 1)], CameraForListView = camera };

            Refresh();
        }

        private void TimerForThirdCamera_Tick(object sender, EventArgs e)
        {
            var camera = GlobalSettings.DB.Camera.ToList()[2];
            var screens = GlobalSettings.DB.CameraScreen.Where(u => u.CameraId == camera.Id).ToList();
            CameraList[2] = new CameraCameraScreen { Id = 3, ScreenCamera = screens[new Random().Next(0, screens.Count - 1)], CameraForListView = camera };
            Refresh();
        }

        public void Refresh()
        {
            if (CameraList.Count == 0)
            {
                var screens = GlobalSettings.DB.CameraScreen.ToList();

                CameraList.Add(new CameraCameraScreen { Id = 1, ScreenCamera = screens.Where(u => u.CameraId == GlobalSettings.DB.Camera.ToList()[0].Id).ToList()[new Random().Next(0, screens.Where(u => u.CameraId == GlobalSettings.DB.Camera.ToList()[0].Id).ToList().Count - 1)], CameraForListView = GlobalSettings.DB.Camera.ToList()[0] });
                CameraList.Add(new CameraCameraScreen { Id = 2, ScreenCamera = screens.Where(u => u.CameraId == GlobalSettings.DB.Camera.ToList()[1].Id).ToList()[new Random().Next(0, screens.Where(u => u.CameraId == GlobalSettings.DB.Camera.ToList()[1].Id).ToList().Count - 1)], CameraForListView = GlobalSettings.DB.Camera.ToList()[1] });
                CameraList.Add(new CameraCameraScreen { Id = 3, ScreenCamera = screens.Where(u => u.CameraId == GlobalSettings.DB.Camera.ToList()[2].Id).ToList()[new Random().Next(0, screens.Where(u => u.CameraId == GlobalSettings.DB.Camera.ToList()[2].Id).ToList().Count - 1)], CameraForListView = GlobalSettings.DB.Camera.ToList()[2] });
            }
            CameraList.OrderBy(u => u.CameraForListView.Description).ToList();
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
