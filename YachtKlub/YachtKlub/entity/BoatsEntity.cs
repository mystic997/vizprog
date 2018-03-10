using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtKlub.entity
{
    [Table("Boats")]
    class BoatsEntity
    {
        [Column("boatId", Order = 0)]
        [DataType("decimal(9, 0)")]
        [Key]
        [Required]
        public int BoatId { get; set; }

        [Column("boatName", Order = 1)]
        [StringLength(50)]
        [Required]
        public string BoatName { get; set; }

        [Column("boatType", Order = 2)]
        [StringLength(30)]
        public string BoatType { get; set; }

        [Column("dailyPrice", Order = 3)]
        [DataType("decimal(5, 2)")]
        [Required]
        public double DailyPrice { get; set; }

        public MembersEntity FKOwner { get; set; }

        [Column("whereIsNowTheBoat", Order = 5)]
        [StringLength(100)]
        [Required]
        public string WhereIsNowTheBoat { get; set; }

        /** TO DO: TEMPORARILY IT IS A STRING, MUST BE A BOOL TYPE */
        [Column("isLoan", Order = 6)]
        [StringLength(5)]
        [Required]
        public string IsLoan { get; set; }

        [Column("maxPerson", Order = 7)]
        [DataType("decimal(3, 0)")]
        [Required]
        public int MaxPerson { get; set; }

        [Column("maxSpeed", Order = 8)]
        [DataType("decimal(3, 0)")]
        public double MaxSpeed { get; set; }

        [Column("diveDepth", Order = 9)]
        [DataType("decimal(5, 2)")]
        public double DiveDepth { get; set; }

        [Column("consumption", Order = 10)]
        [DataType("decimal(2, 1)")]
        public double Consumption { get; set; }

        [Column("yearOfManufacture", TypeName = "Date", Order = 11)]
        public DateTime YearOfManufacture { get; set; }

        [Column("boatLength", Order = 12)]
        [DataType("decimal(3, 2)")]
        public double BoatLength { get; set; }

        [Column("boatWidth", Order = 13)]
        [DataType("decimal(3, 2)")]
        public double BoatWidth { get; set; }

        /** TO DO: image type needed */
        [Column("boatImage", Order = 14)]
        public string BoatImage { get; set; }

        public ICollection<BoatRentalsEntity> BoatRentals { get; set; }
        public ICollection<RentRequestsEntity> RentRequests { get; set; }
        public ICollection<RentRequests> RentRequests { get; set; }
    }
}
