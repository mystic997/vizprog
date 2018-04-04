using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtKlub.entity
{
    [Table("TransportDevices")]
    class TransportDevicesEntity
    {
        [Column("transportDeviceId", Order = 0)]
        [DataType("decimal(9, 0)")]
        [Key]
        [Required]
        public int TransportDeviceId { get; set; }

        [Column("transportDeviceName", Order = 1)]
        [StringLength(50)]
        [Required]
        public string TransportDeviceName { get; set; }

        [Column("carryingCapacity", Order = 2)]
        [DataType("decimal(5, 2)")]
        [Required]
        public double CarryingCapacity { get; set; }

        [Column("transportDeviceType", Order = 3)]
        [StringLength(50)]
        [Required]
        public string TransportDeviceType { get; set; }

        [Column("transportDeviceLength", Order = 4)]
        [DataType("decimal(3, 2)")]
        public double TransportDeviceLength { get; set; }

        [Column("transportDeviceWidth", Order = 5)]
        [DataType("decimal(3, 2)")]
        public double TransportDeviceWidth { get; set; }

        /** TO DO: image type needed */
        [Column("transportDeviceImage", Order = 6)]
        public string TransportDeviceImage { get; set; }

        public MembersEntity FKOwner { get; set; }

        public ICollection<BoatRentalsEntity> BoatRentals { get; set; }
        public ICollection<RentRequestsEntity> RentRequests { get; set; }
    }
}
