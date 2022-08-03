using BugTracker.DataAccessLayer.Entities;
using BugTracker.DataModel;

namespace BugTracker.Services.Mapper
{
    public static class UserMapper
    {
        public static User<TKey> ToModelEntity<TKey>(this UserEntity<TKey> user)
        {
            return new User<TKey>()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
            };
        }

        public static UserEntity<TKey> ToDbEntity<TKey>(this User<TKey> user)
        {
            return new UserEntity<TKey>()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
            };
        }
    }
}
