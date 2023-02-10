using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos.Examples;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamplesController : ControllerBase
    {
        private readonly IExampleService _exampleService;
        private readonly IMapper _mapper;

        public ExamplesController(IExampleService exampleService, IMapper mapper)
        {
            _exampleService = exampleService;
            _mapper = mapper;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync(ExampleAddDto example)
        {
            var result = await _exampleService.AddAsync(example);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync(ExampleUpdateDto example)
        {
            var result = await _exampleService.UpdateAsync(example);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteAsync(int exampleId)
        {
            var result = await _exampleService.DeleteAsync(exampleId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetByIdAsync(int exampleId)
        {
            var result = await _exampleService.GetByIdAsync(exampleId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _exampleService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
