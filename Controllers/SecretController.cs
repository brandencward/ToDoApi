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

    
    [HttpGet(Name = "GetSecret")]
    public Secret Get(string path)
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
}
