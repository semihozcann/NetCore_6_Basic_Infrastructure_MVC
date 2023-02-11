using Entities.Concrete;
using Entities.Dtos.Examples;

namespace WebMVC.Models
{
    public class Example_VM : ExampleListDto
    {
        public List<Example> Examples { get; set; }
    }
}
