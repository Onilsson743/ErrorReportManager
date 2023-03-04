using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseAssignment.MVVM.Models.Entities;

[Index(nameof(Email), IsUnique = true)]
public class PersonEntity
{
    public int Id { get; set; }

    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [StringLength(100)]
    public string Email { get; set; } = null!;

    [Column(TypeName = "char(13)")]
    public string Phone { get; set; } = null!;

    public int AdressId { get; set; }
    public AdressEntity Adress { get; set; } = null!;

}
