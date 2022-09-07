using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsLibrary.Models
{
    public class Vendor
    {
        public int Id { set; get; }
        public string Code { set; get; }
        public string Name { set; get; }
        public string Address { set; get; }
        public string City { set; get; }
        public string State { set; get; }
        public string? Phone { set; get; }
        public string? Email { set; get; }
    }
}
