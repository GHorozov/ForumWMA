namespace ForumWMA.Services
{
    using AutoMapper;
    using ForumWMA.Common.Mapper;
    using ForumWMA.Data;
    using ForumWMA.Data.Models;
    using ForumWMA.Services.Interfaces;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserService : IUserService
    {
        private readonly ForumWMADbContext context;
        private readonly UserManager<ForumWMAUser> userManager;
        private readonly IMapper mapper;

        public UserService(ForumWMADbContext context, UserManager<ForumWMAUser> userManager, IMapper mapper)
        {
            this.context = context;
            this.userManager = userManager;
            this.mapper = mapper;
        }


        public IEnumerable<T> GetAllUsers<T>()
        {
            var users = this.context
                .Users
                .To<T>(this.mapper);

            return users;
        }

        public async Task<IEnumerable<string>> GetUserRoles(string id)
        {
            var user = await this.context
                .Users
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            if (user == null) return new List<string>();

            var userInRoles = await this.userManager
                .GetRolesAsync(user);

            return userInRoles;
        }

        public async Task<T> GetUserById<T>(string id)
        {
            var user = await this.context
                .Users
                .Where(x => x.Id == id)
                .AsQueryable()
                .To<T>(this.mapper)
                .SingleOrDefaultAsync();

            return user;
        }

        public async Task<IdentityResult> ChangePassword(string id, string password)
        {
            var user = await this.userManager.FindByIdAsync(id);
            var token = await this.userManager.GeneratePasswordResetTokenAsync(user);
            var result = await this.userManager.ResetPasswordAsync(user, token, password);

            return result;
        }
    }
}
