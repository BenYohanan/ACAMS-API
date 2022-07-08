using Core.Enum;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Logic.Helper.DropdownHelper;

namespace Logic.IHelper
{
    public interface IDropdownHelper
    {
        Task<List<Country>> GetCountry();
        Task<List<State>> GetState();
        Task<List<CommonDropdowns>> GetDropdownByKey(DropdownEnums dropdownKey, bool deleteOption = false);
        List<DropdownEnumModel> GetDropDownEnumsList();
        Task<bool> CreateDropdownsAsync(CommonDropdowns commonDropdowns);
        bool EditDropdown(CommonDropdowns commonDropdowns);
        DropdownEnumModel GetEnumById(int enumkeyId);
        bool DeleteDropdownById(int id);
    }
}
