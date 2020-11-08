using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace microMantra
{
    public class visitor
    {
        [Key]
        public int visitorID { get; set; }
       public string FirstName { get; set; }
          public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string location {get; set; }

    }
}
