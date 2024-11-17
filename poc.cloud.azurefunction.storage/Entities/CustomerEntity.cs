using poc.cloud.azurefunction.storage.Entities.Base;

namespace poc.cloud.azurefunction.storage.Entities;
public sealed class CustomerEntity : EntityBase
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string ImageUrl { get; set; }
}