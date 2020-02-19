using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OyunCRM.DataBaseLogicLayer;

namespace OyunCRM.BusinessLogicLayer.Manage
{
    public class LoginManage
    {
        OyunCRMDBEntities db = new OyunCRMDBEntities();
        public List<Uyeler> login(string uyeadi, string sifre)
        {
            var enterResult = db.Uyeler.Where(k => k.UyeAdi == uyeadi && k.Sifre == sifre).ToList();
            if (enterResult == null) 
            {
                return null;
            }
            return enterResult;
        }
    }
}
