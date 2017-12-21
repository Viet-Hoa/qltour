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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tour.TENTOUR = textBox1.Text;
            tour.DACDIEM = richTextBox1.Text;
            tour.GIATOUR = int.Parse(textBox4.Text);
            tour.LOAIHINH = textBox3.Text;
            int t = QLTOUR_BUS.sua(tour);
            if (t == 0)
                MessageBox.Show("Lỗi sửa");
        }
    }
}
