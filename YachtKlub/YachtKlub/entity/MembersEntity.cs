using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtKlub.entity
{
    [Table("Members")]
    class MembersEntity
    {
        [Column("memberId", Order = 0)]
        [DataType("decimal(9, 0)")]
        [Key]
        [Required]
        public int MemberId { get; set; }

        [Column("permission", Order = 1)]
        [DataType("decimal(1, 0)")]
        [Required]
        public int Permission { get; set; }

        [Column("email", Order = 2)]
        [StringLength(50)]
        [Index(IsUnique = true)]
        [Required]
        public string Email { get; set; }

        [Column("password", Order = 3)]
        [StringLength(40)]
        [Required]
        public string Password { get; set; }

        [Column("memberName", Order = 4)]
        [StringLength(50)]
        [Required]
        public string MemberName { get; set; }

        [Column("country", Order = 5)]
        [StringLength(100)]
        public string Country { get; set; }

        [Column("city", Order = 6)]
        [StringLength(100)]
        public string City { get; set; }

        [Column("street", Order = 7)]
        [StringLength(100)]
        public string Street { get; set; }

        [Column("houseNumber", Order = 8)]
        [StringLength(20)]
        public string HouseNumber { get; set; }

        [Column("memberImage", Order = 9)]
        [StringLength(50)]
        public string MemberImage { get; set; }

        public ICollection<RentRequestsEntity> RentRequests { get; set; }
        public ICollection<BoatsEntity> Boats { get; set; }
        public ICollection<TransportDevicesEntity> TransportDevices { get; set; }
        public ICollection<BoatRentalsEntity> BoatRentals { get; set; }
    }
}
