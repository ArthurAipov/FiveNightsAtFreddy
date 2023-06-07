using FiveNightsAtFreddy.DataBase;
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
        List<CameraCameraScreen> CameraList = new List<CameraCameraScreen>();
        Random random = new Random();
        Dictionary<DispatcherTimer, Camera> dispatchers = new Dictionary<DispatcherTimer, Camera>();

        public CamerasPage()
        {
            InitializeComponent();
            CameraList = new List<CameraCameraScreen>();
            foreach (var camera in GlobalSettings.DB.Camera)
            {
                CameraList.Add(new CameraCameraScreen() { CameraForListView = camera, ScreenCamera = camera.CameraScreen.FirstOrDefault() });
                InitializeCameraObserve(camera);
            }
            ListViewCameras.ItemsSource = CameraList;
        }

        private void InitializeCameraObserve(Camera camera)
        {
            var dispatcherTimer = new DispatcherTimer();
            dispatchers.Add(dispatcherTimer, camera);
            dispatcherTimer.Interval = TimeSpan.FromSeconds(camera.Frequency);
            dispatcherTimer.Tick += CameraObserve_Tick;
            dispatcherTimer.Start();
        }

        private void CameraObserve_Tick(object sender, EventArgs e)
        {
            var dispatcherTimer = sender as DispatcherTimer;
            var camera = dispatchers[dispatcherTimer];
            var screen = camera.CameraScreen.ToList()[random.Next(0, camera.CameraScreen.Count)];
            CameraList.FirstOrDefault(f => f.CameraForListView == camera).ScreenCamera = screen;
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
