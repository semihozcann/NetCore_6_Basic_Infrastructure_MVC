using Business.Constants;
using Entities.Dtos.Examples;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.Examples
{
    public class ExampleAddValidator : AbstractValidator<ExampleAddDto>
    {
        //Example nesnesinin eklenmesi sırasında çalışan doğrulama kurallarını barındırır.
        //Bu kuralların yazılmasının sebebi veri tabanımızı korumak ve saçma verilerin veri tabannına eklenmesini önlemektir.
        /*
         Dooğrulama işlemi 3 kısımda yapılabilir. Bunlar;
        1- Veri tabanında
        2- Backend sürecinde
        3- Frontend sürecinde 

        Frontend kısmında bu doğrulama kurallarını ayrıca yazıp çalıştırırız böylece her talep gereksiz yere backend'deki doğrulama kurallarından dönüş olmaz. Fakat bazı kötü niyetli ve yazılım bilgisi olan kişiler Frontend'de olan dogrulama kurallarını aşabilirler. Bu durumda veri tabanını korumak için backendde yazılı olan kurallar devreye girer ve hata mesajı göndererek veri tabanına ekleme işlemini gerçekleştirmeden bunu engeller.
         
         */
        public ExampleAddValidator()
        {
            RuleFor(e => e.Name).NotEmpty().WithMessage(Messages.ExampleNameNotEmpty); //Boş olamaz 
            RuleFor(e => e.Name).NotNull(); //Null değer gönderilemez
            RuleFor(e => e.Name).MaximumLength(50).WithMessage(Messages.ExampleNameMaxLength); // En fazla 50 karakter olabilir.
            RuleFor(e => e.Description).NotEmpty().WithMessage(Messages.ExampleDescriptionNotEmpty);
            RuleFor(e => e.Description).NotNull();
            RuleFor(e => e.Description).MaximumLength(250).WithMessage(Messages.ExampleDescriptionMaxLength);
        }
    }
}
