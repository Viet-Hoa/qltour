using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using Core.DTO;

namespace Core.DAO
{
    public class QLDOAN
    {
        private static TourEntities db = new TourEntities();
        public static List<DOAN> load()
        {
            return db.DOANs.ToList();
        }
        public static List<DATTOUR> load(int id)
        {
            return db.DATTOURs.Include(s => s.KHACHHANG).Where(s => s.IDDOAN == id).ToList();            
        }
        public static void them(DOAN d)
        {
            db.DOANs.Add(d);
            db.SaveChanges();
        }
        public static void sua(DOAN d)
        {
            db.Entry(d).State = EntityState.Modified;
            db.SaveChanges();
        }
        public static void them(DATTOUR dt)
        {
            db.DATTOURs.Add(dt);
            db.SaveChanges();
        }
        public static void sua(DATTOUR dt)
        {
            db.Entry(dt).State = EntityState.Modified;
            db.SaveChanges();
        }
        public static void xoa(int id)
        {
            var dt = db.DATTOURs.Find(id);
            db.DATTOURs.Remove(dt);
            db.SaveChanges();
        }
        public static DOAN findd(int id)
        {
            return db.DOANs.Find(id);
        }
    }
}
