using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
   public class State:BaseModel
    {
        public int? CountryId { get; set; }
        [Display(Name = "Country")]
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
    }
}
