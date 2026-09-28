using Microsoft.EntityFrameworkCore;

namespace PowerZoneGym.Models
{
    //entity framework is "code first approch" its like migrations work there 
    public class GymDbContext : DbContext
    {
        public GymDbContext(DbContextOptions<GymDbContext> options) : base(options)
        {

        }
            public DbSet<GymTrainee> Trainees { get; set; }
            public DbSet<BloodGroup> BloodGroups { get; set; }
            public DbSet<TrainingLevel> TrainingLevels { get; set; }
            public DbSet<MonthlyFeeVoucher> MonthlyFeeVouchers { get; set;  }   

}
}
