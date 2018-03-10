﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtKlub.database
{
    [Table("Rentals")]
    class RentRequests
    {
        [Column("startingDate", TypeName = "Date", Order = 0)]
        [Key]
        [Required]
        public DateTime StartingDate { get; set; }

        [Column("endDate", TypeName = "Date", Order = 1)]
        [Key]
        [Required]
        public DateTime EndDate { get; set; }

        public Boats BoatToBorrow { get; set; }
        public TransportDevices DeviceToBorrow { get; set; }

        public Members WhoBorrows { get; set; }

        [Column("howManyPersonWillTravel", Order = 4)]
        [DataType("decimal(3, 0)")]
        [Required]
        public int HowManyPersonWillTravel { get; set; }

        [Column("fromWhere", Order = 5)]
        [StringLength(100)]
        [Required]
        public string FromWhere { get; set; }

        [Column("toWhere", Order = 6)]
        [StringLength(100)]
        [Required]
        public string ToWhere { get; set; }
    }
}