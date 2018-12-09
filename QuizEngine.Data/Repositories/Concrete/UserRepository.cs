using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using QuizEngine.Data.Entities;

namespace QuizEngine.Data.Repositories.Concrete
{
    public class UserRepository : IUserRepository
    {
        private const string fileUserRepository = @"AdminUser.txt";
        private const string folderUserRepository = @"C:\temp";

        public User Get(string username)
        {
            // TODO: Setup db authentication

            return new User();
        }
    }
}
