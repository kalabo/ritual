
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
    
public partial class Trainer
{

    public Trainer()
    {

        this.QuarterlyAssessments = new HashSet<QuarterlyAssessment>();

    }


    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string AspNetUserId { get; set; }

    public int LocationId { get; set; }



    public virtual AspNetUser AspNetUser { get; set; }

    public virtual Location Location { get; set; }

    public virtual Location Location1 { get; set; }

    public virtual ICollection<QuarterlyAssessment> QuarterlyAssessments { get; set; }

}

}
