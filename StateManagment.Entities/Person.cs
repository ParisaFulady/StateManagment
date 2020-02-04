using System;
using System.Collections.Generic;
using System.Text;

namespace AStateManagment.Entities
{
    public class Person
    {
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LasttName { get; set; }
        public List<Contacts> Contacts { get; set; }
        public JobData JobData { get; set; }

    }
}
