using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTO;
using Core.DAO;

namespace Core.BUS
{
    public class QLKHACH_BUS
    {
        public static List<KHACHHANG> load()
        {
            return DAO.QLKHACH.load();
        }
        
        public static int them(KHACHHANG k)
        {
            try
            {
                DAO.QLKHACH.them(k);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        public static int sua(KHACHHANG k)
        {
            try
            {
                DAO.QLKHACH.sua(k);
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
