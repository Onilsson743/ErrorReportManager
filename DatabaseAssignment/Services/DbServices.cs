using DatabaseAssignment.MVVM.Models;
using DatabaseAssignment.MVVM.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
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
    public async Task<ObservableCollection<ErrorReport>> GetErrorReports()
    {
        var result = await _context.ErrorReports.Include(p => p.Person).ThenInclude(a => a.Adress).Include(c => c.Comments).ToListAsync();
        ObservableCollection<ErrorReport> ErrorReports = new ObservableCollection<ErrorReport>();
        if (result != null)
        {            
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
                        Id = x.Id,
                        Date = x.Date,
                        Comment = x.Comment,
                        EmployeeId = x.EmployeeId
                    });
                }
                ErrorReports.Add(eReport);
            } 
        }
        return ErrorReports;
    }

    //Get one error report
    public async Task<ErrorReport> GetOneErrorReport(int id)
    {
        var report = await _context.ErrorReports.Include(p => p.Person).ThenInclude(a => a.Adress).Include(c => c.Comments).FirstOrDefaultAsync(x => x.ErrorId == id);
        if (report != null)
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
                    Id = x.Id,
                    Date = x.Date,
                    Comment = x.Comment,
                    EmployeeId = x.EmployeeId
                });
            }
            //SearchErrorReportViewModel.ErrorReport = eReport;
            return eReport;
        }
        return null!;
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
        };


        //Checks if the person exists
        var Person = await _context.Persons.FirstOrDefaultAsync(a => a.FirstName == person.FirstName && a.LastName == person.LastName && a.Email == person.Email && a.Phone == person.Phone);
        if (Person != null)
        {
            report.PersonId = Person.Id;

        } else
        {
            report.Person = person;

            //Checks if the adress already exists to that person
            var Adress = await _context.Adresses.FirstOrDefaultAsync(a => a.StreetName == adress.StreetName && a.PostalCode == adress.PostalCode && a.City == adress.City && a.ApartmentNumber == a.ApartmentNumber);
            if (Adress != null)
            {
                report.Person.AdressId = Adress.Id;
            }
            else
            {
                var Added = _context.Adresses.Add(adress);
                await _context.SaveChangesAsync();
                var result = await _context.Adresses.FirstOrDefaultAsync(a => a.StreetName == adress.StreetName && a.PostalCode == adress.PostalCode && a.City == adress.City && a.ApartmentNumber == a.ApartmentNumber);
                report.Person.AdressId = result.Id;
            }
        }




        _context.ErrorReports.Add(report);
        await _context.SaveChangesAsync();
        await GetErrorReports();
    }

    //Adds comment to targeted error report
    public async Task AddCommentToErrorReport(CommentsEntity comment)
    {
        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();
        await GetErrorReports();
    }
    #endregion



    //Update functions
    #region
    public async Task<Tuple<string, string>> UpdateErrorReportStatus(int reportId, string status)
    {
        var response = await _context.ErrorReports.FirstAsync(e => e.ErrorId == reportId);
        if (response != null)
        {
            response.Status = status;
            await _context.SaveChangesAsync();
            await GetErrorReports();
            return Tuple.Create("Ärendets status har uppdaterats!", status);
        }
        else
        {
            return Tuple.Create("Någonting gick snett...", status);
        }
    }
    #endregion


    //Remove functions
    #region
    public async Task RemoveErrorReport(int id)
    {
        var response = await _context.ErrorReports.FindAsync(id);
        if (response != null)
        {
            _context.ErrorReports.Remove(response);
            await _context.SaveChangesAsync();
            await GetErrorReports();
        }   
    }
    #endregion

}