using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using Core.DTO;

namespace Core.DAO
{
    public class QLKHACH
    {
        private static TourEntities db = new TourEntities();
        public static List<KHACHHANG> load()
        {
            return db.KHACHHANGs.ToList();
        }
        
        public static void them(KHACHHANG k)
        {
            db.KHACHHANGs.Add(k);
            db.SaveChanges();
        }
        public static void sua(KHACHHANG k)
        {
            db.Entry(k).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
