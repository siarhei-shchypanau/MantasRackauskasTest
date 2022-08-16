using MantasRackauskasTest.Handlers.Files;
using MantasRackauskasTest.Handlers.Sorting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MantasRackauskasTest.Controllers;

/// <summary>
/// The controller provide posibility to sort 
/// </summary>
[ApiController]
[Route("[controller]")]
public class SortController : Controller
{
    private readonly IMediator _mediator;


    public SortController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Sort data by different types
    /// </summary>
    /// <param name="data">The array of sorting</param>
    /// <param name="sorting">the sorting types Bubble=0 or QSort=1 </param>
    [HttpPost]
    public async Task Post([FromBody]List<int> data, [FromQuery]SortingType sorting = SortingType.Burble)
    {
        List<int> sortingResult = null;
        switch (sorting)
        {
            case SortingType.Burble:
            {
                sortingResult = await _mediator.Send(new BubbleSortRequest { Data = data });
                break;
            }

            case SortingType.QSort:
            {
                sortingResult = await _mediator.Send(new QSortRequest { Data = data });
                break;
            }
        }

        await _mediator.Send(new SaveFileHandlerRequest() { Data = sortingResult });
    }
}

public enum SortingType
{
    Burble,
    QSort
}