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

        public abstract Task UploadProducts(Files file);

        public abstract Task RemoveProducts(string file_name);
    }
}
