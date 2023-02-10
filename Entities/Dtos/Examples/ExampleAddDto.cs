using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Examples
{
    public class ExampleAddDto : IDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
