using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Core.DTO;
using System.Data.Entity;

namespace Core.DAO
{
    public class rfconnect
    {
        private static TourEntities db = new TourEntities();
        public static void rf()
        {
            db.Database.Connection.Close();
            Thread.Sleep(100);
            db.Database.Connection.Open();
        }
    }
}
