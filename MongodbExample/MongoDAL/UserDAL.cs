using MongoDB.Driver;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace MongoDAL 
{
    public class UserDAL 
    {
        private readonly IMongoCollection<User> users;

        public UserDAL() 
        {
            var client = DBAccess.GetClient();
            var db = client.GetDatabase("sample_mflix");

            users = db.GetCollection<User>("users");
        }

        public List<User> GetAll() => users.Find(user => true).ToList();

        public User GetUserByName(string name) => users.Find(user => user.Name.ToLower() == name.ToLower()).First();

        public void Update(User ToUpdate) => users.ReplaceOne(user => user.Id == ToUpdate.Id, ToUpdate);
    }
}