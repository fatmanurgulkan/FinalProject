using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
