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
            return db.DOANs.Include(s=>s.TOUR).ToList();
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
            var dd = db.DOANs.Find(d.ID);
            db.Entry(dd).CurrentValues.SetValues(d);
            db.SaveChanges();
        }
        public static void them(DATTOUR dt)
        {
            db.DATTOURs.Add(dt);
            db.SaveChanges();
        }
        
        public static void xoa(int id)
        {
            var dt = db.DATTOURs.Find(id);
            db.DATTOURs.Remove(dt);
            db.SaveChanges();
        }
        public static DATTOUR finddt(int id)
        {
            return db.DATTOURs.Find(id);
        }
        public static DOAN findd(int id)
        {
            return db.DOANs.Find(id);
        }
        public static List<CTCHIP> loadcp(int id)
        {
            return db.CTCHIPs.Where(s => s.IDDOAN == id).ToList();
        }
        public static void them(CTCHIP ct)
        {
            db.CTCHIPs.Add(ct);
            db.SaveChanges();
            var x = db.DOANs.Find(ct.IDDOAN);
            x.CHIPHI += ct.SOTIEN;
            db.Entry(x).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
