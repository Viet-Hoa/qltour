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
    public partial class Themtour : Form
    {
        private List<CTDD> dd = new List<CTDD>();//read only
        private List<CTDD> ctdd = new List<CTDD>();
        private List<GIATOUR> gia = new List<GIATOUR>();
        public Themtour()
        {
            InitializeComponent();
        }
        public void set()
        {
            dd = QLTOUR_BUS.loaddd();
            comboBox1.DataSource = QLTOUR_BUS.loaddd();
            comboBox1.DisplayMember = "TENDIADIEM";
            comboBox1.ValueMember = "ID";            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(comboBox1.SelectedValue.ToString());
            var d = dd.Where(s=>s.ID==id).FirstOrDefault();
            ctdd.Add(d);
            gridControl1.DataSource = ctdd;
            gridControl1.RefreshDataSource();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TOUR tt = new TOUR();
            tt.TENTOUR = textBox1.Text;
            tt.DACDIEM = richTextBox1.Text;
            tt.GIATOUR = int.Parse(textBox4.Text);
            tt.LOAIHINH = textBox3.Text;
            int t = QLTOUR_BUS.them(tt);
            if (t == 0)
                MessageBox.Show("Lỗi thêm tour");
            else
            {
                int id = QLTOUR_BUS.id();
                foreach (var x in ctdd)
                {
                    DIADIEM d = new DIADIEM();
                    d.IDTOUR = id;
                    d.IDDD = x.ID;
                    t = QLTOUR_BUS.them(d);
                    if (t == 0)
                        MessageBox.Show("Lỗi thêm địa điểm");
                }
                foreach(var x in gia)
                {
                    x.IDTOUR = id;
                    t = QLTOUR_BUS.them(x);
                    if (t == 0)
                        MessageBox.Show("Lỗi thêm giá");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GIATOUR g = new GIATOUR();
            g.GIA = int.Parse(textBox2.Text);
            g.THANGBD = comboBox2.SelectedItem.ToString();
            g.THANGKT = comboBox3.SelectedItem.ToString();
            int now = DateTime.Now.Month,
            bd = int.Parse(g.THANGBD),
            kt = int.Parse(g.THANGKT);
            if (bd>kt)
                kt += 12;
            if (bd <= now && now < kt)
            {
                g.current = true;
                textBox4.Text = textBox2.Text;
            }
            else
                g.current = false;
            gia.Add(g);
            textBox2.Text = "";
            gridControl2.DataSource = gia;
            gridControl2.RefreshDataSource();
        }
    }
}
