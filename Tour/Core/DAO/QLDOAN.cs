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
    }
}
