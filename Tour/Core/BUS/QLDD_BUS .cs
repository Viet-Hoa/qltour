using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTO;
using Core.DAO;

namespace Core.BUS
{
    public class QLDD_BUS
    {
        public static List<CTDD> load()
        {
            return DAO.QLDD.load();
        }
        public static int them(CTDD d)
        {
            try
            {
                DAO.QLDD.them(d);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        public static int sua(CTDD d)
        {
            try
            {
                DAO.QLDD.sua(d);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        
        public static CTDD findd(int id)
        {
            return DAO.QLDD.find(id);
        }
    }
}
