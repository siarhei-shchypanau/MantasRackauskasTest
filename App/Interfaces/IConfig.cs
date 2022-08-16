namespace MantasRackauskasTest.Interfaces;

public interface IConfig
{
    public string Path { get; }
}

public class AppConfig : IConfig
{
    public string Path { get; set; }
}