namespace ThriftShopAPI.Repositories
{
    public interface IImgurRepo
    {
        Task<string> UploadImageAsync(byte[] imageData);
    }
}
