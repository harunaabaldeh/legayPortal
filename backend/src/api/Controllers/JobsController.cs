using api.Common.Interfaces;
using api.DTOs;
using api.Entities;
using api.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;


public class JobsController : BaseController
{
    private readonly LegayPortalContext _legayPortalContext;
    private readonly ICurrentUserService _currentUserService;
    public JobsController(LegayPortalContext legayPortalContext, ICurrentUserService currentUserService)
    {
        _legayPortalContext = legayPortalContext;
        _currentUserService = currentUserService;
    }

    [HttpGet]
    public async Task<ActionResult> GetJobs(string keyword = null, string location = null)
    {
        var query = _legayPortalContext.Jobs.AsQueryable();

        if (!string.IsNullOrEmpty(keyword))
        {
            query = query.Where(job => job.Title.Contains(keyword) || job.Description.Contains(keyword));
        }

        if (!string.IsNullOrEmpty(location))
            query = query.Where(job => job.Location.Contains(location));


        var result = await query.ToListAsync();

        return Ok(result);
    }

    [HttpGet("{jobId:guid}")]
    public async Task<ActionResult> GetJob(Guid jobId)
    {
        var job = await _legayPortalContext.Jobs.FirstOrDefaultAsync(x => x.Id == jobId);

        if (job is null) return NotFound("Job does not exit");

        return Ok(job);
    }

    [HttpPost]
    public async Task<ActionResult> SubmitJob(JobDto request)
    {
        var job = new Job
        {
            Title = request.Title,
            Description = request.Description,
            Location = request.Location,
            Company = request.Company,
            DatePosted = DateTime.UtcNow,
            UserId = _currentUserService.UserId()
        };

        await _legayPortalContext.Jobs.AddAsync(job);

        await _legayPortalContext.SaveChangesAsync();

        return Ok(job);
    }

    [HttpPut("{jobId:guid}")]
    public async Task<ActionResult> UpdateJob(Guid jobId, JobDto request)
    {
        var job = await _legayPortalContext.Jobs.FirstOrDefaultAsync(j => j.Id == jobId);

        if (job is null) return NotFound("Job not found!");

        if (job.UserId != _currentUserService.UserId())
            return Unauthorized();

        job.Title = request.Title;
        job.Description = request.Description;
        job.Location = request.Location;

        await _legayPortalContext.SaveChangesAsync();

        return Ok(job);
    }

    [HttpDelete("{jobId:guid}")]
    public async Task<ActionResult> DeleteJob(Guid jobId)
    {
        var job = await _legayPortalContext.Jobs.FirstOrDefaultAsync(j => j.Id == jobId);

        if (job is null) return NotFound("Job not found!");

        if (job.UserId != _currentUserService.UserId())
            return Unauthorized();

        _legayPortalContext.Remove(job);

        await _legayPortalContext.SaveChangesAsync();

        return NoContent();
    }
}