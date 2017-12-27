using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.DTO;
using Core.BUS;

namespace WindowsForms
{
    public partial class Suatour : Form
    {
        private TOUR tour = new TOUR();
        private List<GIATOUR> gia = new List<GIATOUR>();
        private int idcu, idmoi, idcutam;
        public Suatour()
        {
            InitializeComponent();
        }

        public void set(TOUR t)
        {
            tour = t;
            textBox1.Text = t.TENTOUR;
            richTextBox1.Text = t.DACDIEM;
            textBox4.Text = t.GIATOUR.ToString();
            textBox3.Text = t.LOAIHINH;
            gia = QLTOUR_BUS.loadg(t.ID);
            idcu = gia.Where(s => s.current == true).FirstOrDefault().ID;
            gridControl2.DataSource = gia;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tour.TENTOUR = textBox1.Text;
            tour.DACDIEM = richTextBox1.Text;
            tour.GIATOUR = int.Parse(textBox4.Text);
            tour.LOAIHINH = textBox3.Text;
            int t = QLTOUR_BUS.sua(tour);
            if (t == 0)
                MessageBox.Show("Lỗi sửa tour");
            if(idcu!=idmoi)
            {
                t = QLTOUR_BUS.sua(idcu);
                if (t == 0)
                    MessageBox.Show("Lỗi sửa giá cũ");
                t = QLTOUR_BUS.sua(idmoi);
                if (t == 0)
                    MessageBox.Show("Lỗi sửa giá mới");
            }
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            button4.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            idcutam = gia.Where(s => s.current == true).FirstOrDefault().ID;
            idmoi = int.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "ID").ToString());
            textBox4.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "GIA").ToString();
            gia.Where(s => s.ID == idcutam).FirstOrDefault().current = false;
            gia.Where(s => s.ID == idmoi).FirstOrDefault().current = true;
            gridControl2.DataSource = gia;
            gridControl2.RefreshDataSource();
        }
    }
}
