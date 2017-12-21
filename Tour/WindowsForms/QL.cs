using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.BUS;
using Core.DTO;

namespace WindowsForms
{
    public partial class QL : Form
    {
        TOUR tt = new TOUR();
        public QL()
        {
            InitializeComponent();
            load();
        }
        private void load()
        {
            gridControl1.DataSource = QLTOUR_BUS.load();
        }
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            tt = new TOUR();
            TOUR t = new TOUR();
            t.ID = int.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString());
            t.TENTOUR = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TENTOUR").ToString();
            t.DACDIEM = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DACDIEM").ToString();
            t.GIATOUR = int.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MASP").ToString());
            t.LOAIHINH = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "LOAIHINH").ToString();
            button2.Enabled = true;
            button3.Enabled = true;
            tt = t;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var ts = new Themtour())
            {
                ts.set();
                ts.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var ts = new Suatour())
            {
                ts.set(tt);
                ts.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var ct = new Chitiet())
            {

                ct.ShowDialog();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            gridControl2.DataSource = QLTOUR_BUS.thongke(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
        }
    }
}
