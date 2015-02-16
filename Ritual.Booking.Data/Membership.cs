
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
    
public partial class Membership
{

    public Membership()
    {

        this.MembershipSuspensions = new HashSet<MembershipSuspension>();

    }


    public int Id { get; set; }

    public int MemberId { get; set; }

    public int PackageId { get; set; }

    public System.DateTime StartDate { get; set; }

    public System.DateTime EndDate { get; set; }

    public bool Trial { get; set; }

    public int MembershipStateId { get; set; }

    public Nullable<System.DateTime> CancellationDate { get; set; }

    public bool Paid { get; set; }

    public Nullable<System.DateTime> InitialPaymentDate { get; set; }

    public Nullable<decimal> InitialPayment { get; set; }

    public Nullable<decimal> MonthlyPrice { get; set; }

    public Nullable<decimal> TotalPrice { get; set; }

    public Nullable<decimal> DiscountPercentage { get; set; }

    public Nullable<decimal> DiscountPrice { get; set; }

    public string DiscountReason { get; set; }



    public virtual MembershipState MembershipState { get; set; }

    public virtual ICollection<MembershipSuspension> MembershipSuspensions { get; set; }

    public virtual Member Member { get; set; }

    public virtual Package Package { get; set; }

}

}
