using Azure.Data.Tables;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using poc.cloud.azurefunction.storage.Arguments;
using poc.cloud.azurefunction.storage.Entities;

namespace poc.cloud.azurefunction.storage.Functions;

public sealed class CustomerFunction
{
    private readonly ILogger<CustomerFunction> _logger;
    private readonly string _connectionString;

    public CustomerFunction(ILogger<CustomerFunction> logger)
    {
        _connectionString = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
        _logger = logger;
    }

    [Function("SaveCustomerAndUploadImage")]
    public async Task<IActionResult> CreateAsync
    (
        [HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req,
        CancellationToken ct
    )
    {
        _logger.LogInformation("Processing request for Customer and Image upload.");

        if (!req.ContentType.Contains("multipart/form-data"))
            return new BadRequestObjectResult("Expected multipart/form-data content type.");

        // Get form data
        var form = await req.ReadFormAsync();

        if (form["customer"] is var customerData &&
            string.IsNullOrWhiteSpace(customerData))
            return new BadRequestObjectResult("Customer data is missing.");

        if (form.Files["customer-image-file"] is var file &&
            file is null)
            return new BadRequestObjectResult("Image file is missing.");

        var customer = JsonConvert.DeserializeObject<CreateCustomerRequestDto>(customerData);

        string imageUri = await UploadFileAzureBlobAsync(file, ct);

        await SaveCustomerAzureTableAsync(customer, imageUri, ct);

        return new OkObjectResult(new
        {
            Message = "Customer and Image uploaded successfully.",
            Customer = customer,
            ImageUrl = imageUri
        });
    }

    private async Task SaveCustomerAzureTableAsync(CreateCustomerRequestDto customer, string imageUri, CancellationToken ct)
    {
        var tableClient = new TableClient(_connectionString, "TbCustomer");

        // await tableClient.CreateIfNotExistsAsync(); // be careful with this method

        await tableClient.AddEntityAsync
        (
            new CustomerEntity
            {
                PartitionKey = customer.PartitionKey,
                RowKey = customer.RowKey,
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone,
                ImageUrl = imageUri
            }
        );
    }

    private async Task<string> UploadFileAzureBlobAsync(IFormFile file, CancellationToken ct)
    {
        string blobContainerName = Environment.GetEnvironmentVariable("ContainerName");

        var blobServiceClient = new BlobServiceClient(_connectionString);
        var containerClient = blobServiceClient.GetBlobContainerClient(blobContainerName);

        // await containerClient.CreateIfNotExistsAsync(); be careful with this method

        var blobName = $"{Guid.NewGuid()}-{file.FileName}";
        var blobClient = containerClient.GetBlobClient(blobName);

        using (var stream = file.OpenReadStream())
            await blobClient.UploadAsync(stream, overwrite: true);

        return blobClient.Uri.ToString();
    }
}