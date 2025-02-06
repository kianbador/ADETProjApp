using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADETProjApp.Model
{
    public class Discount
    {
        public double percent {  get; set; }
        public string desc { get; set; }
        public string imagePath {  get; set; }
        public int cost { get; set; }
    }
}
