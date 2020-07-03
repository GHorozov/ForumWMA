namespace ForumWMA.Services.Interfaces
{
    using ForumWMA.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IUserService
    {
        IEnumerable<T> GetAllUsers<T>();

        Task<IEnumerable<string>> GetUserRoles(string id);

        Task<T> GetUserById<T>(string id);

        Task<bool> DeleteById(string id);

        Task<IdentityResult> ChangePassword(string id, string password);
    }
}
