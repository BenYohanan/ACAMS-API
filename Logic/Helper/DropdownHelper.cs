using Core.Db;
using Core.Enum;
using Core.Model;
using Logic.IHelper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Helper
{
    public class DropdownHelper : IDropdownHelper
    {
        private readonly AppDbContext _context;


        public DropdownHelper(AppDbContext context)
        {
            _context = context;

        }

        public async Task<List<Country>> GetCountry()
        {

            var common = new Country()
            {
                Id = 0,
                Name = "-- Select your country --"
            };
            var country = await _context.Country.Where(d => !d.Deleted && d.Id != 0).OrderBy(s => s.Id).ToListAsync();
            country.Insert(0, common);

            return country;
        }

        public async Task<List<State>> GetState()
        {
            var common = new State()
            {
                Id = 0,
                Name = "-- Select --"

            };
            var selectedBranches = await _context.State.OrderBy(x => x.Name).Where(x => x.Active && !x.Deleted).ToListAsync();
            if (selectedBranches != null)
            {
                selectedBranches.Insert(0, common);
                return selectedBranches;
            }
            return null;
        }

        public class DropdownEnumModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public async Task<List<CommonDropdowns>> GetDropdownByKey(DropdownEnums dropdownKey, bool deleteOption = false)
        {

            var common = new CommonDropdowns()
            {
                Id = 0,
                Name = "-- Select --"
            };
            var dropdowns = await _context.CommonDropdowns.Where(s => s.Deleted == deleteOption && s.DropdownKey == (int)dropdownKey).OrderBy(s => s.Name).ToListAsync();
            dropdowns.Insert(0, common);

            return dropdowns;
        }

        public List<DropdownEnumModel> GetDropDownEnumsList()
        {
            var common = new DropdownEnumModel()
            {
                Id = 0,
                Name = "-- Select --"

            };
            var enumList = ((DropdownEnums[])Enum.GetValues(typeof(DropdownEnums))).Select(c => new DropdownEnumModel() { Id = (int)c, Name = c.ToString() }).ToList();
            enumList.Insert(0, common);
            return enumList;
        }

        public async Task<bool> CreateDropdownsAsync(CommonDropdowns commonDropdowns)
        {
            try
            {
                if (commonDropdowns != null && commonDropdowns.DropdownKey > 0 && commonDropdowns.Name != null)
                {
                    CommonDropdowns newCommonDropdowns = new CommonDropdowns
                    {
                        Name = commonDropdowns.Name,
                        DropdownKey = commonDropdowns.DropdownKey,
                        Active = true,
                        Deleted = false,
                        DateCreated = DateTime.Now,
                    };

                    var createdDropdowns = await _context.AddAsync(newCommonDropdowns);
                    await _context.SaveChangesAsync();

                    if (createdDropdowns.Entity.Id > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EditDropdown(CommonDropdowns commonDropdowns)
        {
            try
            {
                var dropdown = _context.CommonDropdowns.Where(c => c.Id == commonDropdowns.Id).FirstOrDefault();
                if (dropdown != null)
                {
                    dropdown.Name = commonDropdowns.Name;
                    _context.Update(dropdown);
                    _context.SaveChanges();

                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DropdownEnumModel GetEnumById(int enumkeyId)
        {
            return ((DropdownEnums[])Enum.GetValues(typeof(DropdownEnums))).Select(c => new DropdownEnumModel() { Id = (int)c, Name = c.ToString() }).Where(x => x.Id == enumkeyId).FirstOrDefault();
        }

        public bool DeleteDropdownById(int id)
        {
            if (id == 0)
            {
                return false;
            }
            var dropdown = _context.CommonDropdowns.Where(d => d.Id == id && d.Active && !d.Deleted).FirstOrDefault();
            if (dropdown != null)
            {
                dropdown.Active = false;
                dropdown.Deleted = true;
                _context.CommonDropdowns.Update(dropdown);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
