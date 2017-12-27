using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using Core.DTO;

namespace Core.DAO
{
    public class QLNVU
    {
        private static TourEntities db = new TourEntities();
        public static List<NHIEMVU> load()
        {
            return db.NHIEMVUs.ToList();
        }
        
        public static void them(NHIEMVU k)
        {
            db.NHIEMVUs.Add(k);
            db.SaveChanges();
        }
        public static void sua(NHIEMVU k)
        {
            var dd = db.NHIEMVUs.Find(k.ID);
            db.Entry(dd).CurrentValues.SetValues(k);
            db.SaveChanges();
        }
        public static NHIEMVU find(int id)
        {
            return db.NHIEMVUs.Find(id);
        }
    }
}
