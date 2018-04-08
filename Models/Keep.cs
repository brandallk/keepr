using System.Collections.Generic;

namespace keepr.Models
{
    public class Keep
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public string ImageUrl { get; set; }
        public string Link { get; set; }
        public int Public { get; set; } = 0; // Simulate a bool for MySQL TINYINT(1)
        public int KeepCount { get; set; }
        public int ShareCount { get; set; }
        public int ViewCount { get; set; }
    }
}