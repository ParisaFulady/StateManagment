using System;
using System.Collections.Generic;
using System.Text;

namespace AStateManagment.Entities
{
   public class Contacts
    {
        public int ContactsID { get; set; }
        public int PersonID { get; set; }
        public Person Person { get; set; }
    }
}
