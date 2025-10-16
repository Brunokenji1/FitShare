using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFitShare.Models
{
    internal class Category
    {
        public string Name { get; set; }
        public List<Component> Components { get; set; }
    }
}
