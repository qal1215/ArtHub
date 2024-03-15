using ArtHub.BusinessObject;
using ArtHub.DTO.ReportDTO;

namespace ArtHub.Service.Contracts
{
    public interface IReportService
    {
        Task<Report?> CreateReportAsync(CreateReport reportDto);
        Task<IEnumerable<Report>> GetAllReportsAsync();
        Task<Report> GetReportByIdAsync(int reportId);
        Task<Report?> UpdateReportAsync(int reportId, UpdateReport report);
    }
}
