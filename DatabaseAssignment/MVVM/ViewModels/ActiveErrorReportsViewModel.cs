using CommunityToolkit.Mvvm.ComponentModel;
using DatabaseAssignment.MVVM.Models;
using DatabaseAssignment.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAssignment.MVVM.ViewModels;

partial class ActiveErrorReportsViewModel : ObservableObject
{
    public static ObservableCollection<ErrorReport> ActiveErrorReports { get; set; } = new ObservableCollection<ErrorReport>();
    public static ObservableCollection<Comments> Comments { get; set; } = new ObservableCollection<Comments>();



}
