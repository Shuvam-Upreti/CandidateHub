using CandidateHub.Core.Entities;
using CandidateHub.Logging;
using Microsoft.EntityFrameworkCore;

namespace CandidateHub.SeedData
{
    public class ApplicationDbInitializer
    {
        private readonly CandidateContext _context;

        public ApplicationDbInitializer(CandidateContext context)
        {
            _context = context;
        }

        public void Initialize()
        {
            // Applying migrations automatically
            try
            {
                if (_context.Database.GetPendingMigrations().Any())
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                new SeriLogger().Error(ex.Message, ex);
            }
        }
    }
}
