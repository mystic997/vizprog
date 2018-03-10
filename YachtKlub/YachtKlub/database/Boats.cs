using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtKlub.database
{
    [Table("Boats")]
    class Boats
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

        [Column("dailyPrice", Order = 2)]
        [DataType("decimal(5, 2)")]
        [Required]
        public double DailyPrice { get; set; }

        [Column("maxPerson", Order = 3)]
        [DataType("decimal(3, 0)")]
        [Required]
        public double MaxPerson { get; set; }

        [Column("maxSpeed", Order = 4)]
        [DataType("decimal(3, 0)")]
        public double MaxSpeed { get; set; }

        [Column("consumption", Order = 5)]
        [DataType("decimal(2, 1)")]
        public double Consumption { get; set; }

        [Column("yearOfManufacture", TypeName = "Date", Order = 6)]
        public DateTime YearOfManufacture { get; set; }

        [Column("boatLength", Order = 7)]
        [DataType("decimal(3, 2)")]
        public double BoatLength { get; set; }

        [Column("boatWidth", Order = 8)]
        [DataType("decimal(3, 2)")]
        public double BoatWidth { get; set; }

        [Column("FKmemberId", Order = 9)]
        [DataType("decimal(9, 0)")]
        [Required]
        [ForeignKey("Members")]
        public int MemberId { get; set; }
        public Members Members { get; set; }

        [Column("whereIsNowTheBoat", Order = 10)]
        [StringLength(100)]
        [Required]
        public string WhereIsNowTheBoat { get; set; }

        // TEMPORARILY IT IS A STRING
        [Column("isLoan", Order = 11)]
        [StringLength(5)]
        [Required]
        public string IsLoan { get; set; }

        [Column("image", Order = 12)]
        public string BoatImage { get; set; }
    }
}
