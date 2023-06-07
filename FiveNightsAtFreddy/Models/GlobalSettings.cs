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
    }
}
