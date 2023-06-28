using Azure.Storage.Blobs;
using housefunder.Models;

namespace housefunder.Services
{
    public class FileService : IFileService
    {
        private readonly BlobServiceClient _blobServiceClient;

        public FileService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }
        override public async Task UploadUser(Files file)
        {
            var containerInstance = _blobServiceClient.GetBlobContainerClient("images");

            var blobInstance = containerInstance.GetBlobClient(file.image_file.FileName);

            await blobInstance.UploadAsync(file.image_file.OpenReadStream());
        }

        override public async Task<Stream> Get(string name)
        {
            var containerInstance = _blobServiceClient.GetBlobContainerClient("images");

            var blobInstance = containerInstance.GetBlobClient(name);

            var downloadContent = await blobInstance.DownloadAsync();

            return downloadContent.Value.Content;
        }

        override public async Task RemoveUser(string file_name)
        {
            var containerInstance = _blobServiceClient.GetBlobContainerClient("images");

            var blobInstance = containerInstance.GetBlobClient(file_name);

            await blobInstance.DeleteAsync();
        }
        override public async Task UploadProject(Files file)
        {
            var containerInstance = _blobServiceClient.GetBlobContainerClient("projects");

            var blobInstance = containerInstance.GetBlobClient(file.image_file.FileName);

            await blobInstance.UploadAsync(file.image_file.OpenReadStream());
        }

        override public async Task RemoveProject(string file_name)
        {
            var containerInstance = _blobServiceClient.GetBlobContainerClient("projects");

            var blobInstance = containerInstance.GetBlobClient(file_name);

            await blobInstance.DeleteAsync();
        }
        override public async Task UploadProduct(Files file)
        {
            var containerInstance = _blobServiceClient.GetBlobContainerClient("products");

            var blobInstance = containerInstance.GetBlobClient(file.image_file.FileName);

            await blobInstance.UploadAsync(file.image_file.OpenReadStream());
        }

        override public async Task RemoveProduct(string file_name)
        {
            var containerInstance = _blobServiceClient.GetBlobContainerClient("products");

            var blobInstance = containerInstance.GetBlobClient(file_name);

            await blobInstance.DeleteAsync();
        }
    }
}
