using GymHubAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net;

namespace GymHubAPI
{
    public class GymHubSeeder
    {
        private readonly GymHubDbContext _dbContext;
        public GymHubSeeder(GymHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
               var pendingMigrations = _dbContext.Database.GetPendingMigrations();

                if(pendingMigrations != null && pendingMigrations.Any())
                {
                    _dbContext.Database.Migrate();
                }
            }
        }
    }
}
