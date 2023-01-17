using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenHandler.Models
{
    public class Pantalla
    {
        public string ID { get; set; }
        public bool EntryPoint { get; set; }
        public string Menu { get; set; }
        public string? Message { get; set; }
        public Field[]? Fields { get; set; }
        public Action[] Actions { get; set; }
    }
}
