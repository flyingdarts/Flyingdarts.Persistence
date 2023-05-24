namespace Flyingdarts.Persistence
{
    [DynamoDBTable("Flyingdarts-Application-Table")]
    public class User : IPrimaryKeyItem, ISortKeyItem, IAlternativeSortKeyItem
    {
        [DynamoDBHashKey("PK")]
        public string PrimaryKey { get; set; }

        [DynamoDBRangeKey("SK")]
        public string SortKey { get; set; }

        [DynamoDBLocalSecondaryIndexRangeKey("LSI1")]
        public string LSI1 { get; set; }

        public long UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CognitoUserId { get; set; }
        public UserProfile Profile { get; set; }

        public User()
        {
            CreatedAt = DateTime.UtcNow;
            UserId = CreatedAt.Ticks;
            PrimaryKey = Constants.User;
        }

        public static User Create(string cognitoUserId, UserProfile userProfile)
        {
            var user = new User()
            {
                CognitoUserId = cognitoUserId,
                Profile = userProfile
            };
            user.SortKey = user.UserId.ToString();
            user.LSI1 = $"{userProfile.Country}#{user.CreatedAt}";

            return user;
        }
    }

    public interface IUserProfile
    {
        string UserName { get; set; }
        string Email { get; set; }
        string Country { get; set; }
    }
    public class UserProfile : IUserProfile
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }

        public UserProfile()
        {
            // required for dynamodb
        }

        public UserProfile(string userName, string email, string country)
        {
            UserName = userName;
            Email = email;
            Country = country;
        }

        public static UserProfile Create(string userName, string email, string country)
        {
            return new UserProfile
            {
                UserName = userName,
                Email = email,
                Country = country
            };
        }
    }
}
