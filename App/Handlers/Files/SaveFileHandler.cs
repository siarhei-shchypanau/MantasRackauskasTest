
using MantasRackauskasTest.Interfaces;
using MediatR;

namespace MantasRackauskasTest.Handlers.Files;

public class SaveFileHandlerRequest : IRequest<bool>
{
    public List<int> Data { get; set; }
   

    public SaveFileHandlerRequest()
    {

    }
}

public class SaveFileHandlerHandler : IRequestHandler<SaveFileHandlerRequest, bool>
{
    private readonly IConfig _config;

    public SaveFileHandlerHandler(IConfig config)
    {
        _config = config;
    }

    public async Task<bool> Handle(SaveFileHandlerRequest request, CancellationToken cancellationToken)
    {
        if (!Directory.Exists(_config.Path))
        {
            Directory.CreateDirectory(_config.Path);
        }

        
        var logPath = Path.Combine(_config.Path, Guid.NewGuid().ToString()+ ".txt");

        var jsonString = string.Join(' ',request.Data);
        
        await using var streamWriter = File.CreateText(logPath);
        await streamWriter.WriteLineAsync(jsonString);

        return await Task.FromResult(true);
    }
}