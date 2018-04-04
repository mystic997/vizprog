﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtKlub.entity
{
    [Table("BoatRentals")]
    class BoatRentalsEntity
    {
        [Column("startingDate", TypeName = "Date", Order = 0)]
        [Key]
        [Required]
        public DateTime StartingDate { get; set; }

        [Key]
        public BoatsEntity FKRentedBoat { get; set; }

        public TransportDevicesEntity FKRentedDevice { get; set; }

        public MembersEntity FKWhoRents { get; set; }

        [Column("howManyPersonWillTravel", Order = 3)]
        [DataType("decimal(3, 0)")]
        [Required]
        public int HowManyPersonWillTravel { get; set; }

        [Column("fromWhere", Order = 4)]
        [StringLength(100)]
        [Required]
        public string FromWhere { get; set; }

        [Column("toWhere", Order = 5)]
        [StringLength(100)]
        [Required]
        public string ToWhere { get; set; }

        [Column("endDate", TypeName = "Date", Order = 6)]
        [Required]
        public DateTime EndDate { get; set; }
    }
}
