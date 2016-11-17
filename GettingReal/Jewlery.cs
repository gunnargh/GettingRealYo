using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal
{
    public class Jewlery
    {
        
        public Jewlery(int id, string name,int price,int quanity,string desc,string type)
        {
            ID = id;
            JName = name;
            JPrice = price;
            JDescription = desc;
            JType = type;
            JQuanity = quanity;
        }

        public int ID { get; set; }
        public string JName { get; set; }
        public int JPrice { get; set; }
        public string JDescription { get; set; }
        public string JType { get; set; }
        public int JQuanity { get; set; }
    }
}
