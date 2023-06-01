namespace Flyingdarts.Persistence;

[DynamoDBTable("Flyingdarts-Application-Table")]
public class GameDart : IPrimaryKeyItem, ISortKeyItem, IAlternativeSortKeyItem
{
    [DynamoDBHashKey("PK")]
    public string PrimaryKey { get; set; }

    [DynamoDBRangeKey("SK")]
    public string SortKey { get; set; }

    [DynamoDBLocalSecondaryIndexRangeKey("LSI1")]
    public string LSI1 { get; set; }

    public Guid Id { get; set; }
    public long GameId { get; set; }
    public string PlayerId { get; set; }
    public int Score { get; set; }
    public int GameScore { get; set; }
    public DateTime CreatedAt { get; set; }

    public GameDart()
    {
        PrimaryKey = Constants.GameDart;
    }

    public static GameDart CreateInitial(long gameId, string playerId, int gameScore)
    {
        var id = Guid.NewGuid();
        var createdAt = DateTime.UtcNow;
        return new GameDart()
        {
            Id = id,
            GameId = gameId,
            PlayerId = playerId,
            GameScore = gameScore,
            Score = 0,
            CreatedAt = createdAt,
            SortKey = $"{gameId}#{id}#{playerId}",
            LSI1 = $"{playerId}#{createdAt}"
        };
    }

    public static GameDart Create(long gameId, string playerId, int score, int gameScore)
    {
        var id = Guid.NewGuid();
        var createdAt = DateTime.UtcNow;
        return new GameDart()
        {
            Id = id,
            GameId = gameId,
            PlayerId = playerId,
            GameScore = gameScore,
            Score = score,
            CreatedAt = createdAt,
            SortKey = $"{gameId}#{id}#{playerId}",
            LSI1 = $"{playerId}#{createdAt}"
        };
    }
}