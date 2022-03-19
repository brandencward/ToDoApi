namespace TodoApi.Services
{
    public interface IReadEnvironmentVariable
    {
        public string GetEnvVariable(string variable);        
    }
}