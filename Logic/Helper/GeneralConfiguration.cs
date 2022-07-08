using Logic.IHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Helper
{
   public class GeneralConfiguration: IGeneralConfiguraion
    {
        public string AdminEmail { get; set; }
        public string DeveloperEmail { get; set; }
    }
}
