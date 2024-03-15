using ArtHub.BusinessObject;
using ArtHub.BusinessObject.Extensions;
using ArtHub.DTO.ReportDTO;
using ArtHub.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ArtHub.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly ArtHub2024DbContext _dbContext;

        public ReportRepository(ArtHub2024DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Report> CreateReport(Report createReport)
        {
            await _dbContext.Reports.AddAsync(createReport);
            await _dbContext.SaveChangesAsync();
            return createReport;
        }

        public async Task<Report?> GetReport(int id)
        {
            return await _dbContext.Reports.FindAsync(id);
        }

        public async Task<IEnumerable<Report>> GetReports()
        {
            return await _dbContext.Reports
                .Include(r => r.Artwork)
                .ToListAsync();
        }

        public async Task<Report?> UpdateReport(int reportId, UpdateReport updateReport)
        {
            var report = await _dbContext.Reports
                .Include(r => r.Artwork)
                .FirstOrDefaultAsync(r => r.ReportId == reportId);
            if (report == null)
            {
                return null;
            }

            report.MapperValue(updateReport);
            _dbContext.Reports.Update(report);
            await _dbContext.SaveChangesAsync();
            return report;
        }
    }
}
