
using MantasRackauskasTest.Interfaces;
using MediatR;

namespace MantasRackauskasTest.Handlers.Files;

public class ReadLastFileRequest : IRequest<string>
{
    public ReadLastFileRequest()
    {

    }
}

public class ReadLastFileHandler : IRequestHandler<ReadLastFileRequest, string>
{
    private readonly IConfig _config;

    public ReadLastFileHandler(IConfig config)
    {
        _config = config;
    }

    public async Task<string> Handle(ReadLastFileRequest request, CancellationToken cancellationToken)
    {
        var directory = new DirectoryInfo(_config.Path);

        if (directory is null)
            throw new DirectoryNotFoundException($"Directory {_config.Path} not found");
        
        var myFile = directory.GetFiles()
            .OrderByDescending(f => f.CreationTime)
            .First();

        if (myFile is null)
            throw new FileNotFoundException($"No files in {_config.Path} direcory");

        var data = await myFile.OpenText().ReadLineAsync();

        return data ?? string.Empty;
    }
}