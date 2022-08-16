using MantasRackauskasTest.Handlers.Sorting;

namespace TestProject1;

// Should be file per handler, just time saving =) 
public class SortingTests
{
    [SetUp]
    public void Setup()
    {
       
    }

    [Test]
    [TestCase(new[]{5,3,1}, new[]{1,3,5})]
    [TestCase(new[]{1}, new[]{1})]
    [TestCase(new[]{-1}, new[]{-1})]
    public async Task BubbleSortTest(int[] input,int[] output)
    {
       var handler =  new BubbleSortHandler();
      var result =  await handler.Handle(new BubbleSortRequest { Data = input.ToList() },
           CancellationToken.None);
       
       Assert.That(output, Is.EqualTo(result));
    }
    
    [Test]
    public void BubbleSortNullTest()
    {
        var handler =  new BubbleSortHandler();
        Assert.CatchAsync(async () =>
        {
         await   handler.Handle(new BubbleSortRequest(),
                CancellationToken.None);
        });
    }
    
    [Test]
    [TestCase(new[]{5,3,1}, new[]{1,3,5})]
    [TestCase(new[]{1}, new[]{1})]
    [TestCase(new[]{-1}, new[]{-1})]
    public async Task QSortTest(int[] input,int[] output)
    {
        var handler =  new QSortHandler();
       var result = await handler.Handle(new QSortRequest { Data = input.ToList() },
            CancellationToken.None);
       
        Assert.That(output, Is.EqualTo(result));
    }
    
    [Test]

    public void QSortNullTest()
    {
        var handler =  new QSortHandler();
      
        Assert.CatchAsync(async () =>
        {
           await handler.Handle(new QSortRequest(),
                CancellationToken.None);
        });
    }
}
