using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Models;
using Data;

namespace TomorrowC18ProjectOOP.Services
{
    public interface IProfileService
    {
        Profile Authenticate(string username, string password);
        IEnumerable<Profile> GetAll();
        Profile GetById(int id);
        Profile Create(Profile user, string password);
        void Update(Profile user, string currentPassword, string password, string confirmPassword);
        void Delete(int id);
    }

    public class UserService : IProfileService
    {
        private Context _context;

        public UserService(Context context)
        {
            _context = context;
        }

        public Profile Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            var user = _context.Profile.FirstOrDefault(x => x.userName == username) ?? null;

            // check if username exists
            if (user == null)
            {
                return null;
            }

            // Granting access if the hashed password in the database matches with the password(hashed in computeHash method) entered by user.
            if (computeHash(password) != user.passwordHash)
            {
                return null;
            }
            return user;
        }

        public IEnumerable<Profile> GetAll()
        {
            return _context.Profile;
        }

        public Profile GetById(int id)
        {
            return _context.Profile.Find(id);
        }

        public Profile Create(Profile user, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Password is required");
            }

            if (_context.Profile.Any(x => x.userName == user.userName))
            {
                throw new Exception("Username \"" + user.userName + "\" is already taken");
            }

            //Saving hashed password into Database table
            user.passwordHash = computeHash(password);

            _context.Profile.Add(user);
            _context.SaveChanges();

            return user;
        }

        public void Update(Profile userParam, string currentPassword = null, string password = null, string confirmPassword = null)
        {
            //Find the user by Id
            var user = _context.Profile.Find(userParam.id);

            if (user == null)
            {
                throw new Exception("User not found");
            }
            // update user properties if provided
            if (!string.IsNullOrWhiteSpace(userParam.userName) && userParam.userName != user.userName)
            {
                // throw error if the new username is already taken
                if (_context.Profile.Any(x => x.userName == userParam.userName))
                {
                    throw new Exception("Username " + userParam.userName + " is already taken");
                }
                else
                {
                    user.userName = userParam.userName;
                }
            }
            if (!string.IsNullOrWhiteSpace(userParam.firstName))
            {
                user.firstName = userParam.firstName;
            }
            if (!string.IsNullOrWhiteSpace(userParam.lastName))
            {
                user.lastName = userParam.lastName;
            }
            if (!string.IsNullOrWhiteSpace(currentPassword))
            {
                if (computeHash(currentPassword) != user.passwordHash)
                {
                    throw new Exception("Invalid Current password!");
                }

                if (currentPassword == password)
                {
                    throw new Exception("Please choose another password!");
                }

                if (password != confirmPassword)
                {
                    throw new Exception("Password doesn't match!");
                }

                //Updating hashed password into Database table
                user.passwordHash = computeHash(password);
            }

            _context.Profile.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _context.Profile.Find(id);
            if (user != null)
            {
                _context.Profile.Remove(user);
                _context.SaveChanges();
            }
        }

        private static string computeHash(string Password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            var input = md5.ComputeHash(Encoding.UTF8.GetBytes(Password));
            var hashstring = "";
            foreach (var hashbyte in input)
            {
                hashstring += hashbyte.ToString("x2");
            }
            return hashstring;
        }
    }
}
