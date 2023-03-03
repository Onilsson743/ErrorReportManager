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

    //Get All Error Reports
    public async Task<List<ErrorReport>> GetErrorReports()
    {
        var result = await _context.ErrorReports.ToListAsync();

        if (result != null) 
        {
            List<ErrorReport> errorReports = new List<ErrorReport>();

            foreach (var report in result)
            {
                errorReports.Add(new ErrorReport()
                {
                    ErrorId = report.ErrorId,
                    Date = report.Date,
                    Description = report.Description,
                    Status = report.Status,                    
                });
            }
            return errorReports;
        }
        return null;
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
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    Phone = item.Phone,
                });
            }
            NewErrorReportsViewModel.Persons = persons;
        }
        
    }
}
