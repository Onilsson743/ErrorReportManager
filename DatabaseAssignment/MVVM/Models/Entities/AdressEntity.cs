using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseAssignment.MVVM.Models.Entities;

public class AdressEntity
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string? ApartmentNumber { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string StreetName { get; set; } = string.Empty;

    [Required]
    [Column(TypeName = "char(6)")]
    public string PostalCode { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string City { get; set; } = string.Empty;

    
}
