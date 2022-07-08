using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Enum
{
    public enum DropdownEnums
    {
        [Description("For returning Genders")]
        Gender = 1,

        [Description("For returning Religions")]
        Religion = 2,

        [Description("For returning Schools")]
        School = 3,
    }
}
