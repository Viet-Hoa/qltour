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
    }
}
