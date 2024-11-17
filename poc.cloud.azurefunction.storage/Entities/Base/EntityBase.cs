using Azure;
using Azure.Data.Tables;

namespace poc.cloud.azurefunction.storage.Entities.Base;
public abstract class EntityBase : ITableEntity
{
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public ETag ETag { get; set; } = ETag.All;
    public DateTimeOffset? Timestamp { get; set; }
}