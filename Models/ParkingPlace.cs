using System;
using System.Collections.Generic;

namespace OnlyCarsREST.Models
{
    public partial class ParkingPlace
    {
        public int Id { get; set; }
        public string ParkingNumber { get; set; } = null!;
        public int Level { get; set; }
        public decimal Ldx { get; set; }
        public decimal Ldy { get; set; }
        public string? CarId { get; set; }
        public decimal Occupied { get; set; }
        public decimal Urx { get; set; }
        public decimal Ury { get; set; }
    }
}
