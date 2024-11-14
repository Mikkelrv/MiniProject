namespace ThriftShopAPI.Repositories
{
    public class ImgurRepo : IImgurRepo  // Remove ControllerBase inheritance
    {
        private readonly HttpClient _httpClient;
        private const string ImgurApiUrl = "https://api.imgur.com/3/image";
        private const string ClientId = "38bc22dd547e381";

        public ImgurRepo(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> UploadImageAsync(byte[] imageData)
        {
            try
            {
                var content = new MultipartFormDataContent();
                content.Add(new ByteArrayContent(imageData), "image", "image.jpg");

                var request = new HttpRequestMessage(HttpMethod.Post, ImgurApiUrl);
                request.Headers.Add("Authorization", $"Client-ID {ClientId}");
                request.Content = content;  // Add this line to attach the content

                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<ImgurResponse>();
                return result?.Data?.Link ?? throw new Exception("Failed to get image link from Imgur");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error uploading to Imgur: {ex.Message}");
                throw;
            }
        }
    }

    // Add these classes if you haven't already
    public class ImgurResponse
    {
        public required ImgurData Data { get; set; }
    }

    public class ImgurData
    {
        public required string Link { get; set; }
    }
}
