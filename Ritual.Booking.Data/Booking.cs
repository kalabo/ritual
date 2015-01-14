//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ritual.Booking.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Booking
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int LocationId { get; set; }
        public System.DateTime Date { get; set; }
        public int BookingStateId { get; set; }
        public int RPEFeeling { get; set; }
        public int RPEPush { get; set; }
        public string TrainerNotes { get; set; }
        public int TrainerId { get; set; }
        public int TimeSlotId { get; set; }
    
        public virtual BookingState BookingState { get; set; }
        public virtual Location Location { get; set; }
        public virtual Member Member { get; set; }
        public virtual TimeSlot TimeSlot { get; set; }
    }
}
