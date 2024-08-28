namespace Farmer_Issues.Models
{
    public class ResolvedIssue
    {
        public int Id { get; set; }
        public int IssueId { get; set; }
        public Issue Issue { get; set; }
        public DateTime ResolvedDate { get; set; }
        public string Resolution { get; set; }

        public int FertilizerId { get; set; }

        public Fertilizer Fertilizer { get; set; }
    }

}
