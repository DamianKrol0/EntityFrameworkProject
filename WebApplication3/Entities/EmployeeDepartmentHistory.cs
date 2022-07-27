using WebApplication3.Entities;

namespace AdventureWork.Entities
{
    public class EmployeeDepartmentHistory
    {
        public int BusinessEntityID { get; set; }
        public int DepartmentId { get; set; }
        public int ShiftID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Department Department { get; set; }
        public Shift Shift { get; set; }
        public Employee Employee { get; set; }


    }
}
