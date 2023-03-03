using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseAssignment.MVVM.Models.Entities;

public class EmployeeEntity
{
    [Key]
    public int EmployeeId { get; set; }
    public int PersonId { get; set; }
    public PersonEntity Person { get; set; } = null!;

}
