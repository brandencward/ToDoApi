using Microsoft.AspNetCore.Mvc;
using TodoApi.Services;

namespace TodoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SecretController : ControllerBase
{    

    private readonly ILogger<SecretController> _logger;

    private readonly IReadFiles _readFiles;
    private readonly IReadEnvironmentVariable _readEnvironmentVariable;
    public SecretController(ILogger<SecretController> logger, IReadFiles readFiles, IReadEnvironmentVariable readEnvironmentVariable)
    {
        _logger = logger;
        _readFiles = readFiles;
        _readEnvironmentVariable = readEnvironmentVariable;
    }

    
    [HttpGet(Name = "GetSecret/{path}")]
    public Secret GetSecret(string path)
    {
        Secret secret = new Secret(); 

        try
        {   
            secret.SecretValue = _readFiles.GetFileText(path);
        }
        catch(Exception ex)
        {
            _logger.LogError("Failed to Get Secret. ", ex);
        }   
        return secret; 
    }   

    [HttpGet("GetEnvironmentVariable/{variable}")]
    public EnvironmentVariable GetEnvironmentVariable(string variable)
    {        
        EnvironmentVariable environmentVariable = new EnvironmentVariable();
        try
        {   
            environmentVariable.EnvironmentVariableValue = _readEnvironmentVariable.GetEnvVariable(variable);
        }
        catch(Exception ex)
        {
            _logger.LogError("Failed to Get Environment Variable. ", ex);
        }   
        return environmentVariable; 
    }   
}