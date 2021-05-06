using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constans
{
    //static olması new leme gerektirmez
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "ürün ismi geçersiz";
        public static string MaintenanceTime = "sistem bakımda";
        public static string ProductListed = "ürünler listelendi";
        public static string ProductUpdated="ürünler güncellendi";
        public static string ProductDeleted="ürünler silindi";
    }
}
