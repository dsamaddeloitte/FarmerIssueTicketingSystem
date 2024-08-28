namespace Farmer_Issues.Models
{
    public class Issue
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int FarmerId { get; set; }
        
        public DateTime CreatedAt { get; set; }

        public bool IsResolved { get; set; }

        public int? FertilizerId { get; set; }
       
    }


}
