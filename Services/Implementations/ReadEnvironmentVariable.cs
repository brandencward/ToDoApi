namespace TodoApi.Services;

public class ReadEnvironmentVariable : IReadEnvironmentVariable
{
    private readonly ILogger<ReadEnvironmentVariable> _logger;

    public ReadEnvironmentVariable(ILogger<ReadEnvironmentVariable> logger)
    {
        _logger = logger;
    }

    public string GetEnvVariable(string variable)
    {
        string? var = "";
        try
        {
           var = Environment.GetEnvironmentVariable(variable);          
        }
        catch (Exception ex)
        {
            _logger.LogError("Error Reading File. ", ex);
        }
        if(var is null){
            var = "";
        }
        return var;
    }
}