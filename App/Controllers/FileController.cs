using System.Net;
using System.Net.Http.Headers;
using System.Text;
using MantasRackauskasTest.Handlers.Files;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MantasRackauskasTest.Controllers;

/// <summary>
/// Provide possibility to download sorting results 
/// </summary>
[ApiController]
[Route("[controller]")]
public class FileController : Controller
{
    private readonly IMediator _mediator;
    
    // GET
    public FileController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Download sorting results file
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<FileContentResult> Get()
    {
        var fileName="result.txt";
        var mimeType="text/plain"; 
       
        var content = await _mediator.Send(new ReadLastFileRequest());
        byte[] fileBytes = Encoding.UTF8.GetBytes(content);

        return new FileContentResult(fileBytes, mimeType)
        {
            FileDownloadName = fileName
        };
    }
}