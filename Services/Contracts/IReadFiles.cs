namespace TodoApi.Services
{
    public interface IReadFiles
    {
        public string[] GetFileText(string path);        
    }
}