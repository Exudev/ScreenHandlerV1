using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenHandler.Models
{
    public class Action
    {
        public string Name { get; set; }
        public string Option { get; set; }
        public string Handler { get; set; }
        public string? NextScreen { get; set; }
    }
}
