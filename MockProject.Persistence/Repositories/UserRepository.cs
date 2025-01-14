﻿using MockProject.Domain.Entities;
using MockProject.Domain.Repositories;
using MockProject.Persistence.DataAccess;

using Microsoft.EntityFrameworkCore;

namespace MockProject.Persistence.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly MockProjectDbContext _mockProjectDbContext;

        public UserRepository(MockProjectDbContext mockProjectDbContext)
        {
            _mockProjectDbContext = mockProjectDbContext;
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _mockProjectDbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<User> GetUserByUsernamePasswordAsync(string username, string password)
        {
            return await _mockProjectDbContext.Users.FirstOrDefaultAsync(u => u.UserName == username && u.Password == password);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _mockProjectDbContext.Users.ToListAsync();
        }

        public async Task<int> UpdateUserAsync(Guid id, string email)
        {
            var user = await _mockProjectDbContext.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user is null)
            {
                return 0;
            }

            user.Email = email;
            _mockProjectDbContext.Users.Update(user);

            return 1;
        }
        public async Task<int> CreateUserAsync(string email, string username, string password)
        {
            var user = new User()
            {
                Email = email,
                UserName = username,
                Password = password
            };

            await _mockProjectDbContext.Users.AddAsync(user);

            return 1;
        }

        public async Task<int> DeleteUserAsync(Guid id)
        {
            var user = await _mockProjectDbContext.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user is null)
            {
                return 0;
            }

            _mockProjectDbContext.Users.Remove(user);
            return 1;
        }
    }
}
