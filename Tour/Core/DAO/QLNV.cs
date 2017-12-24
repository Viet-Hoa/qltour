using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTO;
using System.Data.Entity;

namespace Core.DAO
{
    public class QLNV
    {
        private static TourEntities db = new TourEntities();
        public static List<NHANVIEN> load()
        {
            return db.NHANVIENs.ToList();
        }
        public static void them(NHANVIEN nv)
        {
            db.NHANVIENs.Add(nv);
            db.SaveChanges();
        }
        public static void sua(NHANVIEN nv)
        {
            var dd = db.NHANVIENs.Find(nv.ID);
            db.Entry(dd).CurrentValues.SetValues(nv);
            db.SaveChanges();
        }
        public static List<PHANCONG> load(int id)
        {
            return db.PHANCONGs.Include(s => s.DOAN).Include(s=>s.NHIEMVU).Where(s => s.IDNV == id).OrderByDescending(s=>s.ID).ToList();
        }
        public static int demtour(int id, DateTime tu, DateTime den)
        {
            var dt = db.PHANCONGs.Include(s => s.DOAN).Where(s => s.IDNV == id && s.DOAN.NGAYBD >= tu && s.DOAN.NGAYKT <= den).Select(s => s.IDDOAN).Distinct();
            return dt.Count();
        }
        public static void them(PHANCONG pc)
        {
            db.PHANCONGs.Add(pc);
            db.SaveChanges();
        }
        
        public static NHANVIEN findnv(int id)
        {
            return db.NHANVIENs.Find(id);
        }
        public static List<NHIEMVU> loadnv()
        {
            return db.NHIEMVUs.ToList();
        }
    }
}
