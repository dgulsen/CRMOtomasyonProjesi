using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OyunCRM.BusinessLogicLayer.Manage;

namespace OyunCRM.UserInterface
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        LoginManage log_mng = new LoginManage();
        int hak = 1;
        private void buttonGiris_Click(object sender, EventArgs e)
        {
            var Result = log_mng.login(textBoxKullaniciAdi.Text, textBoxSifre.Text);
            if (Result.Count() == 0) 
            {
                MessageBox.Show(hak+". Hakkınızda Kullanıcı Adı veya Şifreniz Hatalı");
                if (hak==3)
                {
                    MessageBox.Show("Hakkınız bittiğinden sistemden atılacaksınız!");
                    this.Close();
                }
            }
            else
            {
                FrmMenu menu = new FrmMenu();

                menu.labelPersonelAdi.Text = Result.FirstOrDefault().Personeller.Adi;
                menu.labelPersonelSoyadi.Text = Result.FirstOrDefault().Personeller.Soyadi;
                menu.UyeYetkisi = Result.FirstOrDefault().Yetkiler.YetkiAdi;
                this.Hide();
                menu.Show();
            }
            hak++;
        }
        public string YetkiAdi;
    }
}
