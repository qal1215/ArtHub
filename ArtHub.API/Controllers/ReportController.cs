using ArtHub.DTO.ReportDTO;
using ArtHub.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ArtHub.API.Controllers
{
    [Route("report")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        public async Task<IActionResult> GetReports()
        {
            var reports = await _reportService.GetAllReportsAsync();
            return Ok(reports);
        }

        [HttpGet("{id}")]
        public IActionResult GetReport(int id)
        {
            var report = _reportService.GetReportByIdAsync(id);
            if (report is null) return NotFound();
            return Ok(report);
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateReportAsync([FromBody] CreateReport createReport)
        {
            var report = await _reportService.CreateReportAsync(createReport);
            return Ok(report);
        }

        [HttpPut("{reportId}")]
        public async Task<IActionResult> UpdateReportAsync([FromRoute] int reportId, [FromBody] UpdateReport updateReport)
        {
            var report = await _reportService.UpdateReportAsync(reportId, updateReport);
            if (report is null) return BadRequest();
            return Ok(report);
        }
    }
}
