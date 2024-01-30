using System.Net.Http.Json;
using System.Text;
using Microsoft.Playwright.NUnit;
using Newtonsoft.Json;
using Test;
using Dapper;





namespace Test;


public class Tests
{

    [Test]
    public async Task TestGetBoxes()
    {
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync($"{ContextConfig.ClientAppBaseUrl}/boxes");


            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                Assert.IsFalse(string.IsNullOrWhiteSpace(responseContent), "API response should not be empty.");
            }
            else
            {
                Assert.Fail($"API request failed with status code: {response.StatusCode}");
            }
        }
    }

    [Test]
    public async Task TestGetBoxById()
    {
        using (HttpClient client = new HttpClient())
        {
            int boxId = 26;
            HttpResponseMessage response = await client.GetAsync($"{ContextConfig.ClientAppBaseUrl}/box/{boxId}");

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                Assert.IsFalse(string.IsNullOrWhiteSpace(responseContent), "API response should not be empty.");
            }
            else
            {
                Assert.Fail($"API request failed with status code: {response.StatusCode}");
            }
        }

    }

    [Test]

    public async Task TestPostBox()
    {
        using (HttpClient client = new HttpClient())
        {
            var boxData = new Box()
            {
                BoxName = "TestBoxTest",
                DateOfCreation = DateTime.Now,
                BoxCategory = "sold"
            };

            HttpResponseMessage response = await client.PostAsJsonAsync($"{ContextConfig.ApiBaseUrl}/NewBox", boxData);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("POST request was successful.");
            }
            else
            {
                Console.WriteLine($"POST request failed with status code: {response.StatusCode}");
                string responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Response content: {responseContent}");
            }

            Assert.IsTrue(response.IsSuccessStatusCode, "POST request should be successful.");
        }
    }

    [Test]
    public async Task TestDeleteBox()
    {
        // rebuild and insert a row with the ID to delete
        ContextConfig.TriggerRebuild();
        
        using (var conn = await ContextConfig.DataSource.OpenConnectionAsync())
        {

            var box = new Box
            {
                BoxId=1,
                BoxName = "YourName",
                DateOfCreation = DateTime.Now,
                BoxCategory = "YourCategory"
            };

            var insertedBox = conn.QueryFirst<Box>(
                "INSERT INTO test_schema.boxes (name, date_of_creation, category) VALUES (@BoxName, @DateOfCreation, @BoxCategory) RETURNING *;",
                box);

            
            int boxIdToDelete = 1;
            
            using (HttpClient client = new HttpClient())
            {

                HttpResponseMessage response =
                    await client.DeleteAsync($"{ContextConfig.ApiBaseUrl}/DeleteBox/{boxIdToDelete}");

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"DELETE request for Box ID {boxIdToDelete} was successful.");
                }
                else
                {
                    Console.WriteLine($"DELETE request failed with status code: {response.StatusCode}");
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Response content: {responseContent}");
                }

                Assert.AreEqual(200, (int)response.StatusCode,
                    "DELETE request should return 204 No Content on success.");
            }
        }

    }
}

    
    
    
    
