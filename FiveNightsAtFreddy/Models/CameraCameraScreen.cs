using FiveNightsAtFreddy.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FiveNightsAtFreddy.Models
{
    public class CameraCameraScreen    
    {
        public int Id { get; set; }
        public Camera CameraForListView { get; set; }
        
        CameraScreen screenCamera;
        public CameraScreen ScreenCamera 
        {
            get
            {
                return screenCamera;
            }

            set
            {
                screenCamera = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
