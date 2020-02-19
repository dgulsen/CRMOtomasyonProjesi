using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OyunCRM.UserInterface
{
    public partial class FrmDepartmanlar : Form
    {
        public FrmDepartmanlar()
        {
            InitializeComponent();
        }

        private void FrmDepartmanlar_Load(object sender, EventArgs e)
        {
            OrtakClassUI ortak = new OrtakClassUI();
            ortak.MusteriAdiSoyadiListesi(comboBox1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(comboBox1.SelectedValue.ToString());
        }
    }
}
