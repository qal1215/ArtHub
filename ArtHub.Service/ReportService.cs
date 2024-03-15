using ArtHub.BusinessObject;
using ArtHub.DTO.ReportDTO;
using ArtHub.Repository.Contracts;
using ArtHub.Service.Contracts;
using AutoMapper;

namespace ArtHub.Service
{
    public class ReportService : IReportService
    {
        private readonly IMapper _mapper;
        private readonly IReportRepository _reportRepository;
        private readonly IArtworkRepository _artworkRepository;

        public ReportService(IMapper mapper, IReportRepository reportRepository, IArtworkRepository artworkRepository)
        {
            _mapper = mapper;
            _reportRepository = reportRepository;
            _artworkRepository = artworkRepository;
        }

        public async Task<Report> CreateReportAsync(CreateReport reportDto)
        {
            var report = _mapper.Map<Report>(reportDto);
            report.ResolveDescription = "";
            var createdReport = await _reportRepository.CreateReport(report);
            return createdReport;
        }

        public async Task<IEnumerable<Report>> GetAllReportsAsync()
        {
            var reports = await _reportRepository.GetReports();
            return reports;
        }

        public async Task<Report> GetReportByIdAsync(int reportId)
        {
            var report = await _reportRepository.GetReport(reportId);
            return report;
        }

        public async Task<Report?> UpdateReportAsync(int reportId, UpdateReport report)
        {
            var updatedReport = await _reportRepository.UpdateReport(reportId, report);
            if (updatedReport == null)
            {
                return null;
            }

            if (!report.IsBanArtwork) return updatedReport;

            var artwork = await _artworkRepository.GetArtwork(updatedReport.ArtworkId);
            if (artwork is null) return updatedReport;

            artwork.BanStatus = BanStatus.Banned;
            artwork.BanReason = report.ResolveDescription;
            await _artworkRepository.UpdateArtwork(artwork);

            return updatedReport;
        }
    }
}
