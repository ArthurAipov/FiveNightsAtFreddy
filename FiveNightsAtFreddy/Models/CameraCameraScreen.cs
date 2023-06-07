using FiveNightsAtFreddy.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveNightsAtFreddy.Models
{
    public class CameraCameraScreen
    {
        public int Id { get; set; }
        public Camera CameraForListView { get; set; }   
        public CameraScreen ScreenCamera { get; set; }
    }
}
