using CommunityToolkit.Mvvm.ComponentModel;
using DatabaseAssignment.MVVM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAssignment.MVVM.ViewModels;

partial class NewErrorReportsViewModel : ObservableObject
{
    public static ObservableCollection<Person> Persons { get; set; } = new ObservableCollection<Person>();
    public static ObservableCollection<ErrorReport> ErrorReport { get; set; } = new ObservableCollection<ErrorReport>();



}
