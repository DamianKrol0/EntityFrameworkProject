namespace AdventureWork.Entities
{
    public class EmployeePayHistory
    {
        public int BusinessEntityId {get;set;}
        public DateTime RateChangeDate {get;set;}
        public decimal Rate { get;set;}
        public int PayFrequency {get;set;}
        public DateTime ModifiedDate {get;set;}
        public Employee Employee { get;set;}
    }
}
