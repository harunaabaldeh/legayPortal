using api.DTOs;
using api.Entities;
using api.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;

public class ApplicationsController : BaseController
{
    private readonly LegayPortalContext _context;
    public ApplicationsController(LegayPortalContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult> GetApplications()
    {
        return Ok(await _context.Applications.ToListAsync());
    }

    [HttpGet("{applicationId:guid}")]
    public async Task<ActionResult> GetApplication(Guid applicationId)
    {
        var application = await _context.Applications.FirstOrDefaultAsync(x => x.Id == applicationId);

        if (application is null) return NotFound("Application not found!");

        return Ok(application);
    }

    [HttpPost("{jobId:guid}")]
    public async Task<ActionResult> SubmitApplication(Guid jobId, ApplicationDto request)
    {
        var job = await _context.Jobs.FindAsync(jobId);

        if (job is null) return NotFound("Job you are applying for does not exist");

        var application = new Application
        {
            JobId = jobId,
            Name = request.Name,
            Email = request.Email,
            Resume = request.Resume,
            DateApplied = DateTime.UtcNow
        };

        await _context.Applications.AddAsync(application);

        await _context.SaveChangesAsync();

        return Ok(application);
    }

    [HttpPut("{applicationId:guid}")]
    public async Task<ActionResult> UpdateApplication(Guid applicationId, ApplicationDto request)
    {
        var application = await _context.Applications.FirstOrDefaultAsync(a => a.Id == applicationId);

        if (application is null) return NotFound("Application does not exist!");

        application.Name = request.Name;
        application.Email = request.Email;
        application.Resume = request.Resume;
        application.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return Ok(application);
    }

    [HttpDelete("{applicationId:guid}")]
    public async Task<ActionResult> DeleteApplication(Guid applicationId)
    {
        var application = await _context.Applications.FirstOrDefaultAsync(a => a.Id == applicationId);

        if (application is null) return NotFound("Application not found!");

        _context.Remove(application);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}