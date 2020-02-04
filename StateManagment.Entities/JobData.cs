using System;
using System.Collections.Generic;
using System.Text;

namespace AStateManagment.Entities
{
    public class JobData
    {
        public int JobDataId { get; set; }
        public string JobTitile { get; set; }
        public int PersonID { get; set; }
        public Person Person { get; set; }
    }
}
