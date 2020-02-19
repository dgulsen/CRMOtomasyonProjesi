using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyunCRM.DataBaseLogicLayer.KatmanliMimariTanimi
{
    class KatmanliTanimi
    {
        #region KATMANLI MİMARİLER TANIMI

        /*
         KATMANLI MİMARİLER
         =>Bütün kodları bir arada ,bir sayfada kodlamak yerine aynı işlemleri yapacakkodları kategorize ederek kütüphanelerde kodlama işlemidir.
         => Kütüphaneler yaptığı işleme göre sınıflandırılır ve Katmanlı Mimarı yapısına uygun birşekilde kodlanması gereklidir.
         => Katmanlı Mimariler temelde 3 katmandan oluşur ama zamanımızda 17 katmana kadar çıkılabilirtabi 17 katman için çook büyük bir proje olması gereklidir.
         */

        #endregion

        #region UI KATMANI
        /*
          =>User Interface(UI)
            ->Kullanıcının göreceği katmandır. Bu katman windows form,web, IOS, ANDROID,... gibi direk kullanıcının göreceği katmanlar olacaktır.Kullanıcının kullandığı, anladığı, aktif olarak işlemler yaptığı katmandır.
             ->Bütün katmanların amacı UI katmanına hizmet etmektir.Veri alımı, gönderilmesi ,listelenmesi gibi bütün işlemler bu katmanın anlayabileceği şekilde olmalıdır.
             ->Bütün katmanların bu katmana işlem verebilmesi için UI katmanının bütün katmanları okuması gereklidir bu nedenle bu katmana BLL,DLL katmanlarının References alanına eklenmesi gereklidir.References alanına eklendikten sonra using alanına da dahil edilmesi gereklidir. Bu iki işlemden sonraBLL,DLL katmanlarında yazılan field,metotları kullanabilirsiniz.
             ->EF eklenmelidir.
         */
        #endregion

        #region DLL KATMANI
        /*
           =>DataBase Logic Layer
            ->Veritabanı işlemlerinin olduğu katmandır.Veritabanı ile ilgili, tablo class yapıları, bağlantı adresleri, bağlanma olayları gibi bütün veritabanı işlemleri bu katmanda olur
            ->References alanına yazılımcını kodladığı hiç bir kütüphane eklenmez(BLL) fakat EF için kütüphane eklenmesi gereklidir.
            ->Eğer EF nin Model yapısını ekleyecekseniz EF oto olarak eklenir ama Code First ile çalışacaksanız EF eklenmesi gerekllidir.
         */
        #endregion

        #region BLL KATMANI
        /*
        =>Business Logic Layer(BLL)
            ->En çok iş yükünün olduğu katmandır.Veri ekleme,güncelleme,silme, listeleme filtreleme için kullanılacak metotlar bu katmanda yazılır.
            -> Bu katmanda yazılacak metotlar genel kullanıma sahip olabilecek şekilde yazılmalıdır. Sadece windows forma ait kodlar yazarsanız web te o metodu çağırdığınız zaman kod hata verecektir.
            ->EF eklenmesi gereklidir.EF ekleme,güncelleme,silme,listelemede kullanılacağından dolayı eklenmelidir.
            -> Katman üzerinde sağ tıkla=> Manage Nuget Packates=> çıkan pencereden Browser sekmesinde EF(Entity Framework) aratılarak eklenir.
            ->BLL katmanında DLL katmanı çok aktif kullanıldığından References alanına DLL eklenir her kullanılmak istendiğinde using alanına DLL çağrılmalıdır.
         */
        #endregion

        #region App.Config AYARI
        /*
        DLL(Database Logic Layer) katmanına eklenen Model yapısının ayarları DLL katmanında yer alan App.Config sayfası içinde Connectionstring tag'i (düğümü) içine atmaktadır. Connectionstring'i kopyalayıp UI kısmında yer alan App.Config sayfasın içinde Configuretion tag'iiçine yapıştırılır.Bu ayar yapılmadan proje çalıştırıldığında hata verir,mutlaka yapılması gereklidir.
         
         */
        #endregion
    }
}
