using ArtHub.BusinessObject;
using ArtHub.DTO.ReportDTO;

namespace ArtHub.Repository.Contracts
{
    public interface IReportRepository
    {
        Task<IEnumerable<Report>> GetReports();
        Task<Report?> GetReport(int id);
        Task<Report> CreateReport(Report createReport);
        Task<Report?> UpdateReport(int id, UpdateReport updateReport);
    }
}
