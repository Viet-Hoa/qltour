using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DAO;
using Core.DTO;

namespace Core.BUS
{
    public class QLTOUR_BUS
    {
        private static int chi = 0, thu = 0;
        public static List<TOUR> load()
        {
            return DAO.QLTOUR.load();
        }
        public static List<DIADIEM> load(int id)
        {
            return DAO.QLTOUR.load(id);
        }
        public static int chiphi(int id, DateTime tu, DateTime den)
        {
            chi = DAO.QLTOUR.chiphi(id, tu, den);
            return chi;
        }
        public static int doanhthu(int id, int gia, DateTime tu, DateTime den)
        {
            thu = DAO.QLTOUR.doanhthu(id, gia, tu, den);
            return thu;
        }
        public static int tienloi()
        {
            return thu - chi;
        }
        public static int them(TOUR t)
        {
            try
            {
                DAO.QLTOUR.them(t);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        public static int sua(TOUR t)
        {
            try
            {
                DAO.QLTOUR.sua(t);
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
