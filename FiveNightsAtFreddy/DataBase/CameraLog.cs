//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FiveNightsAtFreddy.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class CameraLog
    {
        public int Id { get; set; }
        public int CameraId { get; set; }
        public System.DateTime DateTime { get; set; }
    
        public virtual Camera Camera { get; set; }
    }
}
