using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseAssignment.MVVM.Models;

public class Adress
{
    public int Id { get; set; }
    public string? ApartmentNumber {get; set;} = string.Empty;
    public string StreetName { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
}
