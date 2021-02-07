using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
