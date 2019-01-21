using System;
using System.ComponentModel.DataAnnotations;

namespace HattrickApplication.Entities
{


    public class Event
    {
        public int Id { get; set; }
        public int SportId { get; set; }
        public int HomeId { get; set; }
        public int AwayId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Result { get; set; }
        public decimal Tip1 { get; set; }
        public decimal Tip2 { get; set; }
        public decimal TipX { get; set; }
        public decimal Tip1X { get; set; }
        public decimal TipX2 { get; set; }
        public decimal Tip12 { get; set; }
        public bool IsTopEvent { get; set; }

        public virtual Sport Sport { get; set; }
        public virtual Team Home { get; set; }
        public virtual Team Away { get; set; }
    }
}