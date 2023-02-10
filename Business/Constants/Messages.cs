using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        //End Point Mesajlarını dinamik hale getirmek ve yinetimini daha kolay olması için hepsini buraya toplayabiliriz.
        //birden fazla yerde aynı mesajı verdiysek olası bir değişiklikte buradan değişmemiz her yerde değişmesini sağlar aksi halde bütün projede ilgili metni bulup değişmemiz gereklidir.

        public static string ExampleAdded = "Örnek başarıyla eklendi";
        public static string ExampleUpdated = "Örnek başarıyla güncellendi";
        public static string ExampleDeleted = "Örnek başarıyla silindi";
        public static string ExampleNotFound = "Örnek bulunamadı";
        public static string ExamplesListed = "Örnekler listelendi";
        public static string ExampleGeted = "Örnek getirildi.";
        public static string ExampleNameAlreadyExist = "Bu isimde bir örnek mevcut";
        public static string ExampleNameNotEmpty = "Lütfen örnek ismi alanını doldurunuz.";
        public static string ExampleDescriptionNotEmpty = "Lütfen açıklama alınını doldurunuz";
        public static string ExampleNameMaxLength = "İsim uzunluğu en fazla 50 karakter olabilir.";
        public static string ExampleDescriptionMaxLength = "Açıklama uzunluğu en fazla 250 karakter olabilir.";

        public static string UserAdded = "Kullanıcı Eklendi";
        public static string UserRegistered = "Kayıt Başarılı";
        public static string UserNotFound = "Kullanıcı adı veya şifre hatalı";
        public static string PasswordError = "Hatalı şifre girdiniz.";
        public static string SuccessfulLogin ="Giriş Başarılı";
        public static string UserAlreadyExists = "Bu email üzerine kayıtlı kullanıcı bulunmaktadır.";
        public static string AccessTokenCreated = "Access Token oluşturuldu";

        public static string AuthorizationDenied = "Yetkiniz Yok.";
    }
}
