using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HattrickApplication.Interfaces
{
    interface IEvent
    {
        int ID { get; set; }
        int SportID { get; set; }
        string Home { get; set; }
        string Away { get; set; }
        DateTime Start { get; set; }
        DateTime End { get; set; }
        string Result { get; set; }
        decimal T1 { get; set; }
        decimal T2 { get; set; }
        decimal TX { get; set; }
        decimal T1X { get; set; }
        decimal TX2 { get; set; }
        decimal T12 { get; set; }
    }
}
