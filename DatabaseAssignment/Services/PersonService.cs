using DatabaseAssignment.MVVM.Models;
using DatabaseAssignment.MVVM.Models.Entities;
using System.Threading.Tasks;
using DatabaseAssignment.Contexts;
using Microsoft.VisualBasic;
using System;

namespace DatabaseAssignment.Services;

internal class PersonService
{
    private readonly DataContext _context;

    public PersonService()
    {
        _context = new DataContext();
    }

    public async Task Create(PersonEntity person)
    {
        _context.Persons.Add(person);
        await _context.SaveChangesAsync();
       
    }
}
