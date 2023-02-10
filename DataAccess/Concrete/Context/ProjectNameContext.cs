using Core.Entities.Abstract;
using Core.Entities.Concrete;
using DataAccess.Mapping;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Context
{
    public class ProjectNameContext : DbContext
    {

        //Veri tabanına bağlantı için gerekli bilgiler burada verilir.
        //Hangi veri tabanına bağlanılacaksa onun kütüphanesi indirilmelidir.
        //Burada default olarak Microsoft SQL kullanılmıştır. Farklı bir veri tabanı bağlantısı için ilgili kütüphaneyi yükleyip bu kısmı değiştirmeniz gereklidir.
        //Yazılı olan Connection String şifresiz veri tabanına uygun olandır. Veri tabanınızda şifre varsa ilgili Connection Stringi kullanmanız gereklidir.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-5R6CJJ3\SQLEXPRESS;Database=ExampleDb;Trusted_Connection=true");
        }

        //Entity nesnelerimiz ile veri tabanında bulunan tabloların eşleştirmesi için ilgili bilgiler burada verilir. 
        //
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Example> Examples{ get; set; }


        //Veritabanı oluşturulurken gerekli yapılanmayı burada belirttiğimiz Map clasını alarak yapar.
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ExampleMap());
            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new OperationClaimMap());
            builder.ApplyConfiguration(new UserOperationClaimMap());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //ChangeTracker mekanizması varlıkların durumlarını takip eden bir yapıdır. Bu sayede işlem yaparken varlıklar üzerinde ne işlem yapıldığını anlayabilir. Burada Bundan faydalanarak varlıklar üzerindeki değişime göre işlem esnasında yapılmasını istediğimiz eylemleri gereçekleştirebiliriz.
            var datas = ChangeTracker.Entries<BaseEntity>(); // varlığın yakalanması
            foreach (var data in datas) 
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow, //ekleme işlemi ise işlem anındaki tarihi CreatedDate stununa ekle
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow, //Güncelleme işlemi ise işlem anındaki tarihi UpdatedDate stununa ekle

                    //Bu kısıma işlem anında yapılmasını istediğiniz şeyleri ekleyebilirsiniz.
                };
            }
            return base.SaveChangesAsync(cancellationToken); //Değişiklikleri kaydet
        }
    }
}
