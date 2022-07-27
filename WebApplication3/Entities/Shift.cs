using System.ComponentModel.DataAnnotations;

namespace AdventureWork.Entities
{
    public class Shift
    {
        [Key]
        public int ShiftID { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<EmployeeDepartmentHistory> EmployeeDepartmentHistory { get; set; }
    }
}
