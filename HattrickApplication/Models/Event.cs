using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HattrickApplication.Models
{


    public class Event
    {
        public int ID { get; set; }
        public int SportID { get; set; }
        public virtual Team Home { get; set; }
        public virtual Team Away { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Result { get; set; }
        public decimal T1 { get; set; }
        public decimal T2 { get; set; }
        public decimal TX { get; set; }
        public decimal T1X { get; set; }
        public decimal TX2 { get; set; }
        public decimal T12 { get; set; }
        public bool IsTopEvent { get; set; }
    }
}