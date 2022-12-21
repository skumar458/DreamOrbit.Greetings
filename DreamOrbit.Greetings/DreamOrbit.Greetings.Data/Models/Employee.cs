using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamOrbit.Greetings.Data.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string? EmailAddress { get; set; }
        public int EmployeeId { get; set; }
        public DateOnly AnniversaryDate { get; set; }
        public DateOnly CreatedDate { get; set; }
        public DateOnly UpdatedDate { get; set; }
        public DateOnly DateOfJoining { get; set; }

    }
}
