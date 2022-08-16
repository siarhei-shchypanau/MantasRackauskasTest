
using MediatR;

namespace MantasRackauskasTest.Handlers.Sorting;

public class QSortRequest : IRequest<List<int>>
{
    public List<int> Data { get; set; }
    
    public QSortRequest()
    {

    }
}

public class QSortHandler : IRequestHandler<QSortRequest, List<int>>
{

    public QSortHandler()
    {

    }

    public Task<List<int>> Handle(QSortRequest request, CancellationToken cancellationToken)
    {
        return Task.FromResult(SortArray(request.Data.ToArray(),0,request.Data.Count-1).ToList());
    }

    private int[] SortArray(int[] array, int leftIndex, int rightIndex)
    {
        var i = leftIndex;
        var j = rightIndex;
        var pivot = array[leftIndex];
        
        while (i <= j)
        {
            while (array[i] < pivot)
            {
                i++;
            }
        
            while (array[j] > pivot)
            {
                j--;
            }

            if (i > j) continue;
            (array[i], array[j]) = (array[j], array[i]);
            i++;
            j--;
        }
    
        if (leftIndex < j)
            SortArray(array, leftIndex, j);
        if (i < rightIndex)
            SortArray(array, i, rightIndex);
        return array;
    }
    
}