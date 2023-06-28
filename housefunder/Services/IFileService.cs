using housefunder.Models;

namespace housefunder.Services
{
    public abstract class IFileService
    {
        public abstract Task UploadUser(Files file);

        public abstract Task<Stream> Get(string name);

        public abstract Task RemoveUser(string file_name);

        public abstract Task UploadProject(Files file);

        public abstract Task RemoveProject(string file_name);

        public abstract Task UploadProduct(Files file);

        public abstract Task RemoveProduct(string file_name);
    }
}
