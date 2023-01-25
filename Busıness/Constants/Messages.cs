using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Busıness.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "ürün eklendi";
        public static string ProductNameInvalid = "ürün ismi geçersiz";

        public static string ProductsListed = "ürünler listelendi";
        public static string MaintenanceTime="sistem bakımda ";
        public static string ProductCountOfCategoryError=  "bir categoryde max 0 ürün olaılır";
        public static string ProductNameAlreadyExists = "bu isimde zaten başka ürün var";
        public static string Categorylimitexceded="category limiti aşıldığı için yeni ürün eklenemiyor.";
        public static string AuthorizationDenied= "yetkiniz yok";
       public  static string UserNotFound="kullanıcı bulunamadı";
        public static string PasswordError="yanlış parola";
        public static string SuccessfulLogin="basarılı giriş";
        public static string UserAlreadyExists="kullanıcı mevcut";
        public static string AccessTokenCreated="olustu";
        public static string UserRegistered= "kayıt olundu";
    }
}
