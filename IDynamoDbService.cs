namespace Flyingdarts.Persistence;
public interface IDynamoDbService
{
    public Task<Game> GetGame(long gameId);
    public Task<List<GamePlayer>> GetGamePlayers(long gameId);
    public Task<List<GameDart>> GetGamePlayerGameDarts(long gameId);
    public Task PutGame(Game request);
    public Task PutGamePlayer(GamePlayer gamePlayer);
    public Task PutGameDart(GameDart gameDart);
}