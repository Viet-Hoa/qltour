using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTO;
using Core.DAO;

namespace Core.BUS
{
    public class QLNVU_BUS
    {
        public static List<NHIEMVU> load()
        {
            return DAO.QLNVU.load();
        }
        
        public static int them(NHIEMVU k)
        {
            try
            {
                DAO.QLNVU.them(k);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        public static int sua(NHIEMVU k)
        {
            try
            {
                DAO.QLNVU.sua(k);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        public static NHIEMVU find(int id)
        {
            return DAO.QLNVU.find(id);
        }
        
    }
}
