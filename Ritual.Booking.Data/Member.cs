
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
    
public partial class Member
{

    public Member()
    {

        this.SessionBookings = new HashSet<SessionBooking>();

        this.Memberships = new HashSet<Membership>();

        this.QuarterlyAssessments = new HashSet<QuarterlyAssessment>();

    }


    public int Id { get; set; }

    public string IdentificationNumber { get; set; }

    public Nullable<bool> EmailOptOut { get; set; }

    public int HomeLocationId { get; set; }

    public string AspNetUserId { get; set; }



    public virtual Location Location { get; set; }

    public virtual ICollection<SessionBooking> SessionBookings { get; set; }

    public virtual ICollection<Membership> Memberships { get; set; }

    public virtual ICollection<QuarterlyAssessment> QuarterlyAssessments { get; set; }

    public virtual AspNetUser AspNetUser { get; set; }

}

}
