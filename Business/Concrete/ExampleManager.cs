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

        [SecuredOperation("admin")] //Yetkilendirme
        [ValidationAspect(typeof(ExampleAddValidator))] //Doğrulama 
        public async Task<IResult> AddAsync(ExampleAddDto exampleAddDto)
        {

            Task<IResult> result = BusinessRules.Run(ExampleNameAlreadyExist(exampleAddDto.Name)); //İş kuralları

            if (result != null) //İş kurallarından geçip geçmediğinin kontrolü 
            {
                return result.Result;
            }
            var example = _mapper.Map<Example>(exampleAddDto); //Map işlemi 
            await _exampleRepository.AddAsync(example); //maplenen varlığı ekleme işlemi
            await _exampleRepository.SaveAsync(); //Yapılan değişikliğin kayıt işlemi
            return new SuccessResult(Messages.ExampleAdded);

        }

        #endregion

        #region DeleteAsync

        public async Task<IResult> DeleteAsync(int exampleId)
        {
            var example = await _exampleRepository.GetAsync(e => e.Id == exampleId); //id üzerinden varlığı yakalama işlemi
            if (example != null) //eğer ilgili id varsa;
            {
                var deletedExample = await _exampleRepository.DeleteAsync(example); //varlığı silme işlemi
                await _exampleRepository.SaveAsync(); //değişikliği kayıt işlemi
                return new SuccessResult(Messages.ExampleDeleted);
            }
            else //eğer ilgili id yoksa
            {
                return new ErrorResult(Messages.ExampleNotFound);
            }
        }

        #endregion

        #region GetAllAsync

        public async Task<IDataResult<ExampleListDto>> GetAllAsync()
        {
            var examples = await _exampleRepository.GetAllAsync(); //bütün varlıkları getirme işlemi
            if (examples != null) //eğer varlık varsa;
            {
                return new SuccessDataResult<ExampleListDto>(new ExampleListDto { Examples = examples }, Messages.ExamplesListed);
            }
            else // eğer varlık yoksa;
            {
                return new ErrorDataResult<ExampleListDto>(Messages.ExampleNotFound);
            }
        }

        #endregion

        #region GetAsync

        public async Task<IDataResult<ExampleDto>> GetAsync(int exampleId)
        {
            var example = await _exampleRepository.GetAsync(e => e.Id == exampleId); //id üzerinden bir varlığı getirme işlemi
            if (example != null) //eğer varlık varsa;
            {
                return new SuccessDataResult<ExampleDto>(new ExampleDto { Example = example }, Messages.ExampleGeted);
            }
            else //eğer varlık yoksa
            {
                return new ErrorDataResult<ExampleDto>(Messages.ExampleNotFound);
            }
        }

        #endregion

        #region UpdateAsync

        [ValidationAspect(typeof(ExampleAddValidator))]
        public async Task<IResult> UpdateAsync(ExampleUpdateDto exampleUpdateDto)
        {
            var oldExample = await _exampleRepository.GetAsync(e => e.Id == exampleUpdateDto.Id); //id üzerinden varlığı getirme işlemi
            var example = _mapper.Map<ExampleUpdateDto, Example>(exampleUpdateDto, oldExample); //getirilen varlığı mapleme işlemi
            var updatedExample = await _exampleRepository.UpdateAsync(example); //maplenen varlık üzerinde değişiklik işlemi

            return new SuccessResult(Messages.ExampleUpdated);
        }

        #endregion






        #region BusinessRules

        public async Task<IResult> ExampleNameAlreadyExist(string exampleName)
        {
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
