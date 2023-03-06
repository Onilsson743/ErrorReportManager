using DatabaseAssignment.MVVM.Models;
using DatabaseAssignment.MVVM.Models.Entities;
using DatabaseAssignment.MVVM.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;
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
        var result = await _context.ErrorReports.Include(p => p.Person).ThenInclude(a => a.Adress).Include(c => c.Comments).ToListAsync();

        if (result != null) 
        {
            ObservableCollection<ErrorReport> errorReports = new ObservableCollection<ErrorReport>();

            foreach (var report in result)
            {
                ErrorReport eReport = new ErrorReport()
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
                };
                foreach (var x in report.Comments)
                {
                    eReport.CommentsList.Add(new Comments()
                    {
                        Id= x.Id,
                        Comment = x.Comment,
                        EmployeeId = x.EmployeeId
                    });
                }
                errorReports.Add(eReport);
            }
            ContentDataServices.ErrorReports = errorReports;            
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
            //NewErrorReportsViewModel.Persons = persons;
        }
    }
    #endregion


    //Add functions
    #region
    //Add error report
    public async Task CreateErrorReport(PersonEntity person, AdressEntity adress, string description)
    {
        
        ErrorReportEntity report = new ErrorReportEntity
        {
            Description = description,
            Person = person
        };

        var Adress = await _context.Adresses.FirstOrDefaultAsync(a => a.StreetName == adress.StreetName && a.PostalCode == adress.PostalCode && a.City == adress.City && a.ApartmentNumber == a.ApartmentNumber);
        if (Adress != null)
        {
            report.Person.AdressId = Adress.Id;
        } else
        {
            var Added = _context.Adresses.Add(adress);
            await _context.SaveChangesAsync();
            var result = await _context.Adresses.FirstOrDefaultAsync(a => a.StreetName == adress.StreetName && a.PostalCode == adress.PostalCode && a.City == adress.City && a.ApartmentNumber == a.ApartmentNumber);
            report.Person.AdressId = result.Id;
        }

        _context.ErrorReports.Add(report);
        await _context.SaveChangesAsync();
        await GetErrorReports();

    }
    #endregion


}