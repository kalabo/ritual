//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ritual.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public Employee()
        {
            this.ClientIssuesFeedbacks = new HashSet<ClientIssuesFeedback>();
            this.InitialAssessments = new HashSet<InitialAssessment>();
            this.QuarterlyAssessments = new HashSet<QuarterlyAssessment>();
        }
    
        public int Id { get; set; }
        public string IdentificationNumber { get; set; }
        public string AspNetUserId { get; set; }
        public int HomeLocationId { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual ICollection<ClientIssuesFeedback> ClientIssuesFeedbacks { get; set; }
        public virtual ICollection<InitialAssessment> InitialAssessments { get; set; }
        public virtual ICollection<QuarterlyAssessment> QuarterlyAssessments { get; set; }
        public virtual Location Location { get; set; }
    }
}
