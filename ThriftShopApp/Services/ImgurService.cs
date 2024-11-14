using System.Net.Http.Headers;

namespace ThriftShopApp.Services
{
    public class ImgurService : IImgurService
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrl = "/api/imgur/upload";

        public ImgurService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> UploadImageAsync(byte[] imageData)
        {
            var content = new MultipartFormDataContent();
            var imageContent = new ByteArrayContent(imageData);
            imageContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
            content.Add(imageContent, "file", "image.jpg");

            var response = await _httpClient.PostAsync(ApiUrl, content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public class ImgurResponse
        {
            public required string Url { get; set; }
        }
    }
}
