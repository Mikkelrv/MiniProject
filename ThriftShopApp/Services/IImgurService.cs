namespace ThriftShopApp.Services
{
    public interface IImgurService
    {
        Task<string> UploadImageAsync(byte[] imageData);
    }
}
