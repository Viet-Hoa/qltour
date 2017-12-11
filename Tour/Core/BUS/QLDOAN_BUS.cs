using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTO;
using Core.DAO;

namespace Core.BUS
{
    public class QLDOAN_BUS
    {
        public static List<DOAN> load()
        {
            return DAO.QLDOAN.load();
        }
        public static List<DATTOUR> load(int id)
        {
            return DAO.QLDOAN.load(id);
        }
        public static int them(DOAN d)
        {
            try
            {
                DAO.QLDOAN.them(d);
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public static int sua(DOAN d)
        {
            try
            {
                DAO.QLDOAN.sua(d);
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public static int them(DATTOUR dt)
        {
            try
            {
                DAO.QLDOAN.them(dt);
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public static int sua(DATTOUR dt)
        {
            try
            {
                DAO.QLDOAN.sua(dt);
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public static void xoa(int id)
        {
            DAO.QLDOAN.xoa(id);
        }
        public static DOAN findd(int id)
        {
            return DAO.QLDOAN.findd(id);
        }
        
    }
}
