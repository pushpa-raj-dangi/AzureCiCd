using System;
using System.Linq;

namespace CandidateApp.Domain.Entities
{
    public sealed class Candidate
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; } 
        public string CallTimeInterval { get; set; }
        public string LinkedInUrl { get; set; }
        public string GitHubUrl { get; set; }
        public string Comments { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
