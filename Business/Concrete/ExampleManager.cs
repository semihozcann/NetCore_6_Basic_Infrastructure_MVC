using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation.Examples;
using Core.Aspects.Autofac;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Examples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ExampleManager : IExampleService
    {

        #region Injection

        IExampleRepository _exampleRepository;
        IMapper _mapper;

        public ExampleManager(IExampleRepository exampleRepository, IMapper mapper)
        {
            _exampleRepository = exampleRepository;
            _mapper = mapper;
        }

        #endregion




        #region AddAsync

        //[SecuredOperation("admin")] //Ui'dan gelen isteği yapan kişinin yetkisi olup olmadığını kontrol eder. 
        [ValidationAspect(typeof(ExampleAddValidator))] //Ui'dan gelen verinin yapısının doğrulunu kontrol eder. 
        public async Task<IResult> AddAsync(ExampleAddDto exampleAddDto)
        {

            Task<IResult> result = BusinessRules.Run(ExampleNameAlreadyExist(exampleAddDto.Name)); //İş kuralları Run metodu içine virgül ile ayrılarak yazılabilir. Run metodu her kuralı sırayla denetleyerek hata varsa hatayı döndürür. Eğer hata yoksa başarılı ile geçerse bütün kurallardan bir işlem yapmaz ve talep ettiğimiz ekleme işlemi gerçekleşir.

            if (result != null) //Run metodundan null değer gelmediyse
            {
                return result.Result; //Run metodu null harici bir değer gönderirse çalışır.
            }
            var example = _mapper.Map<Example>(exampleAddDto); //Map işlemi yapar.
            await _exampleRepository.AddAsync(example); //maplenen varlığı ekleme işlemi yapar.
            await _exampleRepository.SaveAsync(); //Yapılan değişikliğin kayıt işlemi yapar.
            return new SuccessResult(Messages.ExampleAdded); //Son noktadır API'ye başarı mesajını gönderir. 

        }

        #endregion

        #region DeleteAsync

        public async Task<IResult> DeleteAsync(int exampleId)
        {
            var example = await _exampleRepository.GetAsync(e => e.Id == exampleId); //id üzerinden varlığı yakalama işlemi yapar.
            if (example != null) //eğer ilgili id varsa;
            {
                var deletedExample = await _exampleRepository.DeleteAsync(example); //varlığı silme işlemi yapar.
                await _exampleRepository.SaveAsync(); //değişikliği kayıt işlemi yapar.
                return new SuccessResult(Messages.ExampleDeleted); //Son noktadır API'ye başarı mesajını gönderir. 
            }
            else //eğer ilgili id yoksa
            {
                return new ErrorResult(Messages.ExampleNotFound); //Son noktadır API'ye hata mesajını gönderir. 
            }
        }

        #endregion

        #region GetAllAsync

        public async Task<IDataResult<ExampleListDto>> GetAllAsync()
        {
            var examples = await _exampleRepository.GetAllAsync(); //bütün varlıkları getirme işlemi yapar.
            if (examples != null) //eğer varlık varsa;
            {
                return new SuccessDataResult<ExampleListDto>(new ExampleListDto { Examples = examples }, Messages.ExamplesListed); //Son noktadır API'ye başarı mesajını ve ilgili dataları'yı gönderir. 
            }
            else // eğer varlık yoksa;
            {
                return new ErrorDataResult<ExampleListDto>(Messages.ExampleNotFound); //Son noktadır API'ye hata mesajını gönderir. 
            }
        }

        #endregion

        #region GetByIdAsync

        public async Task<IDataResult<ExampleDto>> GetByIdAsync(int exampleId)
        {
            var example = await _exampleRepository.GetAsync(e => e.Id == exampleId); //id üzerinden bir varlığı getirme işlemi yapar.
            if (example != null) //eğer varlık varsa;
            {
                return new SuccessDataResult<ExampleDto>(new ExampleDto { Example = example }, Messages.ExampleGeted); //Son noktadır API'ye başarı mesajını ve ilgili datayı gönderir. 
            }
            else //eğer varlık yoksa
            {
                return new ErrorDataResult<ExampleDto>(Messages.ExampleNotFound); //Son noktadır API'ye hata mesajını gönderir. 
            }
        }

        #endregion

        #region UpdateAsync

        [ValidationAspect(typeof(ExampleAddValidator))]
        public async Task<IResult> UpdateAsync(ExampleUpdateDto exampleUpdateDto)
        {
            var oldExample = await _exampleRepository.GetAsync(e => e.Id == exampleUpdateDto.Id); //id üzerinden varlığı getirme işlemi yapar.
            var example = _mapper.Map<ExampleUpdateDto, Example>(exampleUpdateDto, oldExample); //getirilen varlığı mapleme işlemi yapar.
            var updatedExample = await _exampleRepository.UpdateAsync(example); //maplenen varlık üzerinde değişiklik işlemi yapar.
            await _exampleRepository.SaveAsync(); //Yapılan değişikliklerin kayıt işlemini yapar.

            return new SuccessResult(Messages.ExampleUpdated); //Son noktadır API'ye başarı mesajını gönderir. 
        }

        #endregion






        #region BusinessRules
        //iş kurallar birden fazla yerde kullanılabilir bu sebepten bu kısımda bir metot ile oluşturulup gerekli yerde çağırılarak kullanmak daha verimli olur. 
        //Bu sayede birden fazla yerde kullanılan bir kuralda değişiklik yapılması gerekince buradan değişiklik yapılınca her yerde değişmiş olur.
        public async Task<IResult> ExampleNameAlreadyExist(string exampleName)
        {
            //Burada aynı isimde başka bir örnek eklenmesini engellemek amacıyla bir örnek kural yazılmıştır.
            var example = await _exampleRepository.GetAllAsync(e => e.Name == exampleName); 
            var result = example.Any();
            if (result)
            {
                return new ErrorResult(Messages.ExampleNameAlreadyExist);
            }
            return new SuccessResult();
        }



        #endregion
    }
}
