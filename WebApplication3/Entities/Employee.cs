using System.ComponentModel.DataAnnotations;

namespace AdventureWork.Entities
{
    public class Employee
    {
        [Key]
        public int BusinessEntityID { get; set; }
        public int NationalIDNumber { get; set; }
        public string LoginID { get; set; }
        
        public int? OrganizationLevel { get; set; }
        public string JobTitle { get; set; }
        public DateTime BirthDate { get; set; }
        public char MaritalStatus { get; set; }
        public char Gender { get; set; }
        public DateTime HireDate { get; set; }
        public int VacationHours { get; set; }
        public int SickLeaveHours { get; set; }
        public int SalariedFlag { get; set; }
        public int CurrentFlag { get; set; }
        
        public DateTime ModifiedDate { get; set; }
        public  ICollection<EmployeeDepartmentHistory> EmployeeDepartmentHistory;
        public  ICollection<EmployeePayHistory> EmployeePayHistory;




    }

 
}
