using Microsoft.AspNetCore.Mvc;
using TodoApi.Services;

namespace TodoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SecretController : ControllerBase
{    

    private readonly ILogger<SecretController> _logger;

    private readonly IReadFiles _readFiles;
    public SecretController(ILogger<SecretController> logger, IReadFiles readFiles)
    {
        _logger = logger;
        _readFiles = readFiles;
    }

    
    [HttpGet(Name = "GetSecret/{path}")]
    public Secret GetSecret(string path)
    {
        Secret secret = new Secret(); 

        try
        {   
            string[] lines = _readFiles.GetFileText(path);               
            secret.SecretValue = lines;            
        }
        catch(Exception ex)
        {
            _logger.LogError("Failed to Get Secret. ", ex);
        }   
        return secret; 
    }   

    [HttpGet("GetEnvironmentVariable/{variable}")]
    public String GetEnvironmentVariable(string variable)
    {        
        string? var = "";
        try
        {   
            var = Environment.GetEnvironmentVariable(variable);
        }
        catch(Exception ex)
        {
            _logger.LogError("Failed to Get Environment Variable. ", ex);
        }   
        return var; 
    }   
}