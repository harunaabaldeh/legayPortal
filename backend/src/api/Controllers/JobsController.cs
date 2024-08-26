using api.DTOs;
using api.Entities;
using api.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;


public class JobsController : BaseController
{
    private readonly LegayPortalContext _context;
    public JobsController(LegayPortalContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult> GetJobs()
    {
        return Ok(await _context.Jobs.ToListAsync());
    }

    [HttpGet("{jobId:guid}")]
    public async Task<ActionResult> GetJob(Guid jobId)
    {
        var job = await _context.Jobs.FirstOrDefaultAsync(x => x.Id == jobId);

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
            DatePosted = DateTime.UtcNow
        };

        await _context.Jobs.AddAsync(job);

        await _context.SaveChangesAsync();

        return CreatedAtAction("/jobs/id", job);
    }

    [HttpPut("{jobId:guid}")]
    public async Task<ActionResult> UpdateJob(Guid jobId, JobDto request)
    {
        var job = await _context.Jobs.FirstOrDefaultAsync(j => j.Id == jobId);

        if (job is null) return NotFound("Job not found!");

        job.Title = request.Title;
        job.Description = request.Description;
        job.Location = request.Location;

        await _context.SaveChangesAsync();

        return Ok(job);
    }

    [HttpDelete("{jobId:guid}")]
    public async Task<ActionResult> DeleteJob(Guid jobId)
    {
        var job = _context.Jobs.FirstOrDefaultAsync(j => j.Id == jobId);

        if (job is null) return NotFound("Job not found!");

        _context.Remove(job);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}