using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace coderush.Models
{
    public class Areas
    {
        [Key]
        public int AreaID { get; set; }
        public string Area { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }

    }
}
