using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Data.Entity;

namespace Farmer_Issues.Models
{
    public class Farmer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        //public List<Farmer> Farmers { get; set; }

    }


}
