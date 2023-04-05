namespace Flyingdarts.Persistence;
public class ApplicationOptions
{
    public string DynamoDbTable { get; set; }
    public DynamoDBOperationConfig ToOperationConfig()
    {
        return new DynamoDBOperationConfig { OverrideTableName = DynamoDbTable };
    }
}
