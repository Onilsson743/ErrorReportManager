using CommunityToolkit.Mvvm.ComponentModel;
using DatabaseAssignment.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace DatabaseAssignment.Services;

public static class ContentDataServices 
{
    public static ObservableCollection<ErrorReport> ErrorReports { get; set; } = new ObservableCollection<ErrorReport>();    


    public static ObservableCollection<ErrorReport> GetList()
    {
        return ErrorReports;
    }




}
