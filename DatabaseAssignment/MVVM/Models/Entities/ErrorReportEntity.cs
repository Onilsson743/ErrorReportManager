using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseAssignment.MVVM.Models.Entities; 
public class ErrorReportEntity 
{
    [Key]
    public int ErrorId { get; set; }

    [Column(TypeName = "DATETIME DEFAULT GETDATE()")] 
    public DateTime Date { get; set; }
    public string Description { get; set; } = string.Empty;
    public int? EmployeeId { get; set; }
    public EmployeeEntity Employee { get; set; } = null!;
    public int PersonId { get; set; }
    public PersonEntity Person { get; set; } = null!;

    public string Status { get; set; } = null!;

    public ICollection<CommentsEntity> Comments = new HashSet<CommentsEntity>();
}
