﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTO;
using System.Data.Entity;

namespace Core.DAO
{
    public class QLTOUR
    {
        private static TourEntities db = new TourEntities();
        public static List<TOUR> load()
        {
            return db.TOURs.ToList();
        }
        public static List<CTDD> load(int id)
        {
            return db.CTDDs.Where(s => s.IDDD == id).ToList();
        }
        public static int demdoan(int id)
        {
            var d = db.DOANs.Where(s => s.IDTOUR == id).ToList();
            return d.Count;
        }
        public static int chiphi(int id, DateTime tu, DateTime den)
        {
            var d = db.DOANs.Where(s => s.IDTOUR == id && s.NGAYBD >= tu && s.NGAYKT <= den).ToList();
            int cp = 0;
            foreach(DOAN doan in d)
            {
                cp += doan.CHIPHI;
            }
            return cp;
        }
        public static int doanhthu(int id, int gia, DateTime tu, DateTime den)
        {
            var d = db.DOANs.Where(s => s.IDTOUR == id && s.NGAYBD >= tu && s.NGAYKT <= den).ToList();
            int dt = 0;
            foreach (DOAN doan in d)
            {
                int sl = db.DATTOURs.Where(s => s.IDDOAN == doan.ID).Count();
                dt += sl * gia;
            }
            return dt;
        }
    }
}