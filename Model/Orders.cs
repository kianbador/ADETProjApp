using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ADETProjApp.Model
{
    public class Orders 
    {
        public string order_id {  get; set; }
        public string username { get; set; }
        public string description { get; set; }
        public string price { get; set; }
        public string payment {  get; set; }
        public DateTime date_ordered { get; set; }

    }
}

