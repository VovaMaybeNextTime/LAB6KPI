using System;
using System.Collections.Generic;

#nullable disable

namespace lab6
{
    public partial class Weather
    {
        public string City { get; set; }
        public int? TempLo { get; set; }
        public int? TempHi { get; set; }
        public float? Prcp { get; set; }
        public DateTime? Date { get; set; }
    }
}
