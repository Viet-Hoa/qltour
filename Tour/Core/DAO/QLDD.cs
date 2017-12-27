using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using Core.DTO;

namespace Core.DAO
{
    public class QLDD
    {
        private static TourEntities db = new TourEntities();
        public static List<CTDD> load()
        {
            return db.CTDDs.ToList();
        }
        public static void them(CTDD d)
        {
            db.CTDDs.Add(d);
            db.SaveChanges();
        }
        public static void sua(CTDD d)
        {
            var dd = db.CTDDs.Find(d.ID);
            db.Entry(dd).CurrentValues.SetValues(d);
            db.SaveChanges();
        }
        
        public static CTDD find(int id)
        {
            return db.CTDDs.Find(id);
        }
    }
}
