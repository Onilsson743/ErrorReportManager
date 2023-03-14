using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAssignment.MVVM.Models.Entities;

public class CommentsEntity
{
    public int Id { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public string Comment { get; set; } = null!;
    public int ErrorReportId { get; set; }
    public ErrorReportEntity ErrorReport { get; set; } = null!;
    public int? EmployeeId { get; set; }
    public EmployeeEntity Employee { get; set; } = null!;

}
