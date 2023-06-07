using FiveNightsAtFreddy.DataBase;
using FiveNightsAtFreddy.Models;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace FiveNightsAtFreddy.Windows
{
    /// <summary>
    /// Interaction logic for NewReportWindow.xaml
    /// </summary>
    public partial class NewReportWindow : Window
    {
        public NewReportWindow(Models.CameraCameraScreen selectedCamera)
        {
            InitializeComponent();
            var newReport = new Report();
            newReport.CameraScreenId = selectedCamera.ScreenCamera.Id;
            newReport.DateTime = DateTime.Now;
            DataContext = newReport;
            ComboBoxAnimatronic.ItemsSource = GlobalSettings.DB.Animatronic.ToList();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            var report = DataContext as Report;
            var errorMessage = "";
            if (report.ReportMessage == null)
                errorMessage += "Enter report message";
            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                MessageBox.Show(errorMessage);
                return;
            }
            var animatronic = ComboBoxAnimatronic.SelectedItem as Animatronic;
            if (ComboBoxAnimatronic.SelectedItem != null)
                report.ReportedAnimatronicId = animatronic.Id;
            GlobalSettings.DB.Report.Add(report);
            GlobalSettings.DB.SaveChanges();
            this.DialogResult = true;
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
