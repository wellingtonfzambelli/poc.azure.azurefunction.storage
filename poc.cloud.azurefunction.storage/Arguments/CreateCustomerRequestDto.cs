namespace poc.cloud.azurefunction.storage.Arguments;

internal sealed class CreateCustomerRequestDto
{
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}