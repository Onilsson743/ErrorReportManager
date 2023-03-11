using CommunityToolkit.Mvvm.ComponentModel;
using DatabaseAssignment.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace DatabaseAssignment.Services;

public class ContentDataServices 
{
    public static ObservableCollection<Adress> Adresses { get; set; } = new ObservableCollection<Adress>();
    public static ObservableCollection<Comments> Comments { get; set; } = new ObservableCollection<Comments>();
    public static ObservableCollection<Employee> Employees { get; set; } = new ObservableCollection<Employee>();
    public static ObservableCollection<ErrorReport> ErrorReports { get; set; } = new ObservableCollection<ErrorReport>();    
    public static ObservableCollection<ErrorReport> NewErrorReports { get; set; } = new ObservableCollection<ErrorReport>();    
    public static ObservableCollection<ErrorReport> ActiveErrorReports { get; set; } = new ObservableCollection<ErrorReport>();    
    public static ObservableCollection<ErrorReport> FinishedErrorReports { get; set; } = new ObservableCollection<ErrorReport>();    
    public static ObservableCollection<Person> Persons { get; set; } = new ObservableCollection<Person>();



    public DbServices DbServices = new DbServices();


    public static void SetErrorReports()
    {

    }




}
