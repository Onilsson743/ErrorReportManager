
using DatabaseAssignment.MVVM.Models.Entities;

namespace DatabaseAssignment.MVVM.Models;

public class Employee
{
    public int EmployeeId { get; set; }
    public Person Person { get; set; } = new Person();
}
