
using BusinessObjectLayer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Access
{
    public class EntryDAL
    {
       
        private readonly AppDbContext _appDb;
        public EntryDAL(AppDbContext appDb)
        {           
            _appDb = appDb;
        }

        public TimeEntry GetEntry(string id)
        {
            var entries = _appDb.Entries.Find(id);

            return entries;
        }

        public List<TimeEntry> GetEntry()
        {
            var entries = _appDb.Entries.ToList();

            return entries;
        }

        public void SetEntry(TimeEntry entry)
        {
            _appDb.Entries.Add(entry);
        }

        public void SetBreak(IList<Break> brks)
        {

            foreach (var brk in brks)
            {
                _appDb.Breaks.Add(brk);
            }
        }

    }
}
