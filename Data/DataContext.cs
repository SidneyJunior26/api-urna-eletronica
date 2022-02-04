using Api_UrnaEletronica.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_UrnaEletronica.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Vote> Votes { get; set; }
    }
}