using FiveNightsAtFreddy.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveNightsAtFreddy.Models
{
    public static class GlobalSettings
    {
        public static FiveNightAtFreddyEntities DB = new FiveNightAtFreddyEntities();
        public static List<CameraScreen> ScreensForThird = DB.CameraScreen.Where(u => u.CameraId == 3).ToList();
        public static List<CameraScreen> ScreensForFirst = DB.CameraScreen.Where(u => u.CameraId == 1).ToList();
        public static List<CameraScreen> ScreensForSecond = DB.CameraScreen.Where(u => u.CameraId == 2).ToList();
    }
}
