using CommunityToolkit.Mvvm.ComponentModel;
using DatabaseAssignment.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAssignment.MVVM.ViewModels;

partial class SearchErrorReportViewModel : ObservableObject
{
    public static ErrorReport errorReport { get; set; } = new ErrorReport();
    public static ObservableCollection<Comments> Comments { get; set; } = new ObservableCollection<Comments>();

}
