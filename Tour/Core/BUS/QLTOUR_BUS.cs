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
        public static List<TOUR> load()
        {
            return DAO.QLTOUR.load();
        }
        public static List<CTDD> loaddd()
        {
            return DAO.QLTOUR.loaddd();
        }
        public static List<DIADIEM> load(int id)
        {
            return DAO.QLTOUR.load(id);
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
        public static int them(DIADIEM d)
        {
            try
            {
                DAO.QLTOUR.them(d);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        public static void xoa(int id)
        {
            DAO.QLTOUR.xoa(id);
        }
        public static List<Thongke> thongke(DateTime tu, DateTime den)
        {
            List<Thongke> tour = new List<Thongke>();
            List<int> lt = QLTOUR.load(tu, den);
            foreach(var temp in lt)
            {
                TOUR tt = QLTOUR.find(temp);
                int demd =  DAO.QLTOUR.demdoan(temp, tu, den);
                int doanhthu =  DAO.QLTOUR.doanhthu(temp, tt.GIATOUR, tu, den);
                int chiphi =  DAO.QLTOUR.chiphi(temp, tu, den);
                int loi = doanhthu - chiphi;
                Thongke tk = new Thongke();
               
                tk.TENTOUR = tt.TENTOUR;
                tk.SODOAN = demd;
                tk.DOANHTHU = doanhthu;
                tk.CHIPHI = chiphi;
                tk.LOI = loi;
                tour.Add(tk);
            }
            return tour;
        }
        public static int id()
        {
            return DAO.QLTOUR.id();
        }
        public static List<GIATOUR> loadg(int id)
        {
            return QLTOUR.loadg(id);
        }
        public static int them(GIATOUR g)
        {
            try
            {
                QLTOUR.them(g);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }

        }
        public static int sua(int id)
        {
            try
            {
                QLTOUR.sua(id);
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
