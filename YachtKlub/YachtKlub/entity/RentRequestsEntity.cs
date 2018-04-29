using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtKlub.entity
{
    [Table("RentRequests")]
    class RentRequestsEntity
    {
        [Column("boatRentalsId", Order = 0)]
        [StringLength(150)]
        [Key]
        [Required]
        public string BoatRentalsId { get; set; }
        [Column("startingDate", TypeName = "Date", Order = 2)]

        public DateTime StartingDate { get; set; }



        [Column("endDate", TypeName = "Date", Order = 1)]
        [Key]
        [Required]
        public DateTime EndDate { get; set; }

        public BoatsEntity BoatToBorrow { get; set; }
        public TransportDevicesEntity DeviceToBorrow { get; set; }

        public MembersEntity WhoBorrows { get; set; }

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

        [Column("status", Order = 7)]
        [DataType("decimal(1, 0)")]
        [Required]
        public int Status { get; set; }
    }
}
