using DatabaseAssignment.MVVM.Models;
using DatabaseAssignment.MVVM.Models.Entities;
using DatabaseAssignment.MVVM.ViewModels;
using DatabaseAssignment.MVVM.Views;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DatabaseAssignment.Services;

public class DbServices
{
    private readonly DataContext _context;

    public DbServices()
    {
        _context = new DataContext();
    }

    //Get functions
    #region
    //Get All Error Reports
    public async Task GetErrorReports()
    {
        var result = await _context.ErrorReports.Include(p => p.Person).ThenInclude(a => a.Adress).ToListAsync();

        if (result != null) 
        {
            ObservableCollection<ErrorReport> errorReports = new ObservableCollection<ErrorReport>();

            foreach (var report in result)
            {
                errorReports.Add(new ErrorReport()
                {
                    ErrorId = report.ErrorId,
                    Date = report.Date,
                    Description = report.Description,
                    Status = report.Status, 
                    Person = new Person()
                    {
                       Id = report.Person.Id,
                       FirstName = report.Person.FirstName,
                       LastName = report.Person.LastName,
                       Email = report.Person.Email,
                       Phone = report.Person.Phone,
                       Adress = new Adress()
                       {
                           ApartmentNumber = report.Person.Adress.ApartmentNumber,
                           StreetName = report.Person.Adress.StreetName,
                           PostalCode = report.Person.Adress.PostalCode,
                           City = report.Person.Adress.City
                       }
                       
                    },

                });
            }
            NewErrorReportsViewModel.ErrorReport = errorReports;
            
        }
    }

    //Get All Persons
    public async Task GetPersons()
    {
        var result = await _context.Persons.ToListAsync();

        if (result != null)
        {
            ObservableCollection<Person> persons = new ObservableCollection<Person>();

            foreach (var item in result)
            {
                persons.Add(new Person()
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    Phone = item.Phone,
                });
            }
            NewErrorReportsViewModel.Persons = persons;
        }
    }
    #endregion 
}
