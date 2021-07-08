using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Address_API.Models
{
    public class Address
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string Phone { get; set; }
        public string Comments { get; set; }
    }
}
