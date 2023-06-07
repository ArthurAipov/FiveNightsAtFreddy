using FiveNightsAtFreddy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FiveNightsAtFreddy.DataBase
{
    public partial class Report
    {
        public string AnimatronicName
        {
            get
            {
                var animatronicId = ReportedAnimatronicId;
                var animatronic = GlobalSettings.DB.Animatronic.FirstOrDefault(u => u.Id == animatronicId);
                if (animatronic != null)
                {
                    return animatronic.Name;
                }
                else
                {
                    return "animatronic missing";
                }
            }
        }
            
        public SolidColorBrush BackGroundReport
        {
            get
            {
                var reportedAnimatronic = ReportedAnimatronicId;
                var animatronicFromScreen = CameraScreen.AnimatronicId;
                if(reportedAnimatronic != animatronicFromScreen)
                {
                    return new SolidColorBrush(Colors.MediumVioletRed);
                }
                else
                {
                    return new SolidColorBrush(Colors.LightGreen);
                }
            }
        }


    }
}
