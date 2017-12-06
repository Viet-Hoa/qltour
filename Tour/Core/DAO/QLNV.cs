﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTO;
using System.Data.Entity;

namespace Core.DAO
{
    public class QLNV
    {
        private static TourEntities db = new TourEntities();
        public static List<NHANVIEN> load()
        {
            return db.NHANVIENs.ToList();
        }
        public static List<PHANCONG> load(int id)
        {
            return db.PHANCONGs.Include(s => s.DOAN).Where(s => s.IDNV == id).ToList();
        }
        public static int demtour(int id, DateTime tu, DateTime den)
        {
            var dt = db.PHANCONGs.Include(s => s.DOAN).Where(s => s.IDNV == id && s.DOAN.NGAYBD >= tu && s.DOAN.NGAYKT <= den).ToList();
            return dt.Count;
        }
        public static void them(PHANCONG pc)
        {
            db.PHANCONGs.Add(pc);
            db.SaveChanges();
        }
        public static void sua(PHANCONG pc)
        {
            db.Entry(pc).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
