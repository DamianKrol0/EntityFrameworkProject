using AdventureWork.Entities;

namespace WebApplication3.Entities
{
    public class Department
    {
      

        public int DepartmentId { get; set; }
        public string Name { get; set; }   
        public string? GroupName { get; set; }
        public DateTime ModifiedDate { get; set; }
        public ICollection<EmployeeDepartmentHistory> EmployeeDepartmentHistory { get; set; }

    }
}
