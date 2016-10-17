using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.RealEstate.Domain.Entities
{
    public class Broker
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public string Position { get; set; }

        public string OfficePhoneNumber { get; set; }

        public string MobilePhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
