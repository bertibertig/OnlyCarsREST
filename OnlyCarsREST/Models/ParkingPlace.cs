using System;
using System.Collections.Generic;

namespace OnlyCarsREST.Models
{
    public partial class ParkingPlace
    {
        public int Id { get; set; }
        public string ParkingNumber { get; set; } = null!;
        public int Level { get; set; }
        public int? Ldx { get; set; }
        public int? Ldy { get; set; }
        public int? CarId { get; set; }
        public int Occupied { get; set; }
        public int? Urx { get; set; }
        public int? Ury { get; set; }
    }
}
