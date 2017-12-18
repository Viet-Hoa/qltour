using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DAO;
using Core.DTO;

namespace Core.BUS
{
    public class QLNV_BUS
    {        
        public static List<NHANVIEN> load()
        {
            return DAO.QLNV.load();
        }
        public static List<PHANCONG> load(int id)
        {
            return DAO.QLNV.load(id);
        }
        public static int demtour(int id, DateTime tu, DateTime den)
        {
            return DAO.QLNV.demtour(id, tu, den);
        }
        public static int them(PHANCONG p)
        {
            try
            {
                DAO.QLNV.them(p);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        public static int sua(PHANCONG p)
        {
            try
            {
                DAO.QLNV.sua(p);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
    }
}
