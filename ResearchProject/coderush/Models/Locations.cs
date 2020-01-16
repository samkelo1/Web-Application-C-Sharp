using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace coderush.Models
{
    public class Locations
    {
        [Key]
        public int LocationId { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string Details { get; set; }
        public int AreaId { get; set; }
    }
}
