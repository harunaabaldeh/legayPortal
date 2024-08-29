using api.Common.Interfaces;
using api.DTOs;
using api.Entities;
using api.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;

public class ApplicationsController : BaseController
{
    private readonly LegayPortalContext _legayPortalContext;
    private readonly ICurrentUserService _currentUserService;
    public ApplicationsController(LegayPortalContext legayPortalContext, ICurrentUserService currentUserService)
    {
        _legayPortalContext = legayPortalContext;
        _currentUserService = currentUserService;
    }

    [HttpGet]
    public async Task<ActionResult> GetApplications()
    {
        var apps = await _legayPortalContext.Applications
                        .Where(a => a.UserId == _currentUserService.UserId())
                        .ToListAsync();
        return Ok();
    }

    [HttpGet("{applicationId:guid}")]
    public async Task<ActionResult> GetApplication(Guid applicationId)
    {
        var application = await _legayPortalContext.Applications.FirstOrDefaultAsync(x => x.Id == applicationId);

        if (application is null) return NotFound("Application not found!");

        return Ok(application);
    }

    [HttpPost("{jobId:guid}")]
    public async Task<ActionResult> SubmitApplication(Guid jobId, ApplicationDto request)
    {
        var job = await _legayPortalContext.Jobs.FindAsync(jobId);

        if (job is null) return NotFound("Job you are applying for does not exist");

        var application = new Application
        {
            JobId = jobId,
            Name = request.Name,
            Email = request.Email,
            Resume = request.Resume,
            UserId = _currentUserService.UserId(),
            DateApplied = DateTime.UtcNow
        };

        await _legayPortalContext.Applications.AddAsync(application);

        await _legayPortalContext.SaveChangesAsync();

        return Ok(application);
    }

    [HttpPut("{applicationId:guid}")]
    public async Task<ActionResult> UpdateApplication(Guid applicationId, ApplicationDto request)
    {
        var application = await _legayPortalContext.Applications.FirstOrDefaultAsync(a => a.Id == applicationId);

        if (application is null) return NotFound("Application does not exist!");

        if (application.UserId != _currentUserService.UserId()) return Unauthorized();

        application.Name = request.Name;
        application.Email = request.Email;
        application.Resume = request.Resume;
        application.UpdatedAt = DateTime.UtcNow;

        await _legayPortalContext.SaveChangesAsync();

        return Ok(application);
    }

    [HttpDelete("{applicationId:guid}")]
    public async Task<ActionResult> DeleteApplication(Guid applicationId)
    {
        var application = await _legayPortalContext.Applications.FirstOrDefaultAsync(a => a.Id == applicationId);

        if (application is null) return NotFound("Application not found!");

        if (application.UserId != _currentUserService.UserId()) return Unauthorized();

        _legayPortalContext.Remove(application);

        await _legayPortalContext.SaveChangesAsync();

        return NoContent();
    }
}