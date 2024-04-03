using Shared.Models;
using System.Text;
using System.Text.Json;
using System.Net;
using System.Net.Http.Json;

namespace FormulaOne.Client.Services
{
    public class DriverService : IDriverService
    {
        private readonly HttpClient _httpClient;
        public DriverService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Driver?> AddDriver(Driver driver)
        {
            try
            {
                var itemJson = new StringContent(JsonSerializer.Serialize(driver), Encoding.UTF8, "application/json");
                
                var response = await _httpClient.PostAsync("/api/drivers", itemJson);
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStreamAsync();
                    var addedDriver = await JsonSerializer.DeserializeAsync<Driver>(responseBody, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    });

                    return addedDriver;
                }
                return null;
            }catch (Exception ex)
            {
                throw new Exception($"a problem happend while adding this driver, message : {ex.Message}");
            }
        }

        public async Task<IEnumerable<Driver>?> All()
        {
            try
            {
                var response = await _httpClient.GetAsync("/api/Drivers");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<Driver>();
                    }

                    return await response.Content.ReadFromJsonAsync<IEnumerable<Driver>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("get all went wrong!");
            }
        }

        public async Task<bool> DeleteDriver(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/api/drivers/{id}");

                return response.IsSuccessStatusCode;
            }catch(Exception ex)
            {
                throw new Exception("delete went wrong!");
            }
        }

        public async Task<Driver?> GetDriver(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/drivers/{id}");
                if ( response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return null;
                    }
                    return await response.Content.ReadFromJsonAsync<Driver>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }catch(Exception ex) {
                throw new Exception("get single driver went wrong!");
            }
        }

        public async Task<bool> UpdateDriver(Driver driver)
        {
            try
            {
                var itemJson = new StringContent(JsonSerializer.Serialize(driver), Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"/api/drivers/{driver.Id}",itemJson);
                return response.IsSuccessStatusCode;
            }catch(Exception ex)
            {
                throw new Exception("update driver went wrong");
            }
        }
    }
}
