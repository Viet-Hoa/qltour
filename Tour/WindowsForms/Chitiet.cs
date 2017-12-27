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
    public partial class Chitiet : Form
    {
        public Chitiet()
        {
            InitializeComponent();
        }
        public void set(TOUR t)
        {
            textBox1.Text = t.TENTOUR;
            richTextBox1.Text = t.DACDIEM;
            textBox4.Text = t.GIATOUR.ToString();
            textBox3.Text = t.LOAIHINH;
            List<DIADIEM> dd = QLTOUR_BUS.load(t.ID);
            List<CTDD> ctdd = new List<CTDD>();
            foreach(var x in dd)
            {
                CTDD ct = new CTDD();
                ct = x.CTDD;
                ctdd.Add(ct);
            }
            List<GIATOUR> gia = QLTOUR_BUS.loadg(t.ID);
            gridControl1.DataSource = ctdd;
            gridControl2.DataSource = gia;
        }

        
    }
}
