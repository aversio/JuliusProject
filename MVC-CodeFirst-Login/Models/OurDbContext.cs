using Microsoft.EntityFrameworkCore;


namespace MVC_CodeFirst_Login.Models {
    public class OurDbContext : DbContext {
        public OurDbContext(DbContextOptions<OurDbContext> options) : base(options) { }
   
        public DbSet<Patient> Patient { get; set; }
        public DbSet<GeneralPractioner> GeneralPractioner { get; set; }
        public DbSet<Consult> Consult { get; set; }
        public DbSet<Diagnosis> Diagnosis { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
    }
}

