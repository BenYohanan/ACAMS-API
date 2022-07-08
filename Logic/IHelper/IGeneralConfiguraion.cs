using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.IHelper
{
   public interface IGeneralConfiguraion
    {
         string AdminEmail { get; set; }
         string DeveloperEmail { get; set; }
    }
}
