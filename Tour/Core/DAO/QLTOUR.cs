using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTO;
using System.Data.Entity;

namespace Core.DAO
{
    public class QLTOUR
    {
        private static TourEntities db = new TourEntities();
        public static List<TOUR> load()
        {
            return db.TOURs.ToList();
        }
        public static List<CTDD> loaddd()
        {
            return db.CTDDs.ToList();
        }
        public static List<DIADIEM> load(int id)
        {
            return db.DIADIEMs.Include(s => s.CTDD).Where(s => s.IDTOUR == id).ToList();
        }
        public static int id()
        {
            return db.TOURs.OrderByDescending(s => s.ID).FirstOrDefault().ID;
        }
        
            public static int demdoan(int id, DateTime tu, DateTime den)
        {
            var d = db.DOANs.Where(s => s.IDTOUR == id && s.NGAYBD>=tu && s.NGAYKT<=den).ToList();
            return d.Count;
        }
        public static int chiphi(int id, DateTime tu, DateTime den)
        {
            var d = db.DOANs.Where(s => s.IDTOUR == id && s.NGAYBD >= tu && s.NGAYKT <= den).ToList();
            int cp = 0;
            foreach(DOAN doan in d)
            {
                cp += doan.CHIPHI;
            }
            return cp;
        }
        public static int doanhthu(int id, int gia, DateTime tu, DateTime den)
        {
            var d = db.DOANs.Where(s => s.IDTOUR == id && s.NGAYBD >= tu && s.NGAYKT <= den).ToList();
            int dt = 0;
            foreach (DOAN doan in d)
            {
                int sl = db.DATTOURs.Where(s => s.IDDOAN == doan.ID).Count();
                dt += sl * gia;
            }
            return dt;
        }
        public static void them(TOUR t)
        {
            db.TOURs.Add(t);
            db.SaveChanges();
        }
        public static void sua(TOUR t)
        {
            var dd = db.TOURs.Find(t.ID);
            db.Entry(dd).CurrentValues.SetValues(t);
            db.SaveChanges();
        }
        public static void them(DIADIEM dd)
        {
            db.DIADIEMs.Add(dd);
            db.SaveChanges();
        }
        public static void xoa(int id)
        {
            var x = db.DIADIEMs.Find(id);
            db.DIADIEMs.Remove(x);
            db.SaveChanges();
        }
        public static TOUR find(int id)
        {
            return db.TOURs.Find(id);
        }
        public static List<int> load(DateTime tu, DateTime den)
        {
            var x = db.DOANs.Where(s => s.NGAYBD >= tu && s.NGAYKT <= den).Select(s => s.IDTOUR).Distinct();
            return x.ToList();
        }
        public static List<GIATOUR> loadg(int id)
        {
            return db.GIATOURs.Where(s => s.IDTOUR == id).ToList();
        }
        public static void them(GIATOUR g)
        {
            db.GIATOURs.Add(g);
            db.SaveChanges();
        }
        public static void sua(int id)
        {
            var x = db.GIATOURs.Find(id);
            if (x.current)
                x.current = false;
            else
                x.current = true;
            db.Entry(x).State = EntityState.Modified;
            db.SaveChanges();
        }

    }
}
