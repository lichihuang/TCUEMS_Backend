using Microsoft.AspNetCore.Mvc;
using TCUEMS_BackendNew.Data;
using TCUEMS_BackendNew.Models;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

[ApiController]
[Route("api/[controller]")]
public class SemesterWarningController : ControllerBase
{
    private readonly ISemesterWarningRepository _semesterWarningRepository;
    private readonly ILogger<SemesterWarningController> _logger;

    public SemesterWarningController(
        ISemesterWarningRepository semesterWarningRepository,
        ILogger<SemesterWarningController> logger)
    {
        _semesterWarningRepository = semesterWarningRepository;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetSemesterWarnings()
    {
        try
        {
            var semesterWarnings = await _semesterWarningRepository.GetAllSemesterWarnings();
            return Ok(semesterWarnings);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while processing GetSemesterWarnings: {ex.Message}");
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost("Search")]
    public async Task<IActionResult> SearchSemesterWarnings([FromBody] SemesterWarning searchCriteria)
    {
        try
        {
            if (searchCriteria == null || !searchCriteria.IsValid())
            {
                return BadRequest("Invalid search criteria");
            }

            _logger.LogInformation($"Received search criteria: {JsonConvert.SerializeObject(searchCriteria)}");

            var semesterWarnings = await _semesterWarningRepository.GetSemesterWarningsByCriteria(searchCriteria);
            return Ok(semesterWarnings);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while processing SearchSemesterWarnings: {ex.Message}");
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost("Combined")]
    public async Task<IActionResult> GetCombinedSemesterWarnings()
    {
        try
        {
            var semesterWarnings = await _semesterWarningRepository.GetAllSemesterWarnings();

            var combinedSemesterWarnings = semesterWarnings
                .GroupBy(sw => sw.w_std_no)
                .Select(group => new {
                    StudentId = group.Key,
                    Warnings = group.Select(sw => new {
                        Department = sw.w_dept_no,
                        Degree=sw.w_degree,
                        StudentClass=sw.w_class,
                        StudentName=sw.chi_name,
                        State=sw.state,
                        InsTime = sw.ins_time,
                        InsIP=sw.ins_ip,
                        InsUser=sw.ins_user,
                        CourseId = sw.w_cos_id,
                        Class = sw.w_cos_class,
                        CourseName = sw.cos_cname,
                        Credit = sw.cos_credit,
                        Teacher = sw.teacher_name,
                        TeacherDept=sw.tch_dept_no,
                        Memo = sw.w_memo,
                        TotalCredit = sw.w_std_total_credit,
                        CourseType=sw.cos_type,
                        Advisor=sw.advisor,
                        Address=sw.address,
                        Parent=sw.parent,
                    }).ToList()
                }).ToList();

            return Ok(combinedSemesterWarnings);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while processing GetCombinedSemesterWarnings: {ex.Message}");
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
