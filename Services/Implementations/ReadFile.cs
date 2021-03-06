namespace TodoApi.Services;

public class ReadFiles : IReadFiles
{
    private readonly ILogger<ReadFiles> _logger;

    public ReadFiles(ILogger<ReadFiles> logger)
    {
        _logger = logger;
    }

    public string[] GetFileText(string path)
    {
        string[] lines = { };

        try
        {
            lines = System.IO.File.ReadAllLines(path);
            _logger.LogInformation($"Reading File Text for {path}");
        }
        catch (Exception ex)
        {
            _logger.LogError("Error Reading File. ", ex);
        }
        return lines;
    }
}