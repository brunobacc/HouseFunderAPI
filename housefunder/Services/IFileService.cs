using housefunder.Models;

namespace housefunder.Services
{
    public abstract class IFileService
    {
        public abstract Task Upload(Files file);

        public abstract Task<Stream> Get(string name);

        public abstract Task Remove(string file_name);
    }
}
