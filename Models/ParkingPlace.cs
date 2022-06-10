using System;
using System.Collections.Generic;

namespace OnlyCarsREST.Models
{
    public partial class ParkingPlace
    {
        public int Id { get; set; }
        public string ParkingNumber { get; set; } = null!;
        public int Level { get; set; }
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public string? CarId { get; set; }
    }
}
