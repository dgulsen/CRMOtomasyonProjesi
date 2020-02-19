using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OyunCRM.DataBaseLogicLayer;

namespace OyunCRM.BusinessLogicLayer.OOPClass
{
    interface IDepartman
    {
        string DepartmanKaydet(string adi);
        string DepartmanGuncelle(int departmanlarId,string adi);
        string DepartmanSil(int departmanlarId);
        List<Departmanlar> DepartmanListesi();
    }
}
