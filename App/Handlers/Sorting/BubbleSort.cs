using MediatR;
namespace MantasRackauskasTest.Handlers.Sorting;

/// <inheritdoc />
public class BubbleSortRequest : IRequest<List<int>>
{
    public List<int> Data { get; set; }
    
    public BubbleSortRequest()
    {

    }
}

public class BubbleSortHandler : IRequestHandler<BubbleSortRequest, List<int>>
{

    public BubbleSortHandler()
    {

    }

    public Task<List<int>> Handle(BubbleSortRequest request, CancellationToken cancellationToken)
    {
        if (request.Data == null)
            throw new ArgumentException(nameof(request.Data));

        var arr = request.Data.ToArray();
        for (var j = 0; j <= arr.Length - 2; j++) {
            for (var i = 0; i <= arr.Length - 2; i++) {
                if (arr[i] > arr[i + 1]) {
                    (arr[i + 1], arr[i]) = (arr[i], arr[i + 1]);
                }
            }
        }
        
        return Task.FromResult(arr.ToList());
    }
}