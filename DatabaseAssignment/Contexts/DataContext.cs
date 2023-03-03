using DatabaseAssignment.MVVM.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace DatabaseAssignment.Contexts;

public class DataContext : DbContext
{

	private readonly string serverString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\onils\\OneDrive\\Skrivbord\\Win22\\DataLagring\\local_db.mdf;Integrated Security=True;Connect Timeout=30";

	public DataContext()
	{

	}
	public DataContext(DbContextOptions<DataContext> options) : base(options)
	{

	}
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		if (!optionsBuilder.IsConfigured)
		{
            optionsBuilder.UseSqlServer(serverString);
        }
			
	}


	public DbSet<AdressEntity> Adresses { get; set; }
	public DbSet<PersonEntity> Persons { get; set; }
	public DbSet<ErrorReportEntity> ErrorReports { get; set; }
	public DbSet<EmployeeEntity> Employees { get; set; }
	public DbSet<CommentsEntity> Comments { get; set; }
}
