using System;
using System.Collections.Generic;


namespace DatabaseAssignment.MVVM.Models;

public class ErrorReport
{
    public int ErrorId { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; } = string.Empty;
    public Employee employee { get; set; } = new Employee();
    public Person Person { get; set; } = new Person();
    public string Status { get; set; } = string.Empty;
    public List<Comments> CommentsList { get; set; } = new List<Comments>();

}
