using Microsoft.EntityFrameworkCore;
using WebApplication3.Entities;

namespace AdventureWork.Entities
{
    public class AdventureWorkContext : DbContext
    {
        public AdventureWorkContext(DbContextOptions<AdventureWorkContext> options) : base(options)
        {
        }
        public DbSet<Department> Department { get; set; }
        public DbSet<EmployeeDepartmentHistory> EmployeeDepartmentHistory { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Shift> Shift { get; set; }
        public DbSet<EmployeePayHistory> EmployeePayHistory { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(hr =>
            {
                hr.Property(x => x.ModifiedDate).HasDefaultValueSql("GETDATE()");
            });
            modelBuilder.Entity<Employee>(hr =>
            {
                hr.Property(x => x.SalariedFlag).HasDefaultValue(1);
                hr.Property(x => x.CurrentFlag).HasDefaultValue(1);
                hr.Property(x => x.VacationHours).HasDefaultValue(0);
                hr.Property(x => x.SickLeaveHours).HasDefaultValue(0);
                hr.Property(x => x.ModifiedDate).HasDefaultValueSql("GETDATE()");
                
            });
            modelBuilder.Entity<EmployeeDepartmentHistory>(hr =>
            {
                hr.Property(x => x.ModifiedDate).HasDefaultValueSql("GETDATE()");
                hr.HasOne(x => x.Department)
                .WithMany(d=>d.EmployeeDepartmentHistory)
                .HasForeignKey(x => x.DepartmentId);
                hr.HasOne(e => e.Shift).WithMany(s => s.EmployeeDepartmentHistory)
                .HasForeignKey(d => d.ShiftID);
                hr.HasOne(e => e.Employee).WithMany(s => s.EmployeeDepartmentHistory)
                .HasForeignKey(d => d.BusinessEntityID);
                hr.HasKey(x => new {  x.BusinessEntityID, x.StartDate,x.DepartmentId, x.ShiftID });


            });
            modelBuilder.Entity<Shift>(hr =>
            {
                hr.HasKey(x => x.ShiftID);
                hr.Property(x => x.ModifiedDate).HasDefaultValueSql("GETDATE()");


            });
            modelBuilder.Entity<EmployeePayHistory>(hr =>
            {
                hr.HasKey(x => new {x.BusinessEntityId, x.RateChangeDate});
                hr.Property(x => x.ModifiedDate).HasDefaultValueSql("GETDATE()");
                hr.HasOne(e=>e.Employee)
                .WithMany(s => s.EmployeePayHistory)
                .HasForeignKey(e => e.BusinessEntityId);


            });

        }
    }
}
