using JewelleryShop.Business.Service.Interface;
using JewelleryShop.DataAccess.Models;
using JewelleryShop.DataAccess.Models.ViewModel.ImgBBViewModel;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.Business.Service
{
    public class ImgBBService : IImgBBService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ImgBBService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<ImageUploadResponse> UploadImageAsync(byte[] imageBytes)
        {
            var apiKey = _configuration["ImgBBApiSettings:ApiKey"];
            var apiRootURL = _configuration["ImgBBApiSettings:ApiURL"];
            var apiUrl = $"{apiRootURL}{apiKey}";

            try
            {
                string base64Image = Convert.ToBase64String(imageBytes);

                using var content = new MultipartFormDataContent
                {
                    { new StringContent(base64Image), "image" }
                };

                var response = await _httpClient.PostAsync(apiUrl, content);

                if (!response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    //Console.WriteLine($"Error: {response.StatusCode}, Content: {responseContent}");
                    throw new HttpRequestException($"Error uploading image: {response.StatusCode}, Content: {responseContent}");
                }

                var successContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ImageUploadResponse>(successContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                throw;
            }
        }
    }
}
