using System.Linq;
using SQLRunManager.Exceptions;
using SQLRunManager.Models;

namespace SQLRunManager.Services
{
    public class UserService : AbstractDataService<User>
    {
        public bool ValidNickName(User user)
        {
            return !Select(user1 => user1.NickName == user.NickName && user1.Id != user.Id).Any();
        }

        public bool ValidEmail(User user)
        {
            return !Select(user1 => user1.Email == user.Email && user1.Id != user.Id).Any();
        }

        public new void Insert(User user)
        {
            if (!ValidEmail(user))
                throw new EmailUsingException();

            if (!ValidNickName(user))
                throw new NickNameUsingException();

            base.Insert(user);
        }

        public class EmailUsingException : BadRequestException
        {
            public EmailUsingException() : base("邮箱已被占用")
            {
            }
        }

        public class NickNameUsingException : BadRequestException
        {
            public NickNameUsingException() : base("昵称已被占用")
            {
            }
        }
    }
}