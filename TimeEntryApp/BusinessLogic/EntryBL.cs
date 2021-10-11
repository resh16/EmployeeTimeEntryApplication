using BusinessObjectLayer.Models;
using DataAccessLayer.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class EntryBL
    {
        private readonly EntryDAL _entryDAL;
        public EntryBL(EntryDAL entryDAL)
        {
            this._entryDAL = entryDAL;
        }

        public TimeEntry GetEntry(string id)
        {
            var entries = _entryDAL.GetEntry(id);

            return entries;
        }

        public List<TimeEntry> GetEntry()
        {
            var entries = _entryDAL.GetEntry();

            return entries;
        }

        public void CreateEntry(ApplicationUser user, TimeEntry entry)
        {
            _entryDAL.CreateEntry(user, entry);
        }

        //Creating Break
        public void CreateBreak(ApplicationUser user, int id, Break @break)
        {
            _entryDAL.CreateBreak(user, id, @break);

        }

        public void DeleteEntry(ApplicationUser user, int? id)
        {
            _entryDAL.DeleteEntry(user, id);
        }

        public void DeleteBreak(ApplicationUser user, int? id)
        {
            _entryDAL.DeleteBreak(user, id);
        }

        public List<TimeEntry> GetId(ApplicationUser user)
        {
            var result = _entryDAL.GetId(user).ToList();
            return result;
        }

        public List<TimeEntry> GetMonth(ApplicationUser user, DateTime monthValue)
        {
            var result = _entryDAL.GetMonth(user, monthValue).ToList();
            return result;
        }
    }
}