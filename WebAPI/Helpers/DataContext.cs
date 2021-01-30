using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebAPI.Entities;

namespace WebAPI.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server database
            options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
        }
                  
        public DbSet<Customer> Customers { get; set; }
        public DbSet<File_Media> File_Media { get; set; }
        public DbSet<Flow> Flows { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Mould> Moulds { get; set; }
        public DbSet<Mould_Detail> Mould_Details { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<PartMould_Type> PartMould_Types { get; set; }        
        public DbSet<PartSet> PartSets { get; set; }
        public DbSet<PartSet_Detail> PartSet_Details { get; set; }
        public DbSet<Production_Type> Production_Types { get; set; }
        public DbSet<Schedule_Job> Schedule_Jobs { get; set; }
        public DbSet<Shift_Type> Shift_Types { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<OperationDetail> OperationDetails { get; set; }
        public DbSet<Operator_Entry> Operator_Entries { get; set; }
        public DbSet<Operator_Entry_Detail> Operator_Entry_Details { get; set; }        
        public DbSet<WorkStation> WorkStations { get; set; }

    }
}