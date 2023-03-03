using DatabaseAssignment.Contexts;
using Microsoft.VisualBasic;
using System;
using System.Threading.Tasks;

namespace DatabaseAssignment.Services;

public abstract class DataBaseServices<T> where T : class
{
    private readonly DataContext _context;

    public DataBaseServices()
    {
        _context = new DataContext();
    }

    public virtual async Task<T> AddToDatabase(T content)
    {
        _context.Set<T>().Add(content);
        await _context.SaveChangesAsync();

        return content;
    }
}
